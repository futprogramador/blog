using System.Collections.Generic;

namespace Web.Models.Home
{
    public class HomeModel
    {
        public IList<ChamadaModel> Chamadas { get; set; }

        public HomeModel()
        {
            this.Chamadas = new List<ChamadaModel>();
        }
    }
}