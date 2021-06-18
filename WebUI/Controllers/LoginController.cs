using DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly CoinContext _context;
        private readonly EfUserRepostoryDal _efUserRepostoryDal;

        public LoginController(CoinContext context)
        {
            _context = context;
            _efUserRepostoryDal = new EfUserRepostoryDal(context);
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {           
            var control = _efUserRepostoryDal.LoginControl(userName, password);
            
            if (!control)
            {
                ViewBag.IncorrectLogin = "Kullanıcı adınızı ve ya şifrenizi yanlış girdiniz.";
                return View();
            }           

            return RedirectToAction("CoinPage", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
                       
        private int UserId() 
        {
            if (Request.Cookies["UserId"] == null) 
            {
                return 0;
            }
            return int.Parse(Request.Cookies["UserId"]);
        }

    }
}
