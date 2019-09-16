using System.Collections.Generic;

namespace Zeeslag.Ships
{
    public class Ship
    {
        public string Name { get; set; }
        public int Hits { get; set; }
        public TileOccupation TileOccupation { get; set; }
        public List<ShipPart> Parts { get; set; }

        public bool IsDestoyed
        {
            get { return Parts.Count <= Hits; }
        }
    }
}