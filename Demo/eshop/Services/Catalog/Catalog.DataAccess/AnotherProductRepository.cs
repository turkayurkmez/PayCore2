using Catalog.Entities;

namespace Catalog.DataAccess
{
    public class AnotherProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchProductName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
