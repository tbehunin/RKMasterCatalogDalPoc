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
        public static DapperRepo Repo;
        public static Brand Brand;

        public BrandAddUpdateTests()
        {
        }

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Repo = new DapperRepo(ConfigurationManager.ConnectionStrings["GDBConnStr"].ConnectionString);
            var guid = Guid.NewGuid().ToString();
            Brand = new Brand
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
            Brand.BrandId = Repo.AddBrand(Brand);
        }

        [TestMethod]
        public void ShouldInsertBrandSuccessfully()
        {
            Assert.IsTrue(Brand.BrandId > 0);
        }

        [TestMethod]
        public void ShouldUpdateBrandNameSuccessfully()
        {
            var oldValue = Brand.BrandName;
            var newValue = Guid.NewGuid().ToString();
            Assert.AreNotEqual(oldValue, newValue);

            Brand.BrandName = newValue;

            Repo.UpdateBrand(Brand);
        }

        [ClassCleanup]
        public void TearDown()
        {
            Repo.DeleteBrand(Brand.BrandId);
        }
    }
}
