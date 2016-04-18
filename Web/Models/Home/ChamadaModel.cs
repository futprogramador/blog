using System;

namespace Web.Models.Home
{
    public class ChamadaModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Chamada { get; set; }

        public string Url { get; set; }

        public string Autor { get; set; }

        public string DataCriacaoPorExtenso { get; set; }        
    }
}