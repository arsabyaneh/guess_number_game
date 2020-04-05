using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine.build
{
    public static class director
    {
        public static game construct(game_type type)
        {
            builder build = null;

            switch (type)
            {
                case game_type.computer_vs_user:
                    build = new computer_vs_user();
                    break;

                case game_type.user_vs_computer:
                    build = new user_vs_computer();
                    break;

                case game_type.computer_vs_computer:
                    build = new computer_vs_computer();
                    break;

                case game_type.user_vs_user:
                    build = new user_vs_user();
                    break;
            }

            build.initialize();
            build.initialize_first_player();
            build.initialize_second_player();

            return build.game_instance;
        }
    }
}
