using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMas;

namespace Lib_9
{
    public static class Multiply
    {
        public static string MultiplyingAnArray(this LibMas.Array array)
        {
            int product = 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    product *= array[i];
                }
            }
            return product.ToString();
        }
    }
}
