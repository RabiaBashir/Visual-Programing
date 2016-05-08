using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
  public  class Singleton
    {
      private static Singleton obj;
      private Singleton()
      {

      }
      public static Singleton OBJ
      {
          get
          {
                if(obj==null)
                {
                    obj = new Singleton();
                }
                return obj;
                Console.WriteLine(obj);
          }
          
      }
     
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.obj;
            Singleton s2 = Singleton.obj;

            
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
             Console.ReadLine();
        }
    }
}
