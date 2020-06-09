using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.engine;
using guess_number_game.engine.build;
using guess_number_game.UI.Base;

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

        }

        private void exit_selected(object sender, EventArgs e)
        {
            close();
        }
    }
}
