using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueAranda.Models.BidingModels
{
    public class ProductsBM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }
    }
}
