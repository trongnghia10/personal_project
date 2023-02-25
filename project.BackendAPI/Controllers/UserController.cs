using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.BackendAPI.Models;
using project.Data.EF;
using project.Data.Entities;
using System.Net;

namespace project.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShopDbContext dbContext;

        public UserController(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [EnableCors("_myAllowSpecificOrigins")]

        // Lấy ra tất cả User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }
        // Lấy ra User theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // Thêm mới User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] UserRequest request)
        {
            var user = new User()
            {
                fullname = request.fullname,
                roleId = request.roleId,
                email = request.email,
                phoneNumber = request.phoneNumber,
                address = request.address,
                username = request.username,
                password = request.password
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        // Sửa user theo Id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UserRequest request)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.fullname = request.fullname;
                user.roleId = request.roleId;
                user.email = request.email;
                user.phoneNumber = request.phoneNumber;
                user.address = request.address;
                user.username = request.username;
                user.password = request.password;

                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        //Xóa user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
