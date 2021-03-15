using Default_Template_MVC.Models;
using Default_Template_MVC.Models.Procedure_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public Usuario Login(Usuario login) 
        {
            Usuario usuario = Db.Usuario.Where(x => !x.DataExclusao.HasValue)
                                        .Where(x => x.Email == login.Email)
                                        .Where(x => x.Senha == login.Senha)
                                        .FirstOrDefault();
            return usuario;
        }
        //get User by id with procedure
        public GetUsuario GetUsuario(int id)
        {
            SqlParameter IdUsuario = new SqlParameter("@id", (object)id);

            return Db.Database.SqlQuery<GetUsuario>("exec GetUsuario @id", IdUsuario).FirstOrDefault();
        }

        //get Users with procedure
        public List<GetUsuariosList> GetUsuariosList()
        {
            return Db.Database.SqlQuery<GetUsuariosList>("exec GetUsuariosList").ToList();
        }
    }
}