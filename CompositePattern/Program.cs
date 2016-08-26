using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
             const int totalGold = 1234;
             Person person1 = new Person() { Name= "Ram",Role="Team Lead" };
             Person person2 = new Person() { Name = "Laxman", Role = "Assistant Lead" };
             Person person3 = new Person() { Name = "Hanuman", Role = "Scrum Master" };
             Group Developers = new Group() { Name = "Developers", Members = new List<IParty>() { new Person(){ Name="Sughrive",Role= "Developer"},new Person(){ Name="Neel",Role="Developer"},new Person(){ Role="Developer",Name="Nal"} } };
             var Helpers = new Group() { Members = new List<IParty>() { new Person() { Name = "Vibhishan", Role = "Helper" }, new Person() { Name = "Garuda", Role = "Helper" } } };



             var Parties = new Group() { Members = new List<IParty>() { person1, person2, person3, Developers, Helpers } };

             Parties.GoldCount = totalGold;
             Parties.Stats();


             Console.ReadLine();

        }

    }

   public interface IParty
    {
        int GoldCount{get ;set;}
        void Stats();
        
    }

    public class Person:IParty
    {
        public string Name { get; set; }
        public string Role { get; set; }
        int _GoldCount;
        public void Stats()
        {
            Console.WriteLine("{0} has {1} Gold.", Name, GoldCount);
        }

        public int GoldCount
        {
            get
            {
                return _GoldCount;
            }
            set
            {
                _GoldCount = value;
            }
        }
    }
    public class Group:IParty
    {
        public List<IParty> Members;
        public string Name { get; set; }


        public int GoldCount
        {
            get
            {
                return Members.Sum(e => e.GoldCount);
            }
            set
            {
                int totalCount = value;
                int leftOver = value % Members.Count;
                foreach (var ind  in Members)
                {
                    ind.GoldCount = (value / Members.Count) + leftOver;
                    leftOver = 0;
                }
            }
        }

        public void Stats()
        {
            foreach (var ind in Members)
            {
                ind.Stats();
            }
        }
    }
}
