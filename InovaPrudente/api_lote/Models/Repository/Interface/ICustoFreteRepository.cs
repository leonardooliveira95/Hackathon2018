using apiInovaPP.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface ICustoFreteRepository
    {
        CustoFrete Get(int idCidade);
         
    }
}