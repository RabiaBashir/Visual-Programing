using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExample
{
    class Program
    {
        public class Employee
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        public class Manager : Employee
        {
            private string name;

            // Notice the use of the new modifier:
            public new string Name
            {
                get { return name; }
                set { name = value + ", Female"; }
            }
        }

        class Test
        {
            public static void Main(string[] args)
            {
                Manager m1 = new Manager();

                // Derived class property.
                m1.Name = "Rabia Bashir";

                // Base class property.
                ((Employee)m1).Name = "Farah Bashir";

                System.Console.WriteLine("Name in the derived class is: {0}", m1.Name);
                System.Console.WriteLine("Name in the base class is: {0}", ((Employee)m1).Name);
                Console.ReadLine();
            }
        }
        
    }
}
