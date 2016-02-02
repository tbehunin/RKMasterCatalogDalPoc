using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.RavenDB
{
    public class RavenRepo : IRepository
    {
        public int AddBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void DeleteBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public IList<Brand> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Brand GetBrandById(int brandId)
        {
            throw new NotImplementedException();
        }

        public int AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int brandId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Brand GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
