using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class Goods
    {
        public Goods()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int GoodId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public byte[] Image { get; set; }
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Type Type { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
    }
}
