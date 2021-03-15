using Default_Template_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Default_Template_MVC.Services
{
    public class ServiceBase<T> : IDisposable where T : class
    {
        private readonly RepositoryBase<T> _repository;
        public ServiceBase()
        {
            this._repository = new RepositoryBase<T>();
        }
        public void Adicionar(T pObj)
        {
            this._repository.Adicionar(pObj);
        }
        public T Listar(int pId)
        {
            return
                this._repository.Listar(pId);
        }
        public T Listar(int pId, bool asNoTracking)
        {
            return
                this._repository.Listar(pId, asNoTracking);
        }
        public T Listar(int pId, int pIdUsuario, bool asNoTracking)
        {
            return
                this._repository.Listar(pId, pIdUsuario, asNoTracking);
        }
        public IEnumerable<T> Listar()
        {
            return
                this._repository.Listar();
        }

        public IEnumerable<T> Listar(bool asNoTracking)
        {
            return
                this._repository.Listar(asNoTracking);
        }
        public void Editar(T pObj)
        {
            this._repository.Editar(pObj);
        }
        public void Excluir(int pId)
        {
            this._repository.Excluir(pId);
        }
        public void Dispose()
        {
            this._repository.Dispose();
            GC.SuppressFinalize(this);
        }
        public IEnumerable<T> Paginar(IEnumerable<T> pCollection, ref int pPaginaSolicitada, ref int pQuantidadePaginas, int pQuantidadeRegistros)
        {
            try
            {
                return
                    this._repository.Paginar(pCollection, ref pPaginaSolicitada, ref pQuantidadePaginas, pQuantidadeRegistros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}