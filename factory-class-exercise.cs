using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace factory2
{
    interface IButton { }

    class WinButton : IButton { }
    class OSXButton : IButton { }

    interface IGUIFactory 
    {
        IButton CreateButton();
    }

    class WinFactory : IGUIFactory
    {

        public IButton CreateButton()
        {
            return new WinButton();
        }
    }

    class OSXFactory : IGUIFactory
    {

        public IButton CreateButton()
        {
            return new OSXButton();
        }
    }

    class Program
    {
        public static void App(IGUIFactory factory)
        {
            IButton btn = factory.CreateButton();
        }
        static void Main(string[] args)
        {
            App(new OSXFactory());
        }
    }
}
