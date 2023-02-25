using Microsoft.AspNetCore.Mvc;
using project.Data.EF;

namespace project.AdminApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ShopDbContext dbContext;
        public LoginController(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var user = dbContext.Users.FirstOrDefault(u => u.username == username && u.password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("username", username);
                // Lưu thông tin đăng nhập vào phiên
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.errLogin = "Sai tên đăng nhập hoặc mật khẩu";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "Login");
        }
    }
}
