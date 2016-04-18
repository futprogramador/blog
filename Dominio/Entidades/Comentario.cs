using Dominio.Base;

namespace Dominio.Entidades
{
    public class Comentario : Entidade
    {
        public virtual string DescricaoComentario { get; set; }

        public virtual string Autor { get; set; }

        public virtual string EmailAutor { get; set; }

        public virtual Comentario ComentarioReferencia { get; set; }

        public virtual bool Ativo { get; set; }
    }
}
