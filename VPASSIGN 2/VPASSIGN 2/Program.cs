using Microsoft.CSharp; // For CSharpCodeProvider
using System.CodeDom.Compiler; // For ICodeCompiler
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPASSIGN_2
{
  
    class Program
    {
        static void Main(string[] args)
        {    
            //string to write a code
            string c = "";
            //string for number of lines
            string l = "";
            //string for Output
            string O = "";
            //Set only exe
            string exe = "Out.exe";

            Console.WriteLine("Press F1 to write the C# Code");
            Console.WriteLine("Press F5 to compile the C# Code");
            Console.Write("Enter your Choice: ");
            var choice = Console.ReadKey();
            Console.WriteLine(choice.Key.ToString());
            //specifies standard keys on Console
            if (choice.Key == ConsoleKey.F1) // 1st Choose to Write the C# Code
            {
                while (true)
                {
                    l = Console.ReadLine(); // Written Code is Adding to Code String
                    //Provide info about and manipulate the current environment and platform
                    c = c + l + Environment.NewLine;
                    var btn = Console.ReadKey();
                    if (btn.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }
                    else if (btn.Key == ConsoleKey.F5)
                    {
                        
                        //provides access to instances of the C# code generator and code compiler
                        CSharpCodeProvider cp = new CSharpCodeProvider();
                        
                        // Define interface for invoking compilation of source code
                        ICodeCompiler ic = cp.CreateCompiler();

                        //Represents the Parameters used to Invoke the Compiler
                        System.CodeDom.Compiler.CompilerParameters p = new CompilerParameters();
                        //get or set value indicating whether to generate an exe
                        p.GenerateExecutable = true;
                        //get or set the name of output assembly
                        p.OutputAssembly = exe;

                        // Represents the results of Compilation that are returned from Compiler 
                        CompilerResults results = ic.CompileAssemblyFromSource(p, c);
                        // Check the error 
                        if (results.Errors.Count > 0) //  if error occur
                        {
                            //Represent Compiler error or warning
                            foreach (CompilerError CompErr in results.Errors)
                            {
                                O = O + "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";" + Environment.NewLine + Environment.NewLine;



                            }
                        }
                        else //Successfully Compile the Code
                        {
                            O = "Success!";
                        }
                        break;
                    }
                    else
                    {
                        c = c + btn.KeyChar.ToString();
                    }
                }
            }
            else if (choice.Key == ConsoleKey.F5)
            {
                Console.WriteLine("First Write  the Code and then Compile it !");
            }
            else
            {
                Console.WriteLine(" Sorry!You have enetered an Invalid Key ");
            }

            Console.WriteLine("Code is as: " + Environment.NewLine + c);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Output is as: " + Environment.NewLine + O);
            Console.ReadLine();

        }


    }
}

                            
                        

                       
           
    



