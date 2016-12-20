using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine(oMenu.Narrate2());
            Console.ReadLine();
        }
    }
}
