using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guess_number_game.UI.drawing
{
    public class rectangle
    {
        public location location { get; set; }
        public size size { get; set; }
        public ConsoleColor color { get; set; }
        public ConsoleColor border_color { get; set; }

        private int left
        {
            get
            {
                return location.left;
            }
        }
        private int top
        {
            get
            {
                return location.top;
            }
        }
        private int width
        {
            get
            {
                return size.width;
            }
        }
        private int height
        {
            get
            {
                return size.height;
            }
        }
        private int right
        {
            get
            {
                return left + width;
            }
        }
        private int bottom
        {
            get
            {
                return top + height;
            }
        }

        public void draw()
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = border_color;

            // rectangle body
            for (int i = top + 1; i < bottom; i++)
                for (int j = left + 1; j < right; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }

            // left border
            for (int i = top; i <= bottom; i++)
            {
                Console.CursorLeft = left;
                Console.CursorTop  = i;
                Console.Write(i == top ? "┌" : (i == bottom ? "└" : "│"));
            }

            // right border
            for (int i = top; i <= bottom; i++)
            {
                Console.CursorLeft = right;
                Console.CursorTop  = i;
                Console.Write(i == top ? "┐" : (i == bottom ? "┘" : "│"));
            }

            // top border
            for (int i = left + 1; i < right; i++)
            {
                Console.CursorLeft = i;
                Console.CursorTop  = top;
                Console.Write("─");
            }

            // bottom border
            for (int i = left + 1; i < right; i++)
            {
                Console.CursorLeft = i;
                Console.CursorTop  = bottom;
                Console.Write("─");
            }
        }
    }
}
