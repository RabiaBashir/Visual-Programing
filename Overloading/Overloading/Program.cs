using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Program
    {
        
        protected int Cgpa;
        public virtual int gpa()
        {
            Console.WriteLine("parent");
            Console.ReadLine();
            return 0;
        }
        class bse : Program
        {
           
            public override int gpa()
            {
                Console.WriteLine("child");
                Console.ReadLine();
                return 0;
            }
            class Caller
            {
                public void CallGpa(Program sh)
                {
                    int a;
                    a = sh.gpa();
                    Console.WriteLine("", a);
                }
            }  

            static void Main(string[] args)
            {
                Caller c = new Caller();
                
                bse b = new bse();
                

                c.CallGpa(b);
            }
            
        }
    }
}

