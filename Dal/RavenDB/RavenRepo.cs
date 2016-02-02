using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Raven.Client.Document;

namespace Dal.RavenDB
{
    public class RavenRepo : IDocStoreRepository
    {
        private DocumentStore _documentStore;
        private MapperConfiguration _mapCfg;

        public RavenRepo(string documentStoreUrl, MapperConfiguration mapCfg)
        {
            _mapCfg = mapCfg;
            _documentStore = new DocumentStore
            {
                Url = documentStoreUrl
            };
            _documentStore.Initialize();
        }

        public string SaveBrand(Brand brand)
        {
            using (var session = _documentStore.OpenSession())
            {
                if (string.IsNullOrEmpty(brand.Id))
                {
                    session.Store(brand);
                }
                else
                {
                    // Get the document and map property values
                    var mapper = _mapCfg.CreateMapper();
                    mapper.Map<Brand, Brand>(GetBrand(brand.Id), brand);
                }
                session.Store(brand);
                session.SaveChanges();
            }
            return brand.Id;
        }

        public Brand GetBrand(string id)
        {
            Brand brand = null;
            using (var session = _documentStore.OpenSession())
            {
                brand = session.Load<Brand>(id);
            }
            return brand;
        }

        public IList<Brand> GetBrands()
        {
            throw new NotImplementedException();
        }
    }
}
