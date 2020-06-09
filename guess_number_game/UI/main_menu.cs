using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.engine;
using guess_number_game.engine.build;
using guess_number_game.UI.Base;
using guess_number_game.UI.drawing;

namespace guess_number_game.UI
{
    public class main_menu : menu
    {
        private menu_item start;
        private menu_item options;
        private menu_item about;
        private menu_item exit;
        public main_menu()
        {
            title_text = "Guess Number Game";

            start   = new menu_item("start");
            options = new menu_item("options");
            about   = new menu_item("about");
            exit    = new menu_item("exit");

            start.selected   += start_selected;
            options.selected += options_selected;
            about.selected   += about_selected;
            exit.selected    += exit_selected;

            items.AddRange(new[] { start, options, about, exit });

            menu_location = new drawing.location(Console.WindowWidth / 2 - padding / 2, Console.WindowHeight / 2 - items.Count);
            menu_size = new drawing.size(padding + 1, items.Count + 1);
        }

        private void start_selected(object sender, EventArgs e)
        {
            ConsoleKey key;
            Console.ResetColor();
            Console.Clear();

            configuration.current.save();

            game run_game = director.construct(configuration.current.type);

            do
            {
                run_game.start();

                Console.WriteLine("do you want to play again? yes (Y), no (N): ");

                do
                {
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Y)
                        break;
                    else if (key == ConsoleKey.N)
                    {
                        close();
                        return;
                    }

                    Console.WriteLine("enter yes (Y), no (N): ");
                } while (true);

                Console.Clear();

            } while (true);
        }

        private void options_selected(object sender, EventArgs e)
        {
            new options_menu().show();
        }

        private void about_selected(object sender, EventArgs e)
        {
            Console.ResetColor();
            Console.Clear();
            rectangle about_rectangle = new rectangle()
            {
                location = new location(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 5),
                size = new size(30, 7),
                color = ConsoleColor.Gray,
                border_color = ConsoleColor.DarkBlue
            };
            about_rectangle.draw();

            Console.SetCursorPosition(about_rectangle.location.left + 7, about_rectangle.location.top + about_rectangle.size.height / 2 - 1);
            Console.WriteLine("Guess Number Game,");
            Console.CursorLeft = about_rectangle.location.left + 6;
            Console.WriteLine("All Rights Reserved.");
            Console.SetCursorPosition(about_rectangle.location.left + 5, about_rectangle.location.top + about_rectangle.size.height / 2 + 3);
            Console.WriteLine("press a key to go back");


            Console.ReadKey(true);
        }

        private void exit_selected(object sender, EventArgs e)
        {
            close();
        }
    }
}
