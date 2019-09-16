using System.Collections.Generic;
using System.Linq;
using Zeeslag.Boards;

namespace Zeeslag.Extentions
{
    public static class TileHelpers
    {
        public static List<Tile> Range(this List<Tile> tiles, int startRow, int startColumn, int endRow, int endColumn)
        {
            return tiles.Where(x => x.Coordinates.Row >= startRow
                                        && x.Coordinates.Column >= startColumn
                                        && x.Coordinates.Row <= endRow
                                        && x.Coordinates.Column <= endColumn).ToList();
        }

        public static Tile At(this List<Tile> tiles, int row, int column)
        {
            return tiles.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }
    }
}