using System.Collections.Generic;
using System.Linq;

using Aplicacao;

using Dominio.Base;
using Dominio.Repositorios;

namespace Infraestrutura.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        private readonly INHSession session;

        public Repositorio(INHSession session)
        {
            this.session = session;
        }

        protected INHSession Session
        {
            get
            {
                return session;
            }
        }

        public IList<T> Listar(IQueryable<T> query)
        {
            return query.ToList();
        }

        public T ObterPorId(int id)
        {
            return this.session.Get<T>(id);
        }

        public T Obter(IQueryable<T> query)
        {
            return query.FirstOrDefault();
        }

        public IQueryable<T> Query()
        {
            return this.session.Query<T>();
        }

        public void Excluir(T entity)
        {
            this.session.Delete(entity);
        }

        public void Persistir(T entity)
        {
             if (!entity.Persistido)
                this.session.Insert(entity);
            else
                this.session.Update(entity);
        }
    }
}
