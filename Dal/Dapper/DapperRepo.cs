using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Dal.Dapper
{
    public class DapperRepo : IRepository
    {
        private string _connectionString;

        public DapperRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddBrand(Brand brand)
        {
            var insertStmt = @"INSERT Products.Brands (BrandName, BrandCode, BrandDescription, BrandDisplayName, InCommBrandIdentifier, BrandImageUrl,
                IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) VALUES (@BrandName, @BrandCode, @BrandDescription, @BrandDisplayName,
                @InCommBrandIdentifier, @BrandImageUrl, @IsActive, @CreatedOn, @CreatedBy, @ModifiedOn, @ModifiedBy); SELECT scope_identity();";
            object id = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                id = conn.ExecuteScalar(insertStmt, brand);

                conn.Close();
            }
            return id != null ? Convert.ToInt32(id) : 0;
        }

        public void UpdateBrand(Brand brand)
        {
            var updateStmt = @"UPDATE Products.Brands
                        SET BrandName = @BrandName, BrandCode = @BrandCode, BrandDescription = @BrandDescription, BrandDisplayName = @BrandDisplayName, 
                            InCommBrandIdentifier = @InCommBrandIdentifier, BrandImageUrl = @BrandImageUrl, IsActive = @IsActive, CreatedOn = @CreatedOn, CreatedBy = @CreatedBy, 
                            ModifiedOn = @ModifiedOn, ModifiedBy = @ModifiedBy)
                        WHERE BrandId = @BrandId";
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                conn.Execute(updateStmt, brand);

                conn.Close();
            }
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

        public IList<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Brand GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
