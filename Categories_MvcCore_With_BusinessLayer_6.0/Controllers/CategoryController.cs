using Categories_MvcCore_With_BusinessLayer_6._0.Authentication;
using Categories_MvcCore_With_BusinessLayer_6._0.BussinesLayer.Catergories;
using Categories_MvcCore_With_BusinessLayer_6._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Categories_MvcCore_With_BusinessLayer_6._0.Controllers
{
    //[Authorize]
    public class CategoryController : Controller
    {
        private readonly ICatergory _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;



        public CategoryController(ICatergory context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_userManager.Users.Any())
            {
                var data = _context.GetData();
                return View(data);
            }
            else
            {
                return RedirectToAction("");
            }

        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var data = _context.GetDataById(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories obj)
        {
            if (_context.InsertData(obj))
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.GetDataById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,DisplayOrder")] Categories category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.UpdateData(category);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.GetDataById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteData(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _context.GetDataById(id);
            return View(data);
        }
    }
}
