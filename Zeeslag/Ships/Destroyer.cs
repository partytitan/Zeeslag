using System.Collections.Generic;

namespace Zeeslag.Ships
{
    internal class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Parts = new List<ShipPart>()
            {
                new ShipPart(Images.Destroyer_1),
                new ShipPart(Images.Destroyer_2),
                new ShipPart(Images.Destroyer_3)
            };
            TileOccupation = TileOccupation.Destroyer;
        }
    }
}