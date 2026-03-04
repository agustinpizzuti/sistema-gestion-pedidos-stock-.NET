using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCase.UsersCu;
using AppLogic.UseCaseInterface;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.UserException;
using BussinesLogic.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private ICreateUserCU _createUserCU;
        private IEditUserCU _editUserCU;
        private IDeleteUserCU _deleteUserCU;
        private IFindAllUsersCU _findAllUsersCU;
        private IFindUserByIDCU _findUserByIDCU;
        private IEncryptCU _encryptCU;
        
        public UserController(ICreateUserCU createUserCU,IEditUserCU editUserCU,
            IDeleteUserCU deleteUserCU, IFindAllUsersCU findAllUsersCU, 
            IFindUserByIDCU findUserByIDCU,IEncryptCU encryptCU)
        {
            _createUserCU = createUserCU;
            _editUserCU = editUserCU;
            _deleteUserCU = deleteUserCU;
            _findAllUsersCU = findAllUsersCU;
            _findUserByIDCU = findUserByIDCU;
            _encryptCU = encryptCU;
            
        }

        // GET: UserController

        public ActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;
                return View(this._findAllUsersCU.TodosLosUsuarios());
            }
            else 
            {
                return RedirectToAction("Index", "Error");
            }
           
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO usuarioDTO)
        {
            try
            {

                usuarioDTO.encrypt = _encryptCU.EncriptarContraseña(usuarioDTO.pass);

                _createUserCU.AgregarUsuarioCU(usuarioDTO);
                
                return RedirectToAction(nameof(Index));
            }
            catch(UserException ex)
            {
                return RedirectToAction("Create",new { mensaje = ex.Message });
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id,string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;

                return View(_findUserByIDCU.EncontrarUsuarioPorID(id));
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserDTO userToUpdate)
        {
            try
            {
                userToUpdate.encrypt = _encryptCU.EncriptarContraseña(userToUpdate.pass);
                _editUserCU.EditarUsuarioCU(userToUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch(UserException ex)
            {
                return RedirectToAction("Edit", new { mensaje = ex.Message });
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            try 
            {
                if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
                {
                    return View(_findUserByIDCU.EncontrarUsuarioPorID(id));
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }              
            } 
            catch 
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _deleteUserCU.EliminarUserCU(id);
           //_repoUser.Remove(id);
            return RedirectToAction(nameof(Index));      
        }
    }
}
