using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine.build
{
    public class computer_vs_user : builder
    {
        public override void initialize_first_player()
        {
            game_instance.first_player = new computer();
        }

        public override void initialize_second_player()
        {
            game_instance.second_player = new user();
        }
    }
}
