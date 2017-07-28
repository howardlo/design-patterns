using System;

namespace decorator_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Beverage beverage = new Expresso();
            Console.WriteLine($"{beverage.GetDescription()} | cost: {beverage.cost():f2}");

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            // beverage2 = new Mocha(beverage2);
            // beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.GetDescription()} | cost: {beverage2.cost():f2}");
            Console.WriteLine($"{beverage2.GetType().Name}");

            Console.ReadKey();
        }
    }

    public abstract class Beverage
    {
        internal string description = "unknown beverage";
        public abstract string GetDescription();
        public abstract double cost();
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            this.description = "House Blend";
        }
        public override string GetDescription() { return description; }

        public override double cost()
        {
            return 1.00;
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            this.description = "Dark Roast";
        }

        public override string GetDescription() { return description; }

        public override double cost()
        {
            return 0.99;
        }
    }

    public class Expresso : Beverage
    {
        public Expresso()
        {
            this.description = "Expresso";
        }
        public override string GetDescription() { return description; }

        public override double cost()
        {
            return 1.00;
        }
    }

    public class Decaf : Beverage
    {
        public Decaf()
        {
            this.description = "Decaf";
        }
        public override string GetDescription() { return description; }

        public override double cost()
        {
            return 1.00;
        }
    }

    public abstract class CondimentDecorator: Beverage
    {

        public override double cost()
        {
            return 1.00;
        }
    }

    public class Milk: CondimentDecorator
    {
        public Beverage beverage;
        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Milk";
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + " " + this.description;
        }
        public override double cost()
        {
            return 0.10;
        }
    }

    public class Mocha: CondimentDecorator
    {
        public Beverage beverage;
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Mocha";
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
        }
        public override double cost()
        {
            return beverage.cost() + 0.20;
        }
    }

    public class Soy: CondimentDecorator
    {
        public Beverage beverage;
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Soy";
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + " " + this.description;
        }
        public override double cost()
        {
            return 0.12;
        }
    }

    public class Whip: CondimentDecorator
    {
        public Beverage beverage;
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Whip";

        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }
        public override double cost()
        {
            return beverage.cost() + 0.20;
        }
    }

}