using System.Collections.Generic;
using System.Linq;
using Zeeslag.Extentions;

namespace Zeeslag.Boards
{
    public class ShotBoard : Board
    {
        public List<Coordinates> GetOddRandomPanels()
        {
            return Tiles.Where(x => x.TileOccupation == TileOccupation.Empty && x.IsOdd).Select(x => x.Coordinates).ToList();
        }

        public List<Coordinates> GetShotNeighbors()
        {
            List<Tile> tiles = new List<Tile>();
            var hits = Tiles.Where(x => x.ShotResult == ShotResult.Hit);
            foreach (var hit in hits)
            {
                tiles.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return tiles.Distinct().Where(x => x.ShotResult == ShotResult.None).Select(x => x.Coordinates).ToList();
        }

        public List<Tile> GetNeighbors(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Tile> tiles = new List<Tile>();
            if (column > 1)
            {
                tiles.Add(Tiles.At(row, column - 1));
            }
            if (row > 1)
            {
                tiles.Add(Tiles.At(row - 1, column));
            }
            if (row < 10)
            {
                tiles.Add(Tiles.At(row + 1, column));
            }
            if (column < 10)
            {
                tiles.Add(Tiles.At(row, column + 1));
            }
            return tiles;
        }
    }
}