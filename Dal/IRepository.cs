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
        void DeleteBrand(int brandId);
        IList<Brand> GetBrands();
        Brand GetBrandById(int brandId);

        int AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int brandId);
        IList<Product> GetProductsByBrand(int brandId);
        Brand GetProductById(int productId);
    }

    public interface IDocStoreRepository
    {
        string SaveBrand(Brand brand);
        Brand GetBrand(string id);
        IList<Brand> GetBrands();
    }
}
