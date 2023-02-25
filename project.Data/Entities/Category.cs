using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Product> products { get; set; }
        public Category()
        {
            products = new List<Product>();
        }
    }
}
