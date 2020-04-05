using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.engine
{
    public class user : player
    {
        public string name;

        public override void get_ready()
        {
            Console.WriteLine("choose a number between 0 and 1000; press any key when you are ready ");
            Console.ReadKey(true);
        }

        public override int guess(result last_result)
        {
            int number;

            do
            {
                do
                {
                    try
                    {
                        Console.Write("geuss a number: ");
                        number = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("enter an integer number: ");
                    }
                } while (true);

                if (number <= 1000 && number >= 0)
                    break;
                else
                    Console.WriteLine("enter a nuumber between 0 and 1000");
            } while (true);

            return number;
        }

        public override result check(int guess_number)
        {
            Console.WriteLine("number {0} is {1}", guess_number, "equal (E), smaller than (S), larger than (L) your chosen number?");

            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.E:
                        return result.equal;
                    case ConsoleKey.S:
                        return result.smaller;
                    case ConsoleKey.L:
                        return result.larger;
                }
            } while (true);
        }
    }
}
