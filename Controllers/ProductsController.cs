using MarketRESTfulAPI.Dtos;
using MarketRESTfulAPI.Models;
using MarketRESTfulAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarketRESTfulAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private IProduct _ProductRepository;

        public ProductsController(IProduct productRepository)
        {
            _ProductRepository = productRepository;
           // _ProductRepository =new InMemProductRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            return _ProductRepository.GetProducts()
                .Select(x=> new ProductDTO
                {
                    Id=x.Id,
                    Title=x.Title,
                    Cost=x.Cost
                }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(Guid id)
        {
            var product = _ProductRepository.GetProduct(id);
            if (product==null)
                return NotFound();

            var productDTO = new ProductDTO {
                Id=product.Id,
                Title=product.Title,
                Cost=product.Cost
            };
            return productDTO;
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductDTO product)
        {
            var myproduct = new Product();
            myproduct.Id = Guid.NewGuid();
            myproduct.Title = product.Title;
            myproduct.Cost = product.Cost;

            _ProductRepository.CreateProduct(myproduct);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, CreateProductDTO product)
        {
            var myproduct = _ProductRepository.GetProduct(id);

            if (myproduct==null)
                return NotFound();

            myproduct.Title = product.Title;
            myproduct.Cost = product.Cost;

            _ProductRepository.UpdateProduct(id, myproduct);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var myproduct = _ProductRepository.GetProduct(id);
            if (myproduct==null)
                return NotFound();
            _ProductRepository.DeleteProduct(id);

            return Ok();

        }

    }
}
