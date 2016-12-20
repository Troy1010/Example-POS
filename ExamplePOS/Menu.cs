using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePOS
{
    class Menu
    {
        public List<MenuItem> Items = new List<MenuItem>();
        public string Narrate2()
        {
            // This version is to be read by user
            string sReturning = "";
            int iTabCount = 0;
            foreach (var menuItem in this.Items.SkipFirst())
            {
                if (!menuItem.Item2)
                {
                    sReturning += "\n";
                }
                iTabCount = Math.Max(iTabCount, (int)Math.Ceiling(menuItem.Item1.Name.Length / 4m));
                sReturning += menuItem.Item1.Name + "<TAB>" + menuItem.Item1.BasePrice;
            }
            sReturning = sReturning.Replace("<TAB>",new string('\t',iTabCount));
            return sReturning;
        }
        public string Narrate()
        {
            // This version is to be read by developer
            string sReturning = "";
            foreach (var menuItem in this.Items.SkipFirst())
            {
                if (!menuItem.Item2)
                {
                    sReturning += "\n";
                }
                sReturning += menuItem.Item1.Name;
            }
            return sReturning;
        }
    }
    class MenuItem
    {
        public string Name;
        public decimal BasePrice;
        public decimal Price
        {
            get { return BasePrice; }
        }
    }
    static class EnumeratorExt
    {
        public static IEnumerable<Tuple<T,bool>> SkipFirst<T>(this IEnumerable<T> vLoopable)
        {
            bool bDoOnce = false;
            foreach (var item in vLoopable)
            {
                if (!bDoOnce)
                {
                    bDoOnce = true;
                    yield return new Tuple<T, bool>(item,true);
                }
                else
                {
                    yield return new Tuple<T, bool>(item, false);
                }
            }
        }
    }
}
