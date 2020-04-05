using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine
{
    public class computer : player
    {
        private int number;
        private int lower_bound;
        private int upper_bound;

        public computer()
        {
            lower_bound = 0;
            upper_bound = 1000;
        }

        public override void get_ready()
        {
            Console.WriteLine("computer is choosing a number ");
            number = new Random().Next(0, 1000);
            System.Threading.Thread.Sleep(1000);
        }

        public override int guess(result last_result)
        {
            switch (last_result)
            {
                case result.smaller:
                    upper_bound = number;
                    break;
                case result.larger:
                    lower_bound = number;
                    break;
            }

            number = new Random().Next(lower_bound, upper_bound);

            return number;
        }

        public override result check(int guess_number)
        {
            if (number == guess_number)
                return result.equal;
            else if (number < guess_number)
                return result.smaller;
            else
                return result.larger;
        }
    }
}
