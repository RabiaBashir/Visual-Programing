//Namespace Example

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespace_1
{
    
        class namespace_cl
        {
            public void func()
            {
                Console.WriteLine("First");
            }
        }
    }

    namespace second_space
    {
        class namespace_cl
        {
            public void func()
            {
                Console.WriteLine("Second");
            }
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            namespace_1.namespace_cl fc = new namespace_1.namespace_cl();
            second_space.namespace_cl sc = new second_space.namespace_cl();
            fc.func();
            sc.func();
            Console.ReadKey();
        }
    }
