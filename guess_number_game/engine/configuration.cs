using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace guess_number_game.engine
{
    [Serializable]
    public class configuration
    {
        public static string path = Directory.GetCurrentDirectory() + "\\config.bin";
        public level_type level;
        public game_type type;

        private configuration()
        {
            level = level_type.easy;
            type  = game_type.computer_vs_user;
        }

        private static configuration _current;

        public static configuration current
        {
            get
            {
                if (_current == null)
                {
                    _current = (configuration) serializer.load(path);

                    if (_current == null)
                        _current = new configuration();
                }

                return _current;
            }
        }

        public void save()
        {
            serializer.save(path, this);
        }
    }
}
