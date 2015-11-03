using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace facadeexample
{
    public class CarModel
    {
        public void SetModel()
        {
            Console.WriteLine("CarModel - SetModel");
        }
    }

    public class CarEngine
    {
        public void SetEngine()
        {
            Console.WriteLine("CarEngine - SetEngine");
        }
    }

    public class CarBody
    {
        public void SetBody()
        {
            Console.WriteLine("CarBody - SetBody");
        }
    }

    public class CarAccessories
    {
        public void SetAccessories()
        {
            Console.WriteLine("CarAccessories - SetAccessories");
        }
    }

    public class CarFacade
    {
        CarModel model;
        CarEngine engine;
        CarBody body;
        CarAccessories accessories;

        public CarFacade()
        {
            model = new CarModel();
            engine = new CarEngine();
            body = new CarBody();
            accessories = new CarAccessories();
        }

        public void CreateCompleteCar()
        {
            Console.WriteLine("**** Creating a Car ****");
            model.SetModel();
            engine.SetEngine();
            body.SetBody();
            accessories.SetAccessories();

            Console.WriteLine("*** Car creation complete ***");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarFacade facade = new CarFacade();

            facade.CreateCompleteCar();


        }
    }
}

