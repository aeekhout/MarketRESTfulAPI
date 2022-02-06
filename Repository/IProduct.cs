using MarketRESTfulAPI.Models;

namespace MarketRESTfulAPI.Repository
{
    public interface IProduct
    {

        public IEnumerable<Product> GetProducts();

        public Product GetProduct(Guid id);

        public void CreateProduct(Product product);

        public void UpdateProduct(Guid id, Product product);

        public void DeleteProduct(Guid id);


    }
}
