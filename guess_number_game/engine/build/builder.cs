using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine.build
{
    public abstract class builder
    {
        public game game_instance;

        public void initialize()
        {
            game_instance = new game();
        }

        public abstract void initialize_first_player();
        public abstract void initialize_second_player();
    }
}
