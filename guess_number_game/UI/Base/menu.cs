using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.UI.Base
{
    public class menu
    {
        public string title_text { get; set; }
        public point left_top_margin { get; set; }
        public List<menu_item> items { get; set; }

        private bool closed;
        private static int padding = 20;

        public menu()
        {
            items = new List<menu_item>();
        }

        public void show()
        {
            int selected_item_index = 0;

            closed = false;
            ConsoleKey key;

            while (!closed)
            {
                Console.CursorVisible = false;
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(title_text);
                Console.WriteLine("----------------------------");

                for (int i = 0; i < items.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = (i == selected_item_index) ? ConsoleColor.Blue : ConsoleColor.Black;

                    Console.Write("\t{0}", items[i].text);
                    for (int j = items[i].text.Length; j < padding; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected_item_index = (selected_item_index == 0) ? items.Count - 1 : selected_item_index - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selected_item_index = (selected_item_index == items.Count - 1) ? 0 : selected_item_index + 1;
                        break;

                    case ConsoleKey.Home:
                        selected_item_index = 0;
                        break;

                    case ConsoleKey.End:
                        selected_item_index = items.Count - 1;
                        break;

                    case ConsoleKey.Escape:
                        closed = true;
                        break;

                    default:
                        items[selected_item_index].process_key(key);
                        break;
                }
            }
        }

        public void close()
        {
            closed = true;
        }
    }
}
