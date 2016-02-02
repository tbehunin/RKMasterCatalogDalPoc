using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;
using Dal.RavenDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.RavenDB
{
    public class BrandInjector
    {
        public static Brand Inject(MapperConfiguration cfg)
        {
            RavenRepo repo = new RavenRepo("http://localhost:8080", cfg);
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
            repo.SaveBrand(brand);
            return brand;
        }
    }
}
