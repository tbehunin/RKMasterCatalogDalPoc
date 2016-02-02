using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using Dal;
using Dal.RavenDB;

namespace Test.RavenDB
{
    /// <summary>
    /// Summary description for RavenRepoTests
    /// </summary>
    [TestClass]
    public class RavenRepoTests
    {
        private MapperConfiguration _mapCfg;

        public RavenRepoTests()
        {
            _mapCfg = new MapperConfiguration(cfg => cfg.CreateMap<Brand, Brand>());
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ShouldAddANewBrandDocument()
        {
            var brand = BrandInjector.Inject(_mapCfg);
            Assert.IsNotNull(brand.Id);
        }

        [TestMethod]
        public void ShouldUpdateAnExistingBrandDocument()
        {
            // First add a brand document
            var initialBrand = BrandInjector.Inject(_mapCfg);

            RavenRepo repo = new RavenRepo("http://localhost:8080", _mapCfg);
            var freshBrand = repo.GetBrand(initialBrand.Id);
            Assert.AreEqual(initialBrand.Id, freshBrand.Id);

            freshBrand.BrandName = "updated";
            Assert.AreNotEqual(initialBrand.BrandName, freshBrand.BrandName);
            repo.SaveBrand(freshBrand);

            var freshFreshBrand = repo.GetBrand(freshBrand.Id);
            Assert.AreEqual(freshBrand.Id, freshFreshBrand.Id);
            Assert.AreEqual(freshBrand.BrandName, freshFreshBrand.BrandName);
        }
    }
}
