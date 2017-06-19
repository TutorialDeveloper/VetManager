using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetManager.Models;

namespace VetManager.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NewUser(UsersModelView user)
        {
            VetManagerEntities vetManagerDB = new VetManagerEntities();
            Users usuarios = vetManagerDB.Users.SingleOrDefault(x => x.UserName == user.UserName);

            var NewUser = new Models.UsersModelView()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Email = user.Email
            };


            return Json(NewUser);
        }

        [HttpPost]
        public JsonResult GetDados(Logon user)
        {
            VetManagerEntities vetManagerDB = new VetManagerEntities();
            Users usuarios = vetManagerDB.Users.SingleOrDefault(x => x.UserName == user.UserName);

            var resultado = new
            {
                FirstName = usuarios.FirstName,
                LastName = usuarios.LastName,
                UserName = usuarios.UserName,
                BirthDate = usuarios.BirthDate.ToShortDateString(),
                Email = usuarios.Email
            };
            return Json(resultado);
        }
    }
}