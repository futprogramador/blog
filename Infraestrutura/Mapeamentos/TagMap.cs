using Dominio.Entidades;

namespace Infraestrutura.Mapeamentos
{
    public class TagMap : EntidadeMap<Tag>
    {
        public TagMap()
            : base("id_tag")
        {
            this.Table("tag");

            this.Map(x => x.Nome).Column("tag");
        }
    }
}
