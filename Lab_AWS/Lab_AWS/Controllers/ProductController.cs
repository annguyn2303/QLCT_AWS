using Lab_AWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_AWS.Controllers
{
    public class ProductController : Controller
    {

        private readonly DbAwsContext _data;

        public ProductController( DbAwsContext data)
        {
            _data = data;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _data.TbProducts.Include("company").ToList();
            return View(products);
        }

       
        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            var product = _data.TbProducts.FirstOrDefault(x => x.IdProduct == id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product Dproduct)
        {
            var product = _data.TbProducts.Where(x => x.IdProduct == Dproduct.IdProduct).FirstOrDefault();
            _data.TbProducts.Remove(product);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
