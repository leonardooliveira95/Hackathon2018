using apiInovaPP.Models.Entrega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface IPontoRetiradaRepository
    {
        IEnumerable<PontoRetirada> Get();
        //bool Add(PontoRetirada _PontoRetirada);
        //bool Update(PontoRetirada _PontoRetirada);
        //bool Delete(int _Id);
    }
}
