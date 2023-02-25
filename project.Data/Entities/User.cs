using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public class User
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
        public ICollection<Order> orders { get; set; }
        public User() 
        {
            orders = new List<Order>();
        }
    }
}
