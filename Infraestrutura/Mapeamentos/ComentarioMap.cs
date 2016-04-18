using Dominio.Entidades;

namespace Infraestrutura.Mapeamentos
{
    public class ComentarioMap : EntidadeMap<Comentario>
    {
        public ComentarioMap()
            : base("id_comentario")
        {
            this.Table("comentario");

            this.Map(x => x.DescricaoComentario).Column("descricao_comentario");
            this.Map(x => x.EmailAutor).Column("email_autor");
            this.Map(x => x.Autor).Column("autor");
            this.Map(x => x.Ativo).Column("ativo");

            this.References(x => x.ComentarioReferencia)
                .Column("id_comentario_referencia")
                .Nullable();
        }
    }
}
