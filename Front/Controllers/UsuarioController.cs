using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Entitys.Result result = Bussiness.Usuario.Login(email);
            if (result.Correct)
            {
                Entitys.Usuario usuario = (Entitys.Usuario)result.Object;
                if (usuario.Password == password)
                {
                    //return View();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Contrasena incorrecta";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = "Error: " + result.Message;
                return PartialView("Modal");
            }
        }
    }
}
