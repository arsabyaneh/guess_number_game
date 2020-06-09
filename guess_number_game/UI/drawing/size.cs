using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guess_number_game.UI.drawing
{
    public class size
    {
        public int width { get; set; }
        public int height { get; set; }

        public size() : this(0, 0)
        {

        }

        public size(int width, int height)
        {
            this.width  = width;
            this.height = height;
        }
    }
}
