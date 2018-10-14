using apiInovaPP.Models.Entrega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface ITipoEncomendaRepository
    {
        IEnumerable<TipoEncomenda> Get();
        /*bool Add(TipoEncomenda _TipoEncomenda);
        bool Update(TipoEncomenda _TipoEncomenda);
        bool Delete(int _Id);*/
    }
}
