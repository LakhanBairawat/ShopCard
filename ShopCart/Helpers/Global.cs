using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Helpers
{
    public static class Global
    {

        public static string ProdDetailsFormatter(string price, string size, string brand)
        {
            string formatteddata = string.Empty;

            if (!string.IsNullOrEmpty(price))
            {
                formatteddata = price + " | ";
            }

            if (!string.IsNullOrEmpty(size))
            {
                formatteddata += size + " | ";
            }

            if (!string.IsNullOrEmpty(brand))
            {
                formatteddata += brand;
            }

            return formatteddata;
        }
    }
}
