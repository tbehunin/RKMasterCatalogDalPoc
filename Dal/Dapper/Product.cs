using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dapper
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductDisplayName { get; set; }
        public Brand Brand { get; set; }
        public string InCommProductUPC { get; set; }
        public string ProductSKU { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string TempInfoBlob { get; set; }
    }
}
