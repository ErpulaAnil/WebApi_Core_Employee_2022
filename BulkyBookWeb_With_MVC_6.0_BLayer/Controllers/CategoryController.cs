using BulkyBookWeb_With_MVC_6._0_BLayer.Data;
using BulkyBookWeb_With_MVC_6._0_BLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb_With_MVC_6._0_BLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _appDb;

        public CategoryController(ApplicationDbContext appDb)
        {
            _appDb=appDb;   
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objcategoryList = _appDb.CategoriesBulky;
            return View(objcategoryList);
        }

        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _appDb.CategoriesBulky.Add(obj);
                _appDb.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
          var categoryFromDb =_appDb.CategoriesBulky.Find(id);
            // var categoryFromDb = _appDb.CategoriesBulky.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _appDb.CategoriesBulky.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _appDb.CategoriesBulky.Update(obj);
                _appDb.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _appDb.CategoriesBulky.Find(id);
            // var categoryFromDb = _appDb.CategoriesBulky.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _appDb.CategoriesBulky.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj= _appDb.CategoriesBulky.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _appDb.CategoriesBulky.Remove(obj);
            _appDb.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
