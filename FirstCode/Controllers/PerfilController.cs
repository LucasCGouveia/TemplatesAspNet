using Default_Template_MVC.Abstractions;
using Default_Template_MVC.Models;
using Default_Template_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Default_Template_MVC.Controllers
{
    public class PerfilController : absPaginaBase
    {
        private readonly PerfilService perfilService;
        public PerfilController()
        {
            perfilService = new PerfilService();
        }
        // GET: Perfil
        public ActionResult Index()
        {
            ViewBag.Perfil = this.perfilService.Listar();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(string descricao)
        {
            Perfil perfil = new Perfil()
            {
                Descricao = descricao
            };

            this.perfilService.Adicionar(perfil);
            return RedirectToAction("Index", "Perfil");
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Perfil = this.perfilService.Listar(id);
            return View();
        }
        [HttpPost]
        public ActionResult Editar(int id, string descricao)
        {
            Perfil perfil = this.perfilService.Listar(id);
            perfil.Descricao = descricao;

            this.perfilService.Editar(perfil);

            return RedirectToAction("Index", "Perfil");
        }
        public ActionResult Excluir(int id)
        {
            this.perfilService.Excluir(id);
            return RedirectToAction("Index", "Perfil");
        }
    }
}