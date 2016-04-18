using System;
using System.Collections.Generic;
using System.Linq;

using Dominio.Entidades;
using Dominio.Repositorios;

using Servicos.Dto;
using System.Globalization;

namespace Servicos.Contratos.Impl
{
    public class PostFacade : IPostFacade
    {
        private readonly IRepositorio<Publicacao> repositorioPublicacao;
        private readonly IRepositorio<Secao> repositorioSecao;

        public PostFacade(IRepositorio<Publicacao> repositorioPublicacao, IRepositorio<Secao> repositorioSecao)
        {
            this.repositorioPublicacao = repositorioPublicacao;
            this.repositorioSecao = repositorioSecao;
        }

        public IEnumerable<ChamadaDto> ObterChamadas()
        {
            var chamadas = new List<ChamadaDto>();

            var query = this.repositorioPublicacao.Query();
            query = query.Where(
                x => x.Ativo 
                  && x.DataCriacao >= DateTime.Now.AddMonths(-1) 
                  && x.ExpiraEm >= DateTime.Now);

            var publicacoes = this.repositorioPublicacao.Listar(query).OrderByDescending(x => x.DataCriacao).ToList();

            foreach (var publicacao in publicacoes)
            {
                chamadas.Add(new ChamadaDto()
                                 {
                                     Id = publicacao.Post.Id,
                                     Titulo = publicacao.Post.Titulo,
                                     Chamada = publicacao.Post.Chamada,
                                     Autor = publicacao.Post.Autor,
                                     DataCriacaoPorExtenso = ObterDataPorExtenso(publicacao.DataCriacao),
                                     Url = publicacao.Post.Titulo
                                 });
            }

            return chamadas;
        }

        private string ObterDataPorExtenso(DateTime dataCriacao)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            return  dia + " de " + mes + " de " + ano;
        }

        public PostDto ObterPostPorId(int id)
        {
            var publicacao = this.repositorioPublicacao.Obter(this.repositorioPublicacao.Query().Where(x => x.Post.Id == id));

            if (publicacao == null)
            {
                return new PostDto()
                           {
                               Titulo = "Ops!",
                               Corpo = "Por algum motivo não encontramos o conteudo que você está procurando!"
                           };
            }

            var post = new PostDto()
                       {
                           Id = publicacao.Post.Id,
                           Autor = publicacao.Post.Autor,
                           Titulo = publicacao.Post.Titulo,
                           Corpo = publicacao.Post.Corpo,
                           PostadoEm = ObterDataPorExtenso(publicacao.DataCriacao),
                           Tags = publicacao.Post.Tags.Select(x => x.Nome).Distinct().ToList(),
                           Comentarios = publicacao.Post.Comentarios.Where(z => z.Ativo).Select(x => new ComentarioDto()
                                                                                     {
                                                                                         Autor = x.Autor,
                                                                                         Descricao = x.DescricaoComentario,
                                                                                         Data = x.DataCriacao
                                                                                     }).ToList()
                       };
            
            return post;
        }

        public IList<SecaoDto> ObterSecoes()
        {
            return this.repositorioSecao.Listar(this.repositorioSecao.Query().Where(x => x.Ativo)).Select(x => new SecaoDto()
                                                                                                                   {
                                                                                                                       Id = x.Id,
                                                                                                                       Nome = x.Nome
                                                                                                                   }).ToList();
        }
    }
}
