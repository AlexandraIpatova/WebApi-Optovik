using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
    }
}
