using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Dapper;

namespace Test.Dapper
{
    public class BrandInjector
    {
        public static DapperRepo Repo;

        public static int Inject()
        {
            Repo = new DapperRepo(ConfigurationManager.ConnectionStrings["GDBConnStr"].ConnectionString);
            var guid = Guid.NewGuid().ToString();
            var brand = new Brand
            {
                BrandName = "Name " + guid,
                BrandCode = "Code " + guid,
                BrandDescription = "Descr " + guid,
                BrandDisplayName = "Display " + guid,
                InCommBrandIdentifier = "Brand id " + guid,
                BrandImageUrl = "ImageUrl " + guid,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = "CreatedByFoo",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "ModifiedByFoo"
            };
            brand.BrandId = Repo.AddBrand(brand);
            return brand.BrandId;
        }
    }
}
