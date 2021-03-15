using Default_Template_MVC.Abstractions;
using Default_Template_MVC.Models;
using Default_Template_MVC.Repository.Utils.Cryptography;
using Default_Template_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Default_Template_MVC.Controllers
{
    public class LoginController : absPaginaBase
    {
        private readonly UsuarioService usuarioService;
        public LoginController()
        {
            usuarioService = new UsuarioService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario login = new Usuario()
                    {
                        Email = email,
                        Senha = password.Encrypt()
                    };
                    Usuario usuario = usuarioService.Login(login);
                    if (usuario != null)
                    {
                        base.SalvarCookie("IdUsuario", usuario.IdUsuario.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.Message = "Usuario ou senha inválidos.";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message(ex.Message);
                return View();
            }
        }
    }
}