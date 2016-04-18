using Dominio.Base;

using FluentNHibernate.Mapping;

namespace Infraestrutura.Mapeamentos
{
    public abstract class EntidadeMap<T> : ClassMap<T>
        where T : Entidade
    {
        protected EntidadeMap(string colunaId)
        {
            this.Id(x => x.Id, colunaId);

            Map(x => x.UsuarioCriacao).Column("usuario_criacao").Nullable().Not.Update();

            Map(x => x.DataCriacao).Column("dt_criacao").Not.Nullable().Not.Update();

            Map(x => x.UsuarioAlteracao).Column("usuario_alteracao").Nullable().Not.Insert();

            Map(x => x.DataAlteracao).Column("dt_alteracao").Nullable().Not.Insert();

            Version(x => x.Versao)
                .Column("versao")
                .UnsavedValue("0")
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore);

            OptimisticLock.Version();
        }
    }
}
