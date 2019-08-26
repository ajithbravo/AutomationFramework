using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Modal
{    
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
        public int locationId { get; set; }
        public int familyId { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Family
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Transaction
    {
        public int id { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
        public int productId { get; set; }
    }

    public class Products
    {
        public List<Product> products { get; set; }
        public List<Location> locations { get; set; }
        public List<Family> families { get; set; }
        public List<Transaction> transactions { get; set; }
    }

}
