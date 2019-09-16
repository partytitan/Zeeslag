using System.Collections.Generic;

namespace Zeeslag.Ships
{
    internal class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Parts = new List<ShipPart>()
            {
                new ShipPart(Images.Battleship_1),
                new ShipPart(Images.Battleship_2),
                new ShipPart(Images.Battleship_3),
                new ShipPart(Images.Battleship_4)
            };
            TileOccupation = TileOccupation.Battleship;
        }
    }
}