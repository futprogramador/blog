using Dominio.Entidades;

namespace Infraestrutura.Mapeamentos
{
    public class PublicacaoMap : EntidadeMap<Publicacao>
    {
        public PublicacaoMap()
            : base("id_publicacao")
        {
            this.Table("publicacao");

            this.Map(x => x.Ativo).Column("ativo");
            this.Map(x => x.ExpiraEm).Column("dthr_expiracao");

            this.References(x => x.Post).Column("id_post");

            this.References(x => x.Secao).Column("id_secao");
        }
    }
}
