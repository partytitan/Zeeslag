using Zeeslag.Ships;

namespace Zeeslag.Boards
{
    public class Tile
    {
        public Coordinates Coordinates { get; set; }
        public ShotResult ShotResult { get; set; }
        public ShipPart ShipPart { get; set; }
        public TileOccupation TileOccupation { get; set; }

        public Tile(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            ShotResult = ShotResult.None;
        }

        public bool Occupied
        {
            get
            {
                return TileOccupation == TileOccupation.Battleship
                    || TileOccupation == TileOccupation.Destroyer
                    || TileOccupation == TileOccupation.Cruiser
                    || TileOccupation == TileOccupation.Submarine
                    || TileOccupation == TileOccupation.Carrier;
            }
        }

        public bool IsOdd
        {
            get
            {
                return (Coordinates.Row % 2 == 0 && Coordinates.Column % 2 == 0)
                    || (Coordinates.Row % 2 == 1 && Coordinates.Column % 2 == 1);
            }
        }
    }
}