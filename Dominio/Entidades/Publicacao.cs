using System;

using Dominio.Base;

namespace Dominio.Entidades
{
    public class Publicacao : Entidade
    {
        public Publicacao(Post post, Secao secao)
        {
            this.Post = post;
            this.Secao = secao;
            this.Ativo = true;
            this.ExpiraEm = DateTime.Now.AddYears(100);
        }

        protected Publicacao()
        {
            
        }

        public virtual Post Post { get; set; }

        public virtual Secao Secao { get; set; }

        public virtual bool Ativo { get; set; }

        public virtual DateTime ExpiraEm { get; set; }        
    }
}
