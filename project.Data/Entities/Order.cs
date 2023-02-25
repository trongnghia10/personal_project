using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public enum Status
    {
        InProgress,
        Confirmed,
        Shipping,
        Success,
        Canceled
    }
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime orderDate { get; set; }
        public Status status { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }
        public Order()
        {
            orderDetails = new List<OrderDetail>();
        }
        public User user { get; set; }
    }
}
