using System;
using System.Collections.Generic;

namespace OPTOVIK.Models
{
    public partial class Country
    {
        public Country()
        {
            Manufacturer = new HashSet<Manufacturer>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Manufacturer> Manufacturer { get; set; }
    }
}
