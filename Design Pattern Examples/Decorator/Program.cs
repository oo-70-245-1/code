using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace decroatorexample
{
    public interface Vechile
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }

    public class HondaCity : Vechile
    {
        public string Make
        {
            get { return "HondaCity"; }
        }

        public string Model
        {
            get { return "CNG"; }
        }

        public double Price
        {
            get { return 10000; }
        }
    }

    public abstract class VechileDecrorator : Vechile
    {
        private Vechile _vechile;

        public VechileDecrorator(Vechile veh)
        {
            _vechile = veh;
        }

        public string Make
        {
            get { return _vechile.Make; }
        }

        public string Model
        {
            get { return _vechile.Model; }
        }

        public double Price
        {
            get { return _vechile.Price; }
        }
    }

    public class SpecialOffer : VechileDecrorator
    {
        public SpecialOffer(Vechile vechile)
            : base(vechile)
        {

        }

        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public double Price
        {
            get
            {
                double price = base.Price;
                double percentage = DiscountPercentage / (double)100;
                double res = Math.Round((price * percentage), 2);
                return price - res;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HondaCity car = new HondaCity();

            Console.WriteLine("Honday City base price : {0}", car.Price);

            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Console.WriteLine(" Special offer price {0} ", offer.Price);
        }
    }
}
