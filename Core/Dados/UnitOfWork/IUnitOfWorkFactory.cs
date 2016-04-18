using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

namespace Core.Dados.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CriarNova();
    }
}
