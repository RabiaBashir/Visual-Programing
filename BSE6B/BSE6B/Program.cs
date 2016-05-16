//Sorting Strings Alphabetically
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


    namespace BSE6B
    {
        class Program
        {
            
            static void Main(string[] args)
            {
               //Two strings
                string name1 = "Rabia Bashir";
                string name2 = "Farah Khan";

                // Get position of space character.
                int index1 = name1.IndexOf(" ");
                index1 = index1 < 0 ? 0 : index1--;
                Console.WriteLine(index1);

                int index2 = name2.IndexOf(" ");
                index2 = index1 < 0 ? 0 : index2--;
                Console.WriteLine(index2);

                int length = Math.Max(name1.Length, name2.Length);
                Console.WriteLine(length);

                Console.WriteLine("Sorted alphabetically by last name:");
                if (String.Compare(name1, index1, name2, index2, length,new CultureInfo("en-US"), CompareOptions.IgnoreCase) < 0)
                    Console.WriteLine("{0}\n{1}", name1, name2);
                else
                    Console.WriteLine("{0}\n{1}", name2, name1); 

                Console.ReadLine();

    }
}

}
        
    


