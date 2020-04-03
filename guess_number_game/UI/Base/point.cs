using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.UI.Base
{
    public class point
    {
        public int x;
        public int y;

        public point() : this(0, 0)
        {

        }

        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
