using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace guess_number_game.engine
{
    public class game
    {
        public player first_player;
        public player second_player;

        public void start()
        {
            bool finished = false;

            first_player.get_ready();

            count_down counter = new count_down();
            counter.seconds = (int) configuration.current.level;
            counter.finished += (s, e) => finished = true;

            Thread game_thread = new Thread(run_game);

            // there is potential of race condtion in writing to console
            counter.start();
            game_thread.Start();

            while (!finished && game_thread.IsAlive) ;

            Console.WriteLine();

            if (finished)
            {
                if (game_thread.IsAlive)
                    game_thread.Abort();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("first player won!");
            }
            else
            {
                counter.stop();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("second player won!");
            }

            Console.ResetColor();
        }

        public void run_game()
        {
            result last_result = result.none;
            int number;

            do
            {
                number = second_player.guess(last_result);
                last_result = first_player.check(number);

                if (last_result == result.smaller)
                    Console.WriteLine("enter a smaller number.");
                else if (last_result == result.larger)
                    Console.WriteLine("enter a larger number");
                else
                    // result.equal
                    return;

            } while (true);
        }
    }
}
