using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.BackendAPI.Models;
using project.Data.EF;
using project.Data.Entities;

namespace project.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ShopDbContext dbContext;
        public CategoryController(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Lấy ra tất cả Category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }
        // Lấy ra Category theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var ctg = await dbContext.Categories.FindAsync(id);
            if (ctg == null)
            {
                return NotFound();
            }
            return Ok(ctg);
        }
        // Thêm mới category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var ctx = new ShopDbContext())
            {
                ctx.Categories.Add(new Category()
                {
                    id = request.id,
                    name = request.name,
                });
                ctx.SaveChanges();
            }
            return Ok();
        }

        // Sửa ctg theo Id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, CategoryRequest request)
        {
            var ctg = await dbContext.Categories.FindAsync(id);
            if (ctg != null)
            {
                ctg.id = request.id;
                ctg.name = request.name;

                await dbContext.SaveChangesAsync();
                return Ok(ctg);
            }
            return NotFound();
        }

        //Xóa Category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var ctg = await dbContext.Categories.FindAsync(id);
            if (ctg != null)
            {
                dbContext.Remove(ctg);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
