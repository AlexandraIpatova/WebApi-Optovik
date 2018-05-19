using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Goods = new HashSet<Goods>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Goods> Goods { get; set; }
    }
}
