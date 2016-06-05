using System;
using System.Threading;
using System.Collections.Generic;


namespace Builder
{
    public interface IIngredient
    {
        string GetName();
    }

    public interface IPizzaBuilder
    {
        void MakePizzaDough();
        void AddIngredients();
        void PutInTheOven();
        void ShowIngredients();

        Pizza Pizza { get; }
    }

    public class Pizza
    {
        private string _name;
        public List<IIngredient> Ingredients;

        public Pizza(string name)
        {
            Ingredients = new List<IIngredient>();
            _name = name;
        }
        public string Name { get { return _name; } }
    }

    public class Ananas : IIngredient
    {
        public string GetName()
        {
            return "Anannas";
        }
    }

    public class Cheese : IIngredient
    {
        public string GetName()
        {
            return "Cheese";
        }
    }

    public class Banana : IIngredient
    {
        public string GetName()
        {
            return "Banana";
        }
    }

    public class Buttonmushrooms : IIngredient
    {
        public string GetName()
        {
            return "Button mushrooms";
        }
    }

    public class Peperoni : IIngredient
    {
        public string GetName()
        {
            return "Peperoni";
        }
    }

    public class Onion : IIngredient
    {
        public string GetName()
        {
            return "Onion";
        }
    }


    public class Oliveoli : IIngredient
    {
        public string GetName()
        {
            return "Olive oil";
        }
    }



    public class HawaiPizzaBuilder : IPizzaBuilder
    {
        public Pizza _pizza { get; }
        public Pizza Pizza { get { return _pizza; } }

        public HawaiPizzaBuilder()
        {
            _pizza = new Pizza("\n---Pizza Hawai---");
        }

        public void MakePizzaDough()
        {
            Console.WriteLine("Hawai pizza douh has been made.");
        }


        public void AddIngredients()
        {
            _pizza.Ingredients.Add(new Ananas());
            _pizza.Ingredients.Add(new Cheese());
            _pizza.Ingredients.Add(new Banana());
            _pizza.Ingredients.Add(new Buttonmushrooms());
            Console.WriteLine("Ingredients have been added.");
        }

        public void ShowIngredients()
        {
            foreach (IIngredient ingredient in _pizza.Ingredients)
            {
                Console.WriteLine(ingredient.GetName());
            }
        }

        public void PutInTheOven()
        {
            Console.WriteLine("Pizza is in the oven...");
            Thread.Sleep(3000);
            Console.WriteLine("Pizza is ready.");
        }
    }

    public class PeperoniPizzaBuilder : IPizzaBuilder
    {
        public Pizza _pizza { get; }
        public Pizza Pizza { get { return _pizza; } }

        public PeperoniPizzaBuilder()
        {
            _pizza = new Pizza("\n---Pizza Peperoni---");
        }

        public void MakePizzaDough()
        {
            Console.WriteLine("Peperoni pizza douh has been made.");
        }


        public void AddIngredients()
        {
            _pizza.Ingredients.Add(new Peperoni());
            _pizza.Ingredients.Add(new Cheese());
            _pizza.Ingredients.Add(new Oliveoli());
            Console.WriteLine("Ingredients have been added.");
        }

        public void ShowIngredients()
        {
            foreach (IIngredient ingredient in _pizza.Ingredients)
            {
                Console.WriteLine(ingredient.GetName());
            }
        }

        public void PutInTheOven()
        {
            Console.WriteLine("Pizza is in the oven...");
            Thread.Sleep(5000);
            Console.WriteLine("Peperoni pizza is ready.");

        }

    }

    public class PizzaDirector
    {
        public void MakePizza(IPizzaBuilder pizzaBuilder)
        {
            pizzaBuilder.MakePizzaDough();
            pizzaBuilder.AddIngredients();
            pizzaBuilder.PutInTheOven();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PizzaDirector pizzaDirector = new PizzaDirector();
            IPizzaBuilder peperoniPizzaBuilder = new PeperoniPizzaBuilder();
            IPizzaBuilder hawaiPizzaBuilder = new HawaiPizzaBuilder();

            pizzaDirector.MakePizza(hawaiPizzaBuilder);
            Console.WriteLine(hawaiPizzaBuilder.Pizza.Name + "\n[RECIPIE]:");
            hawaiPizzaBuilder.ShowIngredients();
            Console.WriteLine();
            pizzaDirector.MakePizza(peperoniPizzaBuilder);
            Console.WriteLine(peperoniPizzaBuilder.Pizza.Name + "\n[RECIPIE]:");
            peperoniPizzaBuilder.ShowIngredients();

            Console.ReadKey();
        }
    }
}
