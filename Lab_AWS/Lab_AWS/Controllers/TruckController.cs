using Lab_AWS.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Lab_AWS.Controllers
{
    public class TruckController : Controller
    {
        private readonly ILogger<TruckController> _logger;
        private readonly DbAwsContext _data;

        public TruckController(ILogger<TruckController> logger, DbAwsContext data)
        {
            _logger = logger;
            _data = data;
        }
        // GET: TruckController
        public ActionResult Index()
        {
            var trucksWithDrivers = _data.TbTrucks.Include("staff").ToList();
            return View(trucksWithDrivers);
        }

        // GET: TruckController/Details/5
        public ActionResult Details(string id)
        {
            var truckinfo = _data.TbTruckdetails.Include("product").Where(x => x.IdTruck == id).ToList();
            return View(truckinfo);
        }

        public ActionResult Truckinfo(string id)
        {
            byte[] value = null;
            var truckinfo = _data.TbTruckdetails.Include("product").Where(x => x.IdTruck == id).ToList();

            string a = HttpContext.Session.GetString("lplate");
            ViewBag.Value = a;

            return View(truckinfo);
        }


        // GET: TruckController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TruckController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Truck newtruck)
        {
            try
            {
                var context = _data;
                context.TbTrucks.Add(newtruck);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TruckController/Edit/5
        public ActionResult Used(string id)
        {
            string idtruck = HttpContext.Session.GetString("idtruck");
            var truckinfo= _data.TbTruckdetails.FirstOrDefault(x =>x.IdTruck.Equals(idtruck) && x.IdProduct.Equals(id));
            return View(truckinfo);
        }

        // POST: TruckController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Used(Truckdetail newtruck)
        {
            try
            {
                var context = _data;
                var oldinfo = context.TbTruckdetails.FirstOrDefault(x=>x.IdTruck == newtruck.IdTruck && x.IdProduct == newtruck.IdProduct);
                oldinfo.Used = newtruck.Used + oldinfo.Used;
                oldinfo.Inventory = - newtruck.Used + oldinfo.Inventory;
                if(oldinfo.Inventory > 0)
                {
                    context.SaveChanges();
                }
                else
                {
                    string message = "Hiện xe " + oldinfo.IdTruck + " đang sử dụng hết sản phẩm " + oldinfo.IdProduct;
                    Sms.SendSmsAdmin(message);
                }
                string idtruck = HttpContext.Session.GetString("idtruck");
               return LocalRedirect("~/Truck/Truckinfo/"+idtruck);
            }
            catch
            {
                return View();
            }
        }

        // GET: TruckController/Delete/5
        public ActionResult Delete(string id)
        {
            var truck= _data.TbTrucks.FirstOrDefault(x=> x.IdTruck ==id);
            return View(truck);
        }

        // POST: TruckController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Truck Dtruck)
        {
            var truck = _data.TbTrucks.FirstOrDefault(x => x.IdTruck == Dtruck.IdTruck);
            _data.TbTrucks.Remove(truck);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
