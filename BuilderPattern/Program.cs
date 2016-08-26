using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------Club Sandwich------------------------------------");
            var sandwichMaker = new SandwichMaker(new ClubSandwichBuilder());
            Sandwich clubSandwich = sandwichMaker.MakeSandwich();
            clubSandwich.Display();

            Console.WriteLine("---------------------------Standard Sandwich------------------------------------");
             sandwichMaker = new SandwichMaker(new StandardSandwichBuilder());
            Sandwich standardSandwich = sandwichMaker.MakeSandwich();
            standardSandwich.Display();

            Console.ReadLine();

        }

    }

    public class SandwichMaker
    {
        SandwichBuilder _SandwichBuilder;
        public SandwichMaker(SandwichBuilder SandwichBuilder)
        {
            _SandwichBuilder = SandwichBuilder;
        }
        public Sandwich MakeSandwich()

        {
            _SandwichBuilder.CreateSandwich();
            return _SandwichBuilder.GetSandwich();

        }

    }
    public abstract class SandwichBuilder
    {

        protected Sandwich _Sandwich;
        public abstract void CreateSandwich();
      
        public  Sandwich GetSandwich()
        {
            return _Sandwich;
        }
    }
    public class ClubSandwichBuilder : SandwichBuilder
    {
        public override void CreateSandwich()
        {
            _Sandwich = new Sandwich();
            _Sandwich.BreadType = Bread.Brown;
            _Sandwich.CheeseType = Cheese.Mayo;
            _Sandwich.IsToasted = true;
            _Sandwich.Vegetables.Add("Onion");
            _Sandwich.Vegetables.Add("Lettuce");
        }

       
    }
    public class StandardSandwichBuilder : SandwichBuilder
    {

        public override void CreateSandwich()
        {
            _Sandwich = new Sandwich();
            _Sandwich.BreadType = Bread.White;
            _Sandwich.CheeseType = Cheese.Cheddar;
            _Sandwich.IsToasted = false;
            _Sandwich.Vegetables.Add("Onion");
            _Sandwich.Vegetables.Add("Tomato");
        }

       
    }

    public class Sandwich
    {
        public Sandwich()
        {
            Vegetables = new List<string>();
        }
        Cheese _CheeseType;
        Bread _BreadType;
        bool _IsToasted;

        public bool IsToasted
        {
            get { return _IsToasted; }
            set { _IsToasted = value; }
        }
        public List<string> Vegetables;

        public Bread BreadType
        {
            get { return _BreadType; }
            set { _BreadType = value; }
        }
        public Cheese CheeseType
        {
            get { return _CheeseType; }
            set { _CheeseType = value; }
        }

        public void Display()
        {
            Console.WriteLine("Cheese : {0}", Enum.GetName(typeof(Cheese), _CheeseType));
            Console.WriteLine("Bread : {0}", Enum.GetName(typeof(Bread), _BreadType));
            Console.WriteLine("Toasted : {0}", _IsToasted);
            Console.WriteLine("Vegetables : {0}", string.Join(",", Vegetables));
        }
    }
    public enum Bread
    {
        White,
        Brown
    };
    public enum Cheese
    {
        Cheddar,
        Mayo
    }
}
