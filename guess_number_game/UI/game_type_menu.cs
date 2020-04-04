using System;
using System.Collections.Generic;
using System.Text;
using guess_number_game.engine;
using guess_number_game.UI.Base;

namespace guess_number_game.UI
{
    public class game_type_menu : menu
    {
        private menu_item computer_vs_user;
        private menu_item user_vs_computer;
        private menu_item computer_vs_computer;
        private menu_item user_vs_user;
        private menu_item back;

        public game_type_menu()
        {
            left_top_margin = new point(0, 0);

            title_text = "select the game type";

            computer_vs_user     = new menu_item("computer vs. user");
            user_vs_computer     = new menu_item("user vs. computer");
            computer_vs_computer = new menu_item("computer vs. computer");
            user_vs_user         = new menu_item("user vs. user");
            back                 = new menu_item("<-");

            computer_vs_user.selected     += computer_vs_user_selected;
            user_vs_computer.selected     += user_vs_computer_selected;
            computer_vs_computer.selected += computer_vs_computer_selected;
            user_vs_user.selected         += user_vs_user_selected;
            back.selected                 += back_selected;

            items.AddRange(new[] { computer_vs_user, user_vs_computer, computer_vs_computer, user_vs_user, back });
        }

        private void computer_vs_user_selected(object sender, EventArgs e)
        {
            configuration.current.type = game_type.computer_vs_user;
            close();
        }

        private void user_vs_computer_selected(object sender, EventArgs e)
        {
            configuration.current.type = game_type.user_vs_computer;
            close();
        }

        private void computer_vs_computer_selected(object sender, EventArgs e)
        {
            configuration.current.type = game_type.computer_vs_computer;
            close();
        }

        private void user_vs_user_selected(object sender, EventArgs e)
        {
            configuration.current.type = game_type.user_vs_user;
            close();
        }

        private void back_selected(object sender, EventArgs e)
        {
            close();
        }
    }
}
