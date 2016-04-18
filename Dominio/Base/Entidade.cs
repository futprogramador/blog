using System;

namespace Dominio.Base
{
    public class Entidade : IEntidade
    {
        public virtual int Id { get; set; }

        private int _versao;

        public virtual int Versao
        {
            get
            {
                return this._versao;
            }
        }

        public virtual string UsuarioCriacao { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual string UsuarioAlteracao { get; set; }

        public virtual DateTime? DataAlteracao { get; set; }

        public virtual bool Persistido
        {
            get
            {
                return this.Id > default(int);
            }
        }

        public override bool Equals(object obj)
        {
            Entidade other = obj as Entidade;
            if (other == null) return false;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (Id == 0) return base.GetHashCode();
            var stringRepresentation =
                this.GetType().FullName
                + "#" + this.Id;
            return stringRepresentation.GetHashCode();
        }
    }
}
