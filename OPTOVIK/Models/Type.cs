using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class Type
    {
        public Type()
        {
            Goods = new HashSet<Goods>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Goods> Goods { get; set; }
    }
}
