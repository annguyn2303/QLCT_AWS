using Lab_AWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_AWS.Controllers
{
    public class InvokeController : Controller
    {
        private readonly DbAwsContext _data;

        public InvokeController( DbAwsContext data)
        {
            _data = data;
        }
        // GET: InvokeController
        public ActionResult Index()
        {
            var invokes = _data.DbInvokes.ToList();
            return View(invokes);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            ViewBag.idstaff = HttpContext.Session.GetString("idstaff");
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoke newstaff)
        {
            try
            {
                var context = _data;
                context.DbInvokes.Add(newstaff);
                context.SaveChanges();
                string mess = "Nhân viên " + HttpContext.Session.GetString("username") + " vừa tạo hóa đơn nhập hàng";
                Sms.SendSmsAdmin(mess);
                return RedirectToAction("Staff","Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
