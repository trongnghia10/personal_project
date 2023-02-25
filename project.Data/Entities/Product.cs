using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public class Product
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
        // ràng buộc với bảng OrderDetail
        public ICollection<OrderDetail> orderDetails { get; set; }
        public Product() 
        { 
            orderDetails = new List<OrderDetail>();
        }
        // ràng buộc với bảng Category
        public Category category { get; set; }
    }
}
