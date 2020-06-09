using guess_number_game.UI;
using System;

namespace guess_number_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Guess Number Game";
            new main_menu().show();
        }
    }
}
