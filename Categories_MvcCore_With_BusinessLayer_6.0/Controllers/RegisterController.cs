using Categories_MvcCore_With_BusinessLayer_6._0.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Categories_MvcCore_With_BusinessLayer_6._0.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
 

        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;   
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel regModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = regModel.Email, Email = regModel.Email };
                var result = await _userManager.CreateAsync(user, regModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Login", "Login");
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel logModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(logModel.Username, logModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Category");
                }
                ModelState.AddModelError(string.Empty, "Invalid loginattempt");
            }
            return View(logModel);
        }
    }
}
