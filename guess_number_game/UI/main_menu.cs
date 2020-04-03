﻿using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.UI.Base;

namespace guess_number_game.UI
{
    public class main_menu : menu
    {
        private menu_item start;
        private menu_item options;
        private menu_item type;
        private menu_item help;
        private menu_item about;
        private menu_item exit;
        public main_menu()
        {
            left_top_margin = new point(0, 0);

            title_text = "Guess Number Game";

            start   = new menu_item("start");
            options = new menu_item("options");
            type    = new menu_item("type");
            help    = new menu_item("about");
            exit    = new menu_item("exit");

            start.selected   += start_selected;
            options.selected += options_selected;
            type.selected    += type_selected;
            help.selected    += help_selected;
            exit.selected    += exit_selected;

            items.AddRange(new[] { start, options, type, help, exit });
        }

        private void start_selected(object sender, EventArgs e)
        {

        }

        private void options_selected(object sender, EventArgs e)
        {
            new options_menu().show();
        }

        private void type_selected(object sender, EventArgs e)
        {
            new game_type_menu().show();
        }

        private void help_selected(object sender, EventArgs e)
        {

        }

        private void exit_selected(object sender, EventArgs e)
        {
            close();
        }
    }
}