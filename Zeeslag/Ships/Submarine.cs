using System.Collections.Generic;

namespace Zeeslag.Ships
{
    internal class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Parts = new List<ShipPart>()
            {
                new ShipPart(Images.Submarine_1),
                new ShipPart(Images.Submarine_2)
            };
            TileOccupation = TileOccupation.Submarine;
        }
    }
}