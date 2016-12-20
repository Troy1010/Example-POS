using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamplePOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu oMenu = new Menu();
            oMenu.Items.Add(new MenuItem { Name = "Blonde Roast Coffee", BasePrice = 4.03m });
            oMenu.Items.Add(new MenuItem { Name = "Earl Grey Tea", BasePrice = 1.34m });
            oMenu.Items.Add(new MenuItem { Name = "Biscuit", BasePrice = 3.21m });
            oMenu.Items.Add(new MenuItem { Name = "Turkey Sandwich", BasePrice = 2.21m });
            Console.WriteLine(oMenu.Narrate2()+"\n\nWhat would you like to order?");
            // Establish d2dMatchables
            Dictionary<string, List<string>> d2dMatchables = oMenu.d2dMatchables();
            d2dMatchables.Add("Done", new List<string> { "Done" });
            Console.WriteLine(GetPatternFromMatchables(d2dMatchables));
            //
            Match oMatch;
            bool bDone = false;
            do
            {
                oMatch = Regex.Match(Console.ReadLine(), GetPatternFromMatchables(d2dMatchables), RegexOptions.IgnoreCase);
                //oMatch = Regex.Match(" Biscuit ", "Biscuit\b", RegexOptions.IgnoreCase); // HM. Why the f*** does /b automatically translate to backspace.
                if (!oMatch.Success)
                {
                    Console.WriteLine("Your input was invalid. Try again");
                }
                else if (oMatch.ToString()=="Done")
                {
                    bDone = true;
                }
                else //matched from menu
                {
                    Console.WriteLine("Adding "+oMatch.ToString()+" to your order.");
                    // add to order
                }
            } while (!bDone);
            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }

        // HM. How do I import this function from CommonCode?
        public static string GetPatternFromMatchables<T>(Dictionary<T, List<string>> d2dMatchables)
        {
            bool bDoOnce = false;
            string sReturning ="";
            foreach (KeyValuePair<T, List<string>> vPair in d2dMatchables)
            {
                foreach (string sString in vPair.Value)
                {
                    if (!bDoOnce)
                    {
                        bDoOnce = true;
                    }
                    else
                    {
                        sReturning += "|";
                    }
                    sReturning += sString;
                }
            }
            return @"\b(" + sReturning + @")\b";
        }
    }
}
