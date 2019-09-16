using System.Collections.Generic;

namespace Zeeslag.Boards
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

        public Board()
        {
            Tiles = new List<Tile>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}