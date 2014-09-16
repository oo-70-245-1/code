using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pizzaexample
{
    class Program
    {
        public class Pizza
        {
            public string dough = "";
            public string sauce = "";
            public string topping = "";
        }
        abstract class PizzaBuilder
        {
            protected Pizza pizza;

            public Pizza GetPizza()
            {
                return pizza;
            }

            public void CreateNewPizzaProduct()
            {
                pizza = new Pizza();
            }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.dough = "cross";
            }

            public override void BuildSauce()
            {
                pizza.sauce = "mild";
            }

            public override void BuildTopping()
            {
                pizza.topping = "ham+pineapple";
            }
        }

        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.dough = "pan baked";
            }

            public override void BuildSauce()
            {
                pizza.sauce = "hot";
            }

            public override void BuildTopping()
            {
                pizza.topping = "pepperoni + salami";
            }
        }

        class Cook
        {
            private PizzaBuilder _pizzaBuilder;

            public void SetPizzaBuilder(PizzaBuilder pb)
            {
                _pizzaBuilder = pb;
            }

            public Pizza GetPizza()
            {
                return _pizzaBuilder.GetPizza();
            }

            public void ConstructPizza()
            {
                _pizzaBuilder.CreateNewPizzaProduct();
                _pizzaBuilder.BuildDough();
                _pizzaBuilder.BuildSauce();
                _pizzaBuilder.BuildTopping();
            }
        }

        static void Main(string[] args)
        {
            PizzaBuilder hawaiianpizzabuilder = new HawaiianPizzaBuilder();
            Cook cook = new Cook();
            cook.SetPizzaBuilder(hawaiianpizzabuilder);
            cook.ConstructPizza();
            Pizza hawaiian = cook.GetPizza();
        }
    }
}
