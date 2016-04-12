using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        class TempRecord
        {
            // Array of temperature values
            private float[] temps = new float[3] { 56.2F, 56.7F, 56.5F };
                                             

            
            // when accessing  indexer.
            public int Length
            {
                get { return temps.Length; }
            }
            // Indexer declaration.
            // If index is out of range, the temps array will throw the exception.
            public float this[int index]
            {
                get
                {
                    return temps[index];
                }

                set
                {
                    temps[index] = value;
                }
            }
        }

        class Test
        {
          public  static void Main(string[]args)
            {
                TempRecord tempRecord = new TempRecord();
                // Use the indexer's set accessor
                tempRecord[0] = 56.2F;
                tempRecord[2] = 56.5F;

                // Use the indexer's get accessor
                for (int i = 0; i < 3; i++)
                {
                    System.Console.WriteLine("Element #{0} = {1}", i, tempRecord[i]);
                }

                
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();

            }
        }
    }
}
