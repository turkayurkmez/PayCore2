using Catalog.Entities;

namespace Catalog.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SearchProductName(string name);

    }
}
