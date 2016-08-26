using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Manuscript> lstDocument = new List<Manuscript>();

            Book book = new Book("Bridge Pattern", "GOF", new StandardPrinter());
            NewPaper theHindu = new NewPaper("The Hindu","Hindustant Times",new ReversePrinter());
            lstDocument.Add(book);
            lstDocument.Add(theHindu);

            foreach (var doc in lstDocument)
            {
                   doc.Print();
            }
            Console.ReadLine();

        }

        public abstract class Manuscript
        {
            protected IPrinter _printer;
            public Manuscript(IPrinter Printer)
            {
                _printer = Printer;
            }
            public abstract void Print();
        }
        public class Book : Manuscript
        {
            
            public Book(string Name, string Author, IPrinter Printer)
                : base(Printer)
            {
                _Name = Name;
                _Author = Author;
                
            }
            private string _Author;
            private string _Name;


            public string Author
            {
                get { return _Author; }
                set { _Author = value; }
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }


            public override void Print()
            {
                Console.WriteLine("I am from Book.");
                Console.WriteLine("Name  {0}, Author {1}", _printer.Print(_Name), _printer.Print(_Author));

            }
        }

        public class NewPaper : Manuscript
        {
          
            public NewPaper(string Name, string Publisher, IPrinter Printer)
                : base(Printer)
            {
                _Name = Name;
                _Publisher = Publisher;
             
            }
            private string _Publisher;
            private string _Name;

            public string Author
            {
                get { return _Publisher; }
                set { _Publisher = value; }
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            public override void Print()
            {
                Console.WriteLine("I am from News Paper.");
                Console.WriteLine("Name  {0}, Publisher {1}", _printer.Print(_Name), _printer.Print(_Publisher));
            }
        }

        public interface IPrinter
        {
            string Print(string Text);
        }
        public class StandardPrinter : IPrinter
        {
            public string Print(String Text)
            {
                return Text;
            }
        }
        public class ReversePrinter : IPrinter
        {
            public string Print(String Text)
            {
                char[] charArray = Text.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }

}
