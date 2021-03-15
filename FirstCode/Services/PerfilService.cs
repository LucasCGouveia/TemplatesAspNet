using Default_Template_MVC.Models;
using Default_Template_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Services
{
    public class PerfilService : ServiceBase<Perfil>
    {
        private readonly PerfilRepository perfilRepository;
        public PerfilService()
        {
            perfilRepository = new PerfilRepository();
        }
    }
}