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
    public class UsuarioController : absPaginaBase
    {
        private readonly UsuarioService usuarioService;
        private readonly PerfilService perfilService;
        public UsuarioController()
        {
            usuarioService = new UsuarioService();
            perfilService = new PerfilService();
        }
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Usuario = this.usuarioService.GetUsuariosList();
            return View();
        }

        public ActionResult Novo()
        {
            ViewBag.Perfil = this.perfilService.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Novo(string nome, string email, string senha, DateTime dataNascimento, string perfil)
        {
            Usuario usuario = new Usuario()
            {
                Nome = nome,
                Email = email,
                Senha = senha.Encrypt(),
                DataNascimento = dataNascimento,
                IdPerfil = int.Parse(perfil)
            };

            usuarioService.Adicionar(usuario);

            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Editar(int id)
        {
            try
            {
                ViewBag.Perfil = this.perfilService.Listar();
                Usuario usuario = this.usuarioService.Listar(id);
                usuario.Senha = usuario.Senha.Decrypt();
                ViewBag.Usuario = usuario;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Editar(int id, string nome, string email, string senha, DateTime dataNascimento, string perfil)
        {
            Usuario usuario = usuarioService.Listar(id);
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha.Encrypt();
            usuario.DataNascimento = dataNascimento;
            usuario.IdPerfil = int.Parse(perfil);

            usuarioService.Editar(usuario);

            return RedirectToAction("Index", "Usuario");
        }


        public ActionResult Excluir(int id)
        {
            usuarioService.Excluir(id);
            return RedirectToAction("Index", "Usuario");
        }

        [HttpGet]
        public ActionResult TesteProcedure(int id)
        {
            ViewBag.Usuario = this.usuarioService.GetUsuario(id);
            return View();
        }
    }
}