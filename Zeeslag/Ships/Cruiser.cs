using System.Collections.Generic;

namespace Zeeslag.Ships
{
    internal class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Parts = new List<ShipPart>()
            {
                new ShipPart(Images.Cruiser_1),
                new ShipPart(Images.Cruiser_2),
                new ShipPart(Images.Cruiser_3)
            };
            TileOccupation = TileOccupation.Cruiser;
        }
    }
}