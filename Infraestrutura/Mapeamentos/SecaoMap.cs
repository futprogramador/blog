using Dominio.Entidades;

namespace Infraestrutura.Mapeamentos
{
    public class SecaoMap : EntidadeMap<Secao>
    {
        public SecaoMap()
            : base("id_secao")
        {
            this.Table("secao");

            this.Map(x => x.Nome).Column("nome");
            this.Map(x => x.Ativo).Column("ativo");

            this.References(x => x.SecaoPai)
                .Column("id_secao_pai")
                .Nullable();
        }
    }
}
