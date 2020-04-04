using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.engine;
using guess_number_game.UI.Base;

namespace guess_number_game.UI
{
    public class options_menu : menu
    {
        private menu_item easy;
        private menu_item medium;
        private menu_item hard;
        private menu_item back;

        public options_menu()
        {
            left_top_margin = new point(0, 0);

            title_text = "options";

            easy   = new menu_item("easy");
            medium = new menu_item("medium");
            hard   = new menu_item("hard");
            back   = new menu_item("<-");

            easy.selected   += easy_selected;
            medium.selected += medium_selected;
            hard.selected   += hard_selected;
            back.selected   += back_selected;

            items.AddRange(new[] { easy, medium, hard, back });
        }

        private void easy_selected(object sender, EventArgs e)
        {
            configuration.current.level = level_type.easy;
            close();
        }

        private void medium_selected(object sender, EventArgs e)
        {
            configuration.current.level = level_type.medium;
            close();
        }
        private void hard_selected(object sender, EventArgs e)
        {
            configuration.current.level = level_type.hard;
            close();
        }
        private void back_selected(object sender, EventArgs e)
        {
            close(); 
        }
    }
}
