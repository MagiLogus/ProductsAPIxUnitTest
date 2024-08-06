
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Domains;
using ProductsAPI.Interface;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;

        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Products>> Get()
        {
            try
            {
                var products = _repository.Get();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetById(Guid id)
        {
            try
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Products newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product is null.");
            }

            try
            {
                _repository.Post(newProduct);
                return CreatedAtAction(nameof(GetById), new { id = newProduct.IdProduct }, newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Products updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest("Product is null.");
            }

            try
            {
                var existingProduct = _repository.GetById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                _repository.Put(id, updatedProduct);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }

                _repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
