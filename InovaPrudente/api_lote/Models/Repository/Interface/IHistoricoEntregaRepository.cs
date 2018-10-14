using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiInovaPP.Models.Entrega;



namespace apiInovaPP.Models.Repository.Interface
{
    public interface IHistoricoEntregaRepository
    {
        IEnumerable<Historico> Get(int IdEntrega);
        IEnumerable<Historico> Get(string CodigoRastreio);
        bool Add(IEnumerable<Historico> historico);        
        
    }
}
