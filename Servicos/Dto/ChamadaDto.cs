using System;
using Servicos.Base;

namespace Servicos.Dto
{
    public class ChamadaDto : BaseDto
    {
        public string Titulo { get; set; }

        public string Chamada { get; set; }

        public string Url { get; set; }

        public string Autor { get; set; }

        public string DataCriacaoPorExtenso { get; set; }
    }
}
