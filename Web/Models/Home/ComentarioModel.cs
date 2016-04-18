using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Home
{
    public class ComentarioModel
    {
        public string Autor { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}