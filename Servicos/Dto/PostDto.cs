using System;
using System.Collections.Generic;

using Servicos.Base;

namespace Servicos.Dto
{
    public class PostDto : BaseDto
    {
        public string Titulo { get; set; }

        public string Corpo { get; set; }

        public string Autor { get; set; }

        public string PostadoEm { get; set; }

        public IList<string> Tags { get; set; }

        public IList<ComentarioDto> Comentarios { get; set; }
    }
}
