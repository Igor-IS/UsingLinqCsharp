using System;
using System.Collections.Generic;

namespace Linq2_Product.Services
{
    class DisplayData
    {
        public void Display<T>(List<T> collection)
        {
            foreach (var obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
    }
}
