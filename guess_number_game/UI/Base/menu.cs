using guess_number_game.UI.drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.UI.Base
{
    public class menu
    {
        public string title_text { get; set; }
        public location menu_location { get; set; }
        public size menu_size { get; set; }
        public List<menu_item> items { get; set; }

        private bool closed;
        public static int padding = 25;

        public menu()
        {
            items = new List<menu_item>();
        }

        public void show()
        {
            int selected_item_index = 0;

            rectangle menu_rectangle = new rectangle()
            {
                location = menu_location,
                size = menu_size,
                color = ConsoleColor.Gray,
                border_color = ConsoleColor.DarkBlue
            };

            closed = false;
            ConsoleKey key;

            while (!closed)
            {
                Console.CursorVisible = false;
                Console.ResetColor();
                Console.Clear();

                show_header(menu_rectangle.location.left + 1, menu_rectangle.location.top - 1);

                menu_rectangle.draw();

                for (int i = 0; i < items.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = (i == selected_item_index) ? ConsoleColor.Blue : menu_rectangle.color;

                    Console.SetCursorPosition(menu_rectangle.location.left + 1, menu_rectangle.location.top + 1 + i);
                    Console.Write("   {0}", items[i].text);
                    for (int j = items[i].text.Length + 3; j < padding; j++)
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

        private void show_header(int left, int top)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("{0}", title_text);
        }

        public void close()
        {
            closed = true;
        }
    }
}
