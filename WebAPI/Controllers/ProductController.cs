using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public ProductController(DataContext dataContext)
        {
            _datacontext = dataContext;

        }

        [HttpGet]
        public async Task<IEnumerable<Product>>Get()
        {
            return await _datacontext.Products.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult>Post(Product product)
        {
            await _datacontext.Products.AddAsync(product);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }


       [HttpPost("{id}")]

       public async Task<ActionResult>Get(int id)
       {
            var product = await _datacontext.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
       }

        [HttpPut("{id}")]

        public async Task<ActionResult>Put(int id, Product product)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            _datacontext.Entry(product).State = EntityState.Modified;
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult>Delete(int id)
        {
            var product = await _datacontext.Products.FindAsync(id);
            if(product != null)
            {
                _datacontext.Products.Remove(product);
                await _datacontext.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
