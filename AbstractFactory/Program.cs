using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = LoadFactory();
            var car = factory.MakeStandardCar();
            car.Start();
            car.Stop();

            var luxCar = factory.MakeLuxaryCar();
            luxCar.Start();
            luxCar.Stop();

            Console.ReadLine();

        }
        private static IAutoFactory LoadFactory()
        {
            var factory = AbstractFactory.Properties.Settings.Default.Factory;
            return Assembly.GetExecutingAssembly().CreateInstance(factory) as IAutoFactory;
        }
    }
    public interface IAuto
    {
        void Start();
        void Stop();
    }
    public interface IAutoFactory
    {
        IAuto MakeStandardCar();
        IAuto MakeLuxaryCar();
    }
    public class BMWM5 : IAuto
    {
        private string _No;
        public BMWM5(string No)
        {
            _No = No;
        }

        public void Start()
        {
            Console.WriteLine("{0} has been started...Grr..", _No);
        }

        public void Stop()
        {
            Console.WriteLine("{0} has been Stoped.", _No);
        }
    }
    public class MiniCooperXS : IAuto
    {
        private string _No;
        public MiniCooperXS(string No
            )
        {
            _No = No;
        }
        public void Start()
        {
            Console.WriteLine("{0} has been started...Vroom..", _No);
        }

        public void Stop()
        {
            Console.WriteLine("{0} has been Stopped.", _No);
        }
    }

    public class BMWM9 : IAuto
    {
        private string _No;
        public BMWM9(string No)
        {
            _No = No;
        }

        public void Start()
        {
            Console.WriteLine("{0} has been started...Grr..", _No);
        }

        public void Stop()
        {
            Console.WriteLine("{0} has been Stoped.", _No);
        }
    }
    public class MiniCooperXZ : IAuto
    {
        private string _No;
        public MiniCooperXZ(string No)
        {
            _No = No;
        }
        public void Start()
        {
            Console.WriteLine("{0} has been started...Vroom..", _No);
        }

        public void Stop()
        {
            Console.WriteLine("{0} has been Stopped.", _No);
        }
    }


    public class BMWFactory : IAutoFactory
    {

        public IAuto MakeStandardCar()
        {
            return new BMWM5("M5-ABC234");
        }


        public IAuto MakeLuxaryCar()
        {
            return new BMWM9("M9-GDR94"); ;
        }
    }
    public class MiniCooperFactory : IAutoFactory
    {

        public IAuto MakeStandardCar()
        {
            return new MiniCooperXS("XS-DEF84");
        }


        public IAuto MakeLuxaryCar()
        {
            return new MiniCooperXS("XZ-GHI8");
        }
    }
}
