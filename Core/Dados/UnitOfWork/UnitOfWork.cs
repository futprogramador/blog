using System;
using System.Data;

using NHibernate;

namespace Core.Dados.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ITransaction _transaction;

        public ISession Session { get; private set; }

        public UnitOfWork(ISession session)
        {
            this.Session = session;
            this.Session.FlushMode = FlushMode.Auto;
            this._transaction = this.Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            this.Session.Close();
        }

        public void Commit()
        {
            if (!this._transaction.IsActive)
            {
                throw new InvalidOperationException("Sem Transação Ativa");
            }
            this._transaction.Commit();
        }

        public void Rollback()
        {
            if (this._transaction.IsActive)
            {
                this._transaction.Rollback();
            }
        }

        void IDisposable.Dispose()
        {
            this.Rollback();
        }
    }
}
