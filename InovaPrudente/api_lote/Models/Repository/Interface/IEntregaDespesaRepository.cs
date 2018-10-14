using apiInovaPP.Models.Entrega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface IEntregaDespesaRepository
    {
        bool Add(IEnumerable<EntregaDespesa> entregaDespesa);
    }
}
