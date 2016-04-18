using Servicos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Home;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostFacade postFacade;

        public HomeController(IPostFacade postFacade)
        {
            this.postFacade = postFacade;
        }

        public ActionResult Index()
        {
            var chamadas = postFacade.ObterChamadas();

            var homeModel = new HomeModel();

            foreach (var chamada in chamadas)
            {
                homeModel.Chamadas.Add(new ChamadaModel
                {
                    Id = chamada.Id,
                    Titulo = chamada.Titulo,
                    Autor = chamada.Autor,
                    Chamada = chamada.Chamada,
                    DataCriacaoPorExtenso = chamada.DataCriacaoPorExtenso,
                    Url = chamada.Url
                });
            }

            return View(homeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Artigo(int id)
        {
            var post = this.postFacade.ObterPostPorId(id);
            
            var postModel = new PostModel()
            {
                Id = post.Id,
                Autor = post.Autor,
                Titulo = post.Titulo,
                Corpo = post.Corpo,
                PostadoEm = post.PostadoEm,
                Tags = post.Tags,
                Comentarios = post.Comentarios.Select(x => new ComentarioModel { Autor = x.Autor, Data = x.Data, Descricao = x.Descricao }).ToList()
            };

            return View(postModel);
        }
    }
}