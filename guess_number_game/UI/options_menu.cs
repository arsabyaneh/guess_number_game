using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.UI.Base;

namespace guess_number_game.UI
{
    public class options_menu : menu
    {
        private menu_item type;
        private menu_item level;
        private menu_item back;

        public options_menu()
        {
            title_text = "Options";

            type  = new menu_item("game type");
            level = new menu_item("game level");
            back  = new menu_item("<-");

            type.selected  += type_selected;
            level.selected += level_selected;
            back.selected  += back_selected;

            items.AddRange(new[] { type, level, back });

            menu_location = new drawing.location(Console.WindowWidth / 2 - padding / 2, Console.WindowHeight / 2 - items.Count);
            menu_size = new drawing.size(padding + 1, items.Count + 1);
        }

        private void type_selected(object sender, EventArgs e)
        {
            new game_type_menu().show();
        }

        private void level_selected(object sender, EventArgs e)
        {
            new game_level_menu().show();
        }
        
        private void back_selected(object sender, EventArgs e)
        {
            close(); 
        }
    }
}
