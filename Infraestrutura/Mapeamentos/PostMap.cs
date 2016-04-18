using Dominio.Entidades;

namespace Infraestrutura.Mapeamentos
{
    public class PostMap : EntidadeMap<Post>
    {
        public PostMap()
            : base("id_post")
        {
            this.Table("post");

            this.Map(x => x.Titulo).Column("titulo");
            this.Map(x => x.Chamada).Column("chamada");
            this.Map(x => x.Corpo).Column("corpo");
            this.Map(x => x.Autor).Column("autor");

            HasManyToMany(x => x.Tags)
                .Table("post_tags")
                .ParentKeyColumn("id_post")
                .ChildKeyColumn("id_tag")
                .Cascade.All()
                .Access.ReadOnlyPropertyThroughCamelCaseField();

            HasManyToMany(x => x.Comentarios)
                .Table("post_comentarios")
                .ParentKeyColumn("id_post")
                .ChildKeyColumn("id_comentario")
                .Cascade.All()
                .Access.ReadOnlyPropertyThroughCamelCaseField();
        }
    }
}
