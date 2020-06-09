using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guess_number_game.UI.drawing
{
    public class location
    {
        public int left { get; set; }
        public int top { get; set; }

        public location() : this(0, 0)
        {

        }

        public location(int left, int top)
        {
            this.left = left;
            this.top  = top;
        }
    }
}
