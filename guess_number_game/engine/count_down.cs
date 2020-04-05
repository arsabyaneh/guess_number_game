using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace guess_number_game.engine
{
    public class count_down
    {
        private int top;
        private int left;
        ConsoleColor fore_color;
        ConsoleColor back_color;

        private int _seconds;
        public int seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < 0)
                    throw new Exception("invalid value!");

                _seconds = value;
            }
        }

        private Thread thread;

        public event EventHandler finished;
        protected virtual void Onfinished(EventArgs e)
        {
            if (this.finished == null)
                return;

            finished(this, e);
        }

        public count_down()
        {
            top = 0;
            left = Console.WindowWidth - 5;
            fore_color = ConsoleColor.White;
            back_color = ConsoleColor.DarkRed;
        }

        public void start()
        {
            thread = new Thread(run);
            thread.Start();
        }

        public void stop()
        {
            if (thread == null || !thread.IsAlive)
                return;

            thread.Abort();
        }

        private void run()
        {
            ConsoleColor saved_fore_color, saved_back_color;
            int x, y;
            int counter = seconds;

            while (counter >= 0)
            {
                saved_fore_color = Console.ForegroundColor;
                saved_back_color = Console.BackgroundColor;
                x = Console.CursorLeft;
                y = Console.CursorTop;

                Console.ForegroundColor = fore_color;
                Console.BackgroundColor = back_color;
                Console.SetCursorPosition(left, top);
                Console.Write(" {0:d3} ", counter);

                Console.ForegroundColor = saved_fore_color;
                Console.BackgroundColor = saved_back_color;
                Console.SetCursorPosition(x, y);
                counter--;
                Thread.Sleep(1000);
            }

            Onfinished(EventArgs.Empty);
        }
    }
}
