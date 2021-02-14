using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTShop.Client.Base
{
    public class ModuleBase
    {
        public static void Display<T>(
            IEnumerable<T> items, 
            string itemType, 
            Func<T, string> itemDisplayFormat)
        {
            var itemCount = items.Count();
            for(var itemIndex = 0; itemIndex < itemCount; itemIndex++)
            {
                var item = items
                    .ElementAt(itemIndex);
                Console.WriteLine("--- {0} {1} of {2} ---{3}{3}",
                    itemType,
                    itemIndex + 1, 
                    itemCount,
                    newLine);

                Console.WriteLine(
                    itemDisplayFormat(item));

                Console.WriteLine("-------------------------------{0}", newLine);
            }
        }

        public static readonly string newLine = Environment.NewLine;
    }
}
