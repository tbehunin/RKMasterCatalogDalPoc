using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandCode { get; set; }
        public string BrandDescription { get; set; }
        public string BrandDisplayName { get; set; }
        public string InCommBrandIdentifier { get; set; }
        public string BrandImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public IList<Product> Products { get; set; }
    }
}
