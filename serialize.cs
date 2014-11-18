using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace serialize
{
    public class serialize<T> where T : new()
    {

        public static List<T> createList(string file)
        {
            List<T> ret = new List<T>();
            Dictionary<string, string> vals = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(file);
            string[] header = lines[0].Split(',');
            foreach (string line in lines.Skip(1))
            {
                string[] data = line.Split(',');
                for (int i = 0; i < header.Count(); i++)
                    vals[header[i]] = data[i];
                ret.Add(createFromDict(vals));
            }
            return ret;
        }

        public static T create(string file)
        {
            Dictionary<string, string> vals = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(file);
            string[] header = lines[0].Split(',');
            string[] data = lines[1].Split(',');
            for (int i = 0; i < header.Count(); i++)
                vals[header[i]] = data[i];

            return createFromDict(vals);

        }

        public static string dump(T obj)
        {
            Dictionary<variant, variant> res = new Dictionary<variant, variant>();
            string retstring = "";
            foreach (FieldInfo f in obj.GetType().GetFields())
            {
                res[f.Name] = (variant)f.GetValue(obj);
            }

            foreach (variant v in res.Keys)
            {
                retstring += (string)v + ",";
            }

            retstring = retstring.Trim(',');

            retstring += "\n";

            foreach (variant v in res.Values)
            {
                retstring += (string)v + ",";
            }

            return retstring.Trim(',') + "\n";
        }

        public static T createFromDict(Dictionary<string, string> vals)
        {
            T obj = new T();
            foreach (KeyValuePair<string, string> kv in vals)
            {
                obj.GetType().GetField(kv.Key).SetValue(obj, (variant)kv.Value);
            }
            return obj;
        }
    }
    class User
    {
        public variant id;
        public variant name;
        public variant username;

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", id, name, username);
        }

        public static User CreateFromFile(string file)
        {
            User u = new User();
            string[] col = File.ReadAllText(file).Split(',');
            u.id = col[0];
            u.name = col[1];
            u.username = col[2];
            return u;
        }

        public static User CreateFromFile2(string file)
        {
            User u = new User();
            string[] col = File.ReadAllText(file).Split(',');
            int i = 0;
            foreach (FieldInfo f in u.GetType().GetFields())
            {
                f.SetValue(u, (variant)col[i]);
                i++;
            }
            return u;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            u.id = 1;
            u.name = "Nate Adams";
            u.username = "adamsna";
            Console.WriteLine(u);

            User u2 = new User();
            string[] col = File.ReadAllText("c:/temp/user.txt").Split(',');
            u2.id = col[0];
            u2.name = col[1];
            u2.username = col[2];
            Console.WriteLine(u2);

            User u3 = User.CreateFromFile("c:/temp/user2.txt");
            Console.WriteLine(u3);

            User u4 = User.CreateFromFile2("c:/temp/user3.txt");
            Console.WriteLine(u4);

            User u5 = serialize<User>.create("c:/temp/user4.txt");
            Console.WriteLine(u5);

            Console.WriteLine(serialize<User>.dump(u5));

            List<User> users = serialize<User>.createList("c:/temp/user5.txt");
            foreach (User usr in users)
                Console.WriteLine(usr);
        }
    }
}
