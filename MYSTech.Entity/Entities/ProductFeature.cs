using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class ProductFeature : BaseEntity
    {
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Product Product { get; set; }
    }
}
