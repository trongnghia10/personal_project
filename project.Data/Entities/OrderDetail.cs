using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public class OrderDetail
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal totalPrice { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
    }
}
