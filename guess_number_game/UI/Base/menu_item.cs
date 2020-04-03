using System;
using System.Collections.Generic;
using System.Text;

namespace guess_number_game.UI.Base
{
    public class menu_item
    {
        public string text { get; set; }

        public menu_item() : this(string.Empty)
        {

        }
        public menu_item(string text)
        {
            this.text = text;
        }

        public event EventHandler selected;
        protected virtual void Onselected(EventArgs e)
        {
            if (selected == null) return;

            selected(this, e);
        }

        public void process_key(ConsoleKey key)
        {
            if (key != ConsoleKey.Enter) return;
            Onselected(EventArgs.Empty);
        }
    }
}
