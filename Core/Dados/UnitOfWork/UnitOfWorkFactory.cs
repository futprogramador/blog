using NHibernate;

namespace Core.Dados.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISession _session;

        public UnitOfWorkFactory(ISession session)
        {
            this._session = session;
        }

        public IUnitOfWork CriarNova()
        {
            return new UnitOfWork(this._session);
        }
    }
}
