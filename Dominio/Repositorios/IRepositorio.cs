using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dominio.Repositorios
{
    public interface IRepositorio<T> where T : IEntidade
    {
        IList<T> Listar(IQueryable<T> query);
        T ObterPorId(int id);
        T Obter(IQueryable<T> query);
        
        IQueryable<T> Query();        
        void Excluir(T entity);
        void Persistir(T entity);
    }
}
