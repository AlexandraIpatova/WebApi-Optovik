using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
