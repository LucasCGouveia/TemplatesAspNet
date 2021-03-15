using Default_Template_MVC.Models;
using Default_Template_MVC.Models.Procedure_Models;
using Default_Template_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Services
{
    public class UsuarioService : ServiceBase<Usuario>
    {
        private readonly UsuarioRepository usuarioRepository;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public Usuario Login(Usuario login)
        {
            Usuario usuario = usuarioRepository.Login(login);
            return usuario;
        }
        
        public GetUsuario GetUsuario(int id)
        {
            return this.usuarioRepository.GetUsuario(id);
        }
        public List<GetUsuariosList> GetUsuariosList()
        {
            return this.usuarioRepository.GetUsuariosList();
        }
    }
}