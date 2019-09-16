using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zeeslag.Boards;
using Zeeslag.Extentions;
using Zeeslag.Ships;

namespace Zeeslag
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board { get; set; }
        public ShotBoard ShotBoard { get; set; }
        public List<Ship> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsDestoyed);
            }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            Board = new Board();
            ShotBoard = new ShotBoard();
        }

        public Coordinates FireShot()
        {
            var ShotNeigbors = ShotBoard.GetShotNeighbors();

            Coordinates coordinates;
            if(ShotNeigbors.Any())
            {
                coordinates = SearchingShot();
            }
            else
            {
                coordinates = RandomShot();
            }
            return coordinates;
        }

        private Coordinates RandomShot()
        {
            var openTiles = ShotBoard.GetOddRandomPanels();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var tileCoord = rand.Next(openTiles.Count);
            return openTiles[tileCoord];
        }

        private Coordinates SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbors = ShotBoard.GetShotNeighbors();
            var neighborID = rand.Next(hitNeighbors.Count);
            return hitNeighbors[neighborID];
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed panels are occupied, place the ship
                //Do this for all ships

                bool isOpen = true;
                while (isOpen)
                {
                    //Next() has the second parameter be exclusive, while the first parameter is inclusive.
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2; //0 for Horizontal

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Parts.Count; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Parts.Count; i++)
                        {
                            endcolumn++;
                        }
                    }

                    //We cannot place ships beyond the boundaries of the board
                    if (endrow > 10 || endcolumn > 10)
                    {
                        isOpen = true;
                        continue; //Restart the while loop to select a new random panel
                    }

                    //Check if specified panels are occupied
                    var affectedPanels = Board.Tiles.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedPanels.Any(x => x.Occupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    for (int i = 0; i < affectedPanels.Count; i++)
                    {
                        affectedPanels[i].TileOccupation = ship.TileOccupation;
                        affectedPanels[i].ShipPart = ship.Parts[i];
                        if (orientation == 0) affectedPanels[i].ShipPart.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    isOpen = false;
                }
            }
        }

        public void OutputBoards(List<PictureBox> ownBoard, List<PictureBox> shotBoard)
        {
            for (int index = 0; index <= 99; index++)
            {

                ownBoard[index].Image = ShotToDraw(Board.Tiles[index].ShotResult);
                ownBoard[index].BackgroundImage = Board.Tiles[index].ShipPart?.Image;
                shotBoard[index].Image = ShotToDraw(ShotBoard.Tiles[index].ShotResult);
            }
            ownBoard[0].Parent.Refresh();
        }

        private Image ShotToDraw(ShotResult shotResult)
        {
            switch (shotResult)
            {
                case ShotResult.None:
                    return null;
                case ShotResult.Hit:
                    return Images.explosion;
                case ShotResult.Miss:
                    return Images.splash;
                default:
                    return null;
            }
        }

        public ShotResult ProcessShot(Coordinates coords, Label response)
        {
            var tile = Board.Tiles.At(coords.Row, coords.Column);
            if (!tile.Occupied)
            {
                response.Text = $"{Name} says: Miss!";
                response.Refresh();
                tile.ShotResult = ShotResult.Miss;
                return ShotResult.Miss;
            }
            var ship = Ships.First(x => x.TileOccupation == tile.TileOccupation);
            ship.Hits++;
            tile.ShotResult = ShotResult.Hit;
            response.Text = $"{Name} says: Hit!";

            if (ship.IsDestoyed)
            {
                response.Text = $"{Name} says: You sunk my {ship.Name}!";
            }

            response.Refresh();
            return ShotResult.Hit;
        }

        public void ProcessShotResult(Coordinates coords, ShotResult result)
        {
            var tile = ShotBoard.Tiles.At(coords.Row, coords.Column);
            switch (result)
            {
                case ShotResult.Hit:
                    tile.ShotResult = ShotResult.Hit;
                    break;

                default:
                    tile.ShotResult = ShotResult.Miss;
                    break;
            }
        }
    }
}