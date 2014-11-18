using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace object1
{
    class variant
    {
        protected enum V_TYPE
        {
            INT,
            FLOAT,
            STRING,
            DOUBLE,
            OBJECT,
            NULL
        };

        protected V_TYPE TYPE;
        protected object data;

        protected void setData(object o, V_TYPE t)
        {
            TYPE = t;
            data = o;
        }

        public variant(int val)
        {
            setData(val, V_TYPE.INT);
        }

        public variant(float f)
        {
            setData(f, V_TYPE.FLOAT);
        }

        public variant(string s)
        {
            setData(s, V_TYPE.STRING);
        }

        public variant(double d)
        {
            setData(d, V_TYPE.DOUBLE);
        }

        public variant(variant v)
        {
            setData(v.data, v.TYPE);
        }

        public variant()
        {
            setData(null, V_TYPE.NULL);
        }

        public static implicit operator variant(int i)
        {
            return new variant(i);
        }

        public static implicit operator variant(float f)
        {
            return new variant(f);
        }

        public static implicit operator variant(double d)
        {
            return new variant(d);
        }

        public static implicit operator variant(string s)
        {
            return new variant(s);
        }

        public static implicit operator int(variant v)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                case V_TYPE.FLOAT:
                case V_TYPE.DOUBLE:
                case V_TYPE.OBJECT:
                    return (int)v.data;
                case V_TYPE.STRING:
                    return int.Parse((string)v.data);
                default:
                    return 0;
            }
        }

        public static implicit operator float(variant v)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                case V_TYPE.FLOAT:
                case V_TYPE.DOUBLE:
                case V_TYPE.OBJECT:
                    return (float)v.data;
                case V_TYPE.STRING:
                    return float.Parse((string)v.data);
                default:
                    return 0;
            }
        }

        public static implicit operator double(variant v)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                case V_TYPE.FLOAT:
                case V_TYPE.DOUBLE:
                case V_TYPE.OBJECT:
                    return (double)v.data;
                case V_TYPE.STRING:
                    return double.Parse((string)v.data);
                default:
                    return 0;
            }
        }

        public static implicit operator string(variant v)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                    return ((int)v.data).ToString();
                case V_TYPE.DOUBLE:
                    return ((double)v.data).ToString();
                case V_TYPE.FLOAT:
                    return ((float)v.data).ToString();
                case V_TYPE.OBJECT:
                    return ((object)v.data).ToString();
                case V_TYPE.STRING:
                    return (string)v.data;
                default:
                    return "";
            }
        }

        public static variant operator +(variant v, int i)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                    return new variant((int)v.data + i);
                case V_TYPE.FLOAT:
                    return new variant((float)v.data + i);
                case V_TYPE.DOUBLE:
                    return new variant((double)v.data + i);
                case V_TYPE.STRING:
                    return new variant((string)v.data + i.ToString());
                default:
                    return new variant();
            }
        }

        public static variant operator +(variant v, float i)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                    return new variant((int)v.data + i);
                case V_TYPE.FLOAT:
                    return new variant((float)v.data + i);
                case V_TYPE.DOUBLE:
                    return new variant((double)v.data + i);
                case V_TYPE.STRING:
                    return new variant((string)v.data + i.ToString());
                default:
                    return new variant();
            }
        }

        public static variant operator +(variant v, double i)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                    return new variant((int)v.data + i);
                case V_TYPE.FLOAT:
                    return new variant((float)v.data + i);
                case V_TYPE.DOUBLE:
                    return new variant((double)v.data + i);
                case V_TYPE.STRING:
                    return new variant((string)v.data + i.ToString());
                default:
                    return new variant();
            }
        }

        public static variant operator +(variant v, string i)
        {
            switch (v.TYPE)
            {
                case V_TYPE.INT:
                    return new variant((int)v.data + int.Parse(i));
                case V_TYPE.FLOAT:
                    return new variant((float)v.data + float.Parse(i));
                case V_TYPE.DOUBLE:
                    return new variant((double)v.data + double.Parse(i));
                case V_TYPE.STRING:
                    return new variant((string)v.data + i);
                default:
                    return new variant();
            }
        }

        public override string ToString()
        {
            switch (TYPE)
            {
                case V_TYPE.INT:
                case V_TYPE.DOUBLE:
                case V_TYPE.FLOAT:
                case V_TYPE.STRING:
                    return (string)this;
                default:
                    return "";
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            variant v = 5;
            Console.WriteLine(v.ToString());
            int x = v;
            Console.WriteLine(x);
            v += 10;
            Console.WriteLine(v.ToString());
            v += "10";
            Console.WriteLine(v.ToString());
            string s = v;
            Console.WriteLine(s);

            x = 20;
            v = x;
            s = v;
            x = v;
            Console.WriteLine("{0} - {1} - {2}", x, v, s);

            /*object var1, var2, var3;
            var1 = 4;
            var2 = 5;
            var3 = var1 + var2;*/

        }
    }
}
