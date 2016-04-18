using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Servicos.Dto;

namespace Servicos.Contratos
{
    public interface IPostFacade
    {
        IEnumerable<ChamadaDto> ObterChamadas();

        PostDto ObterPostPorId(int id);

        IList<SecaoDto> ObterSecoes();

    }
}
