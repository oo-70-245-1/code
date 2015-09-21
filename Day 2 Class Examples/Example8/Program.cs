using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace classex3
{
    public class BaseClass
    {
        public virtual void DoWork()
        {
            Console.WriteLine("BaseWork");
        }
        public int WorkField;
        public int getWorkProperty() { return 0; }
        public void setWorkProperty(int value) { this.WorkField = value; }
        public int WorkProperty
        {
            get { return 0; }
            set { this.WorkField = value; }
        }
    }

    public class DerivedClass : BaseClass
    {
        public override void DoWork() { Console.WriteLine("DerivedWork"); }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass B = new DerivedClass();
            BaseClass A = (BaseClass)B;
            B.DoWork();
            A.DoWork();
            //A.WorkProperty = 20;
            //int x = A.WorkProperty;
        }
    }
}
