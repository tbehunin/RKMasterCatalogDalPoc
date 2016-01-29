using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dal.Dapper;
using System.Configuration;

namespace Test.Dapper
{
    /// <summary>
    /// Summary description for DapperRepo
    /// </summary>
    [TestClass]
    public class BrandAddUpdateTests
    {
        public BrandAddUpdateTests()
        {
        }

        [TestMethod]
        public void ShouldInsertBrandSuccessfully()
        {
            var repo = new DapperRepo(ConfigurationManager.ConnectionStrings["GDBConnStr"].ConnectionString);
            var brand = new Brand
            {
                BrandName = "BrandNameFoo",
                BrandCode = "BrandCodeFoo",
                BrandDescription = "BrandDescriptionFoo",
                BrandDisplayName = "BrandDisplayNameFoo",
                InCommBrandIdentifier = "InCommBrandIdentifierFoo",
                BrandImageUrl = "BrandImageUrlFoo",
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = "CreatedByFoo",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "ModifiedByFoo"
            };
            var id = repo.AddBrand(brand);
            Assert.IsTrue(id > 0);
        }
    }
}
