using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine
{
    public abstract class player
    {
        public abstract void get_ready();
        public abstract int guess(result last_result);
        public abstract result check(int guess_number);
    }
}
