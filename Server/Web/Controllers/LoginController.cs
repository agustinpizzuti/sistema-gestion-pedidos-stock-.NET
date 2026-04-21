using AppLogic.DTOs;
using AppLogic.UseCase;
using AppLogic.UseCaseInterface;
using BussinesLogic.Entity;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.ContextEF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    { 
        private ILoginCU _loginCU;
        private IGetUserByEmailCU _userByEmailCU;
        
        public LoginController(ILoginCU loginCU,IGetUserByEmailCU getUserByEmailCU)
        {
            _loginCU = loginCU;
            _userByEmailCU = getUserByEmailCU;   
        }

        public IActionResult Login(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string mail, string pass)
        {
            try 
            {
                if (_loginCU.Login(mail, pass))
                {
                    UserDTO usu = _userByEmailCU.EncontrarUsuarioPorMail(mail);

                    HttpContext.Session.SetString("mail", mail);

                    if (usu.isAdmin)
                    {
                        HttpContext.Session.SetString("rol", "admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("rol", "manager");
                    }

                    return RedirectToAction("Index", "Home", new { mensaje = "Bienvenido" });
                }

                return RedirectToAction("Login", new { mensaje = "Usuario o contraseña incorrectos" });
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }

        public IActionResult Desloguear() 
        {
            HttpContext.Session.Remove("mail");
            HttpContext.Session.Remove("rol");
            return RedirectToAction("Login", "Login");
        }

        

    }
}
