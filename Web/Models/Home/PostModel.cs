using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Home
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string PostadoEm { get; set; }
        public string Autor { get; set; }
        public string Corpo { get; set; }
        public IList<string> Tags { get; set; }
        public IList<ComentarioModel> Comentarios { get; set; }
    }
}
