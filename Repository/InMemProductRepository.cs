using MarketRESTfulAPI.Models;

namespace MarketRESTfulAPI.Repository
{
    public class InMemProductRepository : IProduct
    {
        private List<Product> _Products;

        public InMemProductRepository()
        {
            _Products = new(){ 
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Product 0",
                Cost = 10
            } };
        }
        public void CreateProduct(Product product)
        {
            _Products.Add(product);
        }

        public void DeleteProduct(Guid id)
        {
            var productIndex = _Products.FindIndex(x => x.Id==id);
            if (productIndex > -1)
                _Products.RemoveAt(productIndex);
        }

        public Product GetProduct(Guid id)
        {
            var product = _Products.Where(x=> x.Id == id).SingleOrDefault();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _Products;
        }

        public void UpdateProduct(Guid id, Product product)
        {
            var productIndex = _Products.FindIndex(x => x.Id==id);
            if (productIndex > -1)
                _Products[productIndex] = product;
        }
    }
}
