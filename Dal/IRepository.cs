using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Dapper;

namespace Dal
{
    public interface IRepository
    {
        int AddBrand(Brand brand);
        void UpdateBrand(Brand brand);
        IList<Brand> GetBrands();
        Brand GetBrandById(int brandId);

        int AddProduct(Product product);
        void UpdateProduct(Product product);
        IList<Product> GetProducts();
        Brand GetProductById(int productId);
    }
}
