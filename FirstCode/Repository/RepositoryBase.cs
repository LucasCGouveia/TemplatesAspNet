using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Default_Template_MVC.Context;

namespace Default_Template_MVC.Repository
{
    public class RepositoryBase<T> : IDisposable where T : class
    {
        /// <summary>
        /// Contexto do Banco de Dados.
        /// </summary>
        protected Context.Context Db = new Context.Context();
        /// <summary>
        /// Método responsável por adicionar uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será salva.</param>
        public void Adicionar(T pObj)
        {
            try
            {
                Db.Set<T>().Add(pObj);
                Db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por listar uma entidade genérica no banco de dados de acordo com o Id.
        /// </summary>
        /// <param name="pId">Id da entidade.</param>
        /// <returns>Entidade correspondente ao Id passado por parâmetro.</returns>
        public T Listar(int pId)
        {
            try
            {
                var obj =
                    Db.Set<T>().Find(pId);
                if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                {
                    return obj;
                }
                throw new Exception("Nenhum registro encontrado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Listar(int pId, bool asNoTracking)
        {
            try
            {
                if (asNoTracking)
                {
                    Db.Configuration.ProxyCreationEnabled = false;
                    var obj = Db.Set<T>().Find(pId);
                    if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                    {
                        return obj;
                    }
                }
                else
                {
                    var obj = Db.Set<T>().Find(pId);
                    if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                    {
                        return obj;
                    }
                }

                throw new Exception("Nenhum registro encontrado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Listar(int pId, int pIdUsuario, bool asNoTracking)
        {
            try
            {
                if (asNoTracking)
                {
                    Db.Configuration.ProxyCreationEnabled = false;
                    var obj = Db.Set<T>().Find(pId);
                    if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                    {
                        return obj;
                    }
                }
                else
                {
                    var obj = Db.Set<T>().Find(pId);
                    if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                    {
                        return obj;
                    }
                }

                throw new Exception("Nenhum registro encontrado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método responsável por retornar uma lista de entidade genérica.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<T> Listar()
        {
            try
            {
                return
                    Db.Set<T>().ToList().Where(x => !((DateTime?)x.GetType().GetProperty("DataExclusao").GetValue(x)).HasValue).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método responsável por retornar uma lista de entidade genérica com .
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<T> Listar(bool asNoTracking)
        {
            try
            {
                if (asNoTracking)
                {
                    Db.Configuration.ProxyCreationEnabled = false;
                    return Db.Set<T>().AsNoTracking().ToList().Where(x => !((DateTime?)x.GetType().GetProperty("DataExclusao").GetValue(x)).HasValue).ToList();
                }
                else
                {
                    return Db.Set<T>().ToList().Where(x => !((DateTime?)x.GetType().GetProperty("DataExclusao").GetValue(x)).HasValue).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por editar uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será editada.</param>
        public void Editar(T pObj)
        {
            try
            {
                Db.Entry(pObj).State = EntityState.Modified;
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por excluir uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será excluída.</param>
        public void Excluir(int pId)
        {
            try
            {
                var pObj = this.Listar(pId);
                pObj.GetType().GetProperty("DataExclusao").SetValue(pObj, DateTime.Now);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por listar somente os registros ativos.
        /// </summary>
        /// <param name="source">Lista com todos os registros.</param>
        /// <returns>Lista de registros ativos.</returns>
        protected IEnumerable<T> GetAtivos(IEnumerable<T> source)
        {
            try
            {
                return
                   source.Where(x => !((DateTime?)x.GetType().GetProperty("DataExclusao").GetValue(x)).HasValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método responsável por realizar a paginação.
        /// </summary>
        /// <param name="pCollection">Collection que será paginada.</param>
        /// <param name="pPaginaSolicitada">Página solicitada.</param>
        /// <param name="pQuantidadePaginas">Quantidade de páginas.</param>
        /// <param name="pQuantidadeRegistros">Quantidade de registros.</param>
        /// <returns>Collection paginada.</returns>
        public IEnumerable<T> Paginar(IEnumerable<T> pCollection, ref int pPaginaSolicitada, ref int pQuantidadePaginas, int pQuantidadeRegistros)
        {
            try
            {

                double pQuantidadePaginasComPrecisao = (double)pCollection.Count() / (double)pQuantidadeRegistros;
                pQuantidadePaginas = pCollection.Count() / pQuantidadeRegistros;
                if (pQuantidadePaginas < pQuantidadePaginasComPrecisao)
                {
                    pQuantidadePaginas++;
                }

                if (pPaginaSolicitada <= 0)
                {
                    pPaginaSolicitada = 1;
                }
                else if (pPaginaSolicitada > pQuantidadePaginas)
                {
                    pPaginaSolicitada = pQuantidadePaginas;
                }

                var lstRetorno = pCollection.Skip((pPaginaSolicitada - 1) * pQuantidadeRegistros)
                                            .Take(pQuantidadeRegistros)
                                            .AsParallel()
                                            .ToList();
                return
                    lstRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por dar dispose na instância da classe.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.Db.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por retornar uma lista de entidade genérica.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<T> ListarTudo()
        {
            try
            {
                return Db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}