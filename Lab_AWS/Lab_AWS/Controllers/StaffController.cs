using Lab_AWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_AWS.Controllers
{
    public class StaffController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly DbAwsContext _data;

        public StaffController(ILogger<StaffController> logger, DbAwsContext data)
        {
            _logger = logger;
            _data = data;
        }
        // GET: StaffController
        public ActionResult Index()
        {
            /*string role = "Nhân viên";
            var staffs = _data.TbStaffs.Where(x => x.Role.Trim() == role.Trim()).ToList();*/
            var staffs = _data.TbStaffs.ToList();
            return View(staffs);
        }

        // GET: StaffController
        public ActionResult Detail(string id)
        {
            var staffinfo = _data.TbStaffs.Where(x => x.IdStaff == id).FirstOrDefault();
            return View(staffinfo);
        }


        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff newstaff)
        {
            try
            {
                var context = _data;
                context.TbStaffs.Add(newstaff);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(string id)
        {
            var staffinfo = _data.TbStaffs.Where(x => x.IdStaff == id).FirstOrDefault();
            return View(staffinfo);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Staff Ustaff)
        {
            try
            {
                var context = _data;
                var oldinfo = context.TbStaffs.Find(Ustaff.IdStaff);
                oldinfo.Name = Ustaff.Name;
                oldinfo.Address = Ustaff.Address;
                oldinfo.Phone = Ustaff.Phone;
                oldinfo.Email = Ustaff.Email;
                oldinfo.Password = Ustaff.Password;
                oldinfo.Role = Ustaff.Role;
                oldinfo.Status = Ustaff.Status;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: StaffController/Edit/5
        public ActionResult Staffedit(string id)
        {
            var staffinfo = _data.TbStaffs.Where(x => x.IdStaff == id).FirstOrDefault();
            return View(staffinfo);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Staffedit(Staff Ustaff)
        {
            try
            {
                var context = _data;
                var oldinfo = context.TbStaffs.Find(Ustaff.IdStaff);
                oldinfo.Name = Ustaff.Name;
                oldinfo.Address = Ustaff.Address;
                oldinfo.Phone = Ustaff.Phone;
                oldinfo.Email = Ustaff.Email;
                oldinfo.Password = Ustaff.Password;
                oldinfo.Role = Ustaff.Role;
                oldinfo.Status = Ustaff.Status;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: StaffController/Delete/5
        public ActionResult Delete(string id)
        {
            var staffinfo = _data.TbStaffs.Where(x => x.IdStaff == id).FirstOrDefault();
            return View(staffinfo);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Staff Dstaff)
        {
            var staffinfo = _data.TbStaffs.Where(x => x.IdStaff == Dstaff.IdStaff).FirstOrDefault();
            _data.TbStaffs.Remove(staffinfo);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
