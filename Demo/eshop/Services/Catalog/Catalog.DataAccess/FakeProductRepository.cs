using Catalog.Entities;

namespace Catalog.DataAccess
{
    public class FakeProductRepository : IProductRepository
    {
        List<Product> products;
        public FakeProductRepository()
        {
            products = new List<Product>
            {
                new Product{ Id=1, Name="Ürün A", Price=100, Stock=100},
                new Product{ Id=2, Name="Ürün B", Price=150, Stock=100},
                new Product{ Id=3, Name="Ürün B", Price=200, Stock=100}


            };
        }
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            return products;
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
