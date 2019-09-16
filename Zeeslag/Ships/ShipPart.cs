using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeeslag.Ships
{
    public class ShipPart
    {
        public Image Image { get; set; }
        public bool Destroyed { get; set; }

        public ShipPart(Image image)
        {
            Image = image;
            Destroyed = false;
        }
    }
}
