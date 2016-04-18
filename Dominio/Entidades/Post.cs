using Dominio.Base;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Post : Entidade
    {        
        private readonly IEnumerable<Tag> tags;

        private readonly IEnumerable<Comentario> comentarios;

        public Post(string titulo, string chamada, string corpo, string autor, IEnumerable<Tag> tags)
        {
            this.Titulo = titulo;
            this.Corpo = corpo;
            this.Autor = autor;
            this.tags = tags;
            this.comentarios = new List<Comentario>();
        }

        protected Post()
        {
            
        }

        public virtual string Titulo { get; set; }

        public virtual string Chamada { get; set; }

        public virtual string Corpo { get; set; }

        public virtual string Autor { get; set; }

        public virtual IEnumerable<Tag> Tags 
        {
            get
            {
                return this.tags;                
            }
        }

        public virtual IEnumerable<Comentario> Comentarios
        {
            get
            {
                return this.comentarios;
            }
        }

        public virtual Publicacao Publicacao { get; set; }        
    }
}
