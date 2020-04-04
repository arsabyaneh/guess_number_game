using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace guess_number_game.engine
{
    public static class serializer
    {
        public static void save(string path, object obj)
        {
            FileStream stream = new FileStream(path,
                File.Exists(path) ? FileMode.Truncate : FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None);

            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, obj);
            stream.Close();
        }

        public static object load(string path)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                object obj = new BinaryFormatter().Deserialize(stream);
                stream.Close();

                return obj;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
    }
}
