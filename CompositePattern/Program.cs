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
             Group Developers = new Group() { Name = "Developers", Persons = new List<Person>() { new Person(){ Name="Sughrive",Role= "Developer"},new Person(){ Name="Neel",Role="Developer"},new Person(){ Role="Developer",Name="Nal"} } };
             List<Person> Helpers = new List<Person>() { new Person(){Name="Vibhishan",Role = "Helper"},new Person(){ Name="Garuda",Role="Helper" }};


             List<IParty> lstParties = new List<IParty>() { person1,person2,person3,Developers};
             lstParties.AddRange(Helpers);

             foreach (var party in lstParties)
             {
                 party.GoldCount = totalGold/lstParties.Count;
             }
             foreach (var party in lstParties)
                 party.Stats();

        }

    }

    interface IParty
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
        public List<Person> Persons;
        public string Name { get; set; }


        public int GoldCount
        {
            get
            {
                return Persons.Sum(e => e.GoldCount);
            }
            set
            {
                int totalCount = value;
                int leftOver = value % Persons.Count;
                foreach (var ind  in Persons)
                {
                    ind.GoldCount = (value / Persons.Count) + leftOver;
                    leftOver = 0;
                }
            }
        }

        public void Stats()
        {
            foreach (var ind in Persons)
            {
                ind.Stats();
            }
        }
    }
}
