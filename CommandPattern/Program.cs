using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = GetAvailableCommand();
            if (args.Length == 0)
            {
                foreach (var cmd in commands)
                {
                    Console.WriteLine("Command {0}", cmd.Name);
                    Console.WriteLine(cmd.Description);
                }
                return;
            }
            var commandParser = new CommandParser(commands);
            var command = commandParser.MakeCommand(args);
            command.Execute();


        }
        static IEnumerable<ICommandFactory> GetAvailableCommand()
        {
            return new ICommandFactory[] { new Add(), new Update(), new Delete() };
        }
    }


    public interface ICommand
    {

        void Execute();
    }
    public interface ICommandFactory
    {
        String Name { get; }
        String Description { get; }
        ICommand GetCommand(string[] args);

    }
    public class NullCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("No such command found.");
        }
    }
    public class Add : ICommand, ICommandFactory
    {
        

        public string Name
        {
            get
            {
                return "Add";
            }

        }

        public string Description
        {
            get
            {
                return "Adds item to database: Arguments 'Add {Quantity}'";
            }

        }

        public String Quantity;


        public void Execute()
        {
            Console.WriteLine("Database updated");
            Console.WriteLine("Item added: Quantity {0}.", Quantity);
        }

        public ICommand GetCommand(string[] args)
        {
            var newAddCommand = new Add();
            newAddCommand.Quantity = args[1];
            return newAddCommand;
        }
    }
    public class Update : ICommand, ICommandFactory
    {

        public String NewQuantity { get; set; }

        public string Name
        {
            get
            {
                return "Update";
            }

        }

        public string Description
        {
            get
            {
                return "Updates the database with given quantity: Arguments 'Update {Quantity}'";
            }

        }


        public void Execute()
        {
            const int oldQuantity = 5;
            Console.WriteLine("Database updated");
            Console.WriteLine("Old quantity {0} updated to {1}", oldQuantity, NewQuantity);

        }

        public ICommand GetCommand(string[] args)
        {
            var newCommand = new Update();
            newCommand.NewQuantity = args[1];
            return newCommand;
        }
    }
    public class Delete : ICommand, ICommandFactory
    {


        public string Name
        {
            get
            {
                return "Delete";
            }

        }

        public string Description
        {
            get
            {
                return "Deletes the item from database: Arguments 'Delete {Id}'";
            }

        }

        public string Id;


        public void Execute()
        {
            Console.WriteLine("Database updated");
            Console.WriteLine("Item deleted : {0}", Id);
        }

        public ICommand GetCommand(string[] args)
        {
            var newCommand = new Delete();
            newCommand.Id = args[1];
            return newCommand;
        }
    }

    public class CommandParser
    {
        IEnumerable<ICommandFactory> _Commands;
        public CommandParser(IEnumerable<ICommandFactory> Commands)
        {
            _Commands = Commands;
        }
        public ICommand MakeCommand(string[] args)
        {
            var commandFactory =_Commands.FirstOrDefault<ICommandFactory>(e => (string.Compare(e.Name.Trim(),args[0].Trim(),true)==0));
            if (commandFactory == null)
                return new NullCommand();
            else
                return commandFactory.GetCommand(args);
        }
    }


}
