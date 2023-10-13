using backend.Context;
using backend.Dtos;
using backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto dto)
        {
            var newProduct = new ProductEntity()
            {
                Brand = dto.Brand,
                Title = dto.Title,
            };

            await _context.PetStoreProducts.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }

        // Read
        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
            var products = await _context.PetStoreProducts.OrderByDescending(q => q.UpdatedAt).ToListAsync();

            return Ok(products);
        }
        // Read id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductByID([FromRoute] long id)
        {
            var product = await _context.PetStoreProducts.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        // Update
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> UpdateProduct([FromRoute] long id, [FromBody] CreateUpdateProductDto dto)
        {
            var product = await _context.PetStoreProducts.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            product.Title = dto.Title;
            product.Brand = dto.Brand;
            product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        [HttpDelete]
        [Route("{id}")]

        // Delete
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.PetStoreProducts.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            _context.PetStoreProducts.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");

        }


    }
    }
