using System.Collections.Generic;

namespace Zeeslag.Ships
{
    internal class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Parts = new List<ShipPart>()
            {
                new ShipPart(Images.Carrier_1),
                new ShipPart(Images.Carrier_2),
                new ShipPart(Images.Carrier_3),
                new ShipPart(Images.Carrier_4),
                new ShipPart(Images.Carrier_5)
            };
            TileOccupation = TileOccupation.Carrier;
        }
    }
}