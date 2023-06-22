using Lab_AWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Lab_AWS.Controllers
{
    public class LoginController : Controller
    {

        private readonly DbAwsContext _data;

        public LoginController(DbAwsContext data)
        {
            _data = data;
        }
        // GET: LoginController
        public ActionResult Login()
        {
            byte[] value = null;
            if (HttpContext.Session.TryGetValue("username", out value))
            {
                TempData["success"] = "Login Succesfully";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password )
        {
            if (Email == null || Password == null)
            {
                ModelState.AddModelError("Email", "Email không được để trống");
                return View();
            }
            var user = _data.TbStaffs.FirstOrDefault(x => x.Email.Trim() == Email.Trim());
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email không đúng ");
            }
            if (ModelState.IsValid)
            {

                if (user.Password.Trim() == Password.Trim())
                {
                    TempData["success"] = "Đăng Nhập Thành Công";
                    HttpContext.Session.SetString("username", user.Name);
                    HttpContext.Session.SetString("idstaff", user.IdStaff);

                    var idtruck = _data.TbTrucks.FirstOrDefault(x=>x.IdStaff == user.IdStaff);
                    if (idtruck != null)
                    {
                        HttpContext.Session.SetString("idtruck", idtruck.IdTruck);
                        HttpContext.Session.SetString("lplate", idtruck.LicensePlates);
                    }

                    if(user.Role.Trim() == "Quản lý")
                        return RedirectToAction("Admin");
                    if(user.Role.Trim() == "Nhân viên")
                        return RedirectToAction("Staff");
                }
                else
                {
                    ModelState.AddModelError("Password", "Sai Mật Khẩu");
                }
            }

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Staff()
        {
            
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("idstaff");
            HttpContext.Session.Remove("idtruck");
            return RedirectToAction("Login");
        }
        
    }
}
