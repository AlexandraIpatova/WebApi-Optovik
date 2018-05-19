using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class OrderLine
    {
        public int OrderlineId { get; set; }
        public int GoodId { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }

        public Goods Good { get; set; }
        public Order Order { get; set; }
    }
}
