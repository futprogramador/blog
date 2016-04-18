using Dominio.Base;

namespace Dominio.Entidades
{
    public class Secao : Entidade
    {
        public virtual string Nome { get; set; }

        public virtual bool Ativo { get; set; }

        public virtual Secao SecaoPai { get; set; }
    }
}
