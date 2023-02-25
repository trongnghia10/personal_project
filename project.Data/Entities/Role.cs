using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Entities
{
    public class Role
    {
        public int id { get; set; }
        public string roleName { get; set; }
        public ICollection<User> users { get; set; }
        public Role() {
            users = new List<User>(); 
        }
    }
}
