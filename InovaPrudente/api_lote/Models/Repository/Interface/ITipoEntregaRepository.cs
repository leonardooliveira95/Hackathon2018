using apiInovaPP.Models.Entrega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface ITipoEntregaRepository
    {
        IEnumerable<TipoEntrega> Get();
        bool Add(TipoEntrega _TipoEntrega);
        bool Update(TipoEntrega _TipoEntrega);
        bool Delete(int _Id);
    }
}
