using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleTechTest
{
    public class BaseTea
    {
        public int id { get; set; }
        public string name { get; set; }

        public int price { get; set; }
    }

    public class Flavour
    {
        public int id { get; set; }
        public string name { get; set; }

        public int price { get; set; }
    }

    class ShoppingCart
    {
        public string base_tea { get; set; }
        public string flavour { get; set; }
        public string size { get; set; }
        public string toppings { get; set; }



    }

}
