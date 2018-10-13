using apiInovaPP.Models;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace apiInovaPP.Controllers
{
    public class TipoEncomendaController : ApiController
    {
        static readonly ITipoEncomendaRepository _repositoryTipoEncomenda = new TipoEncomendaRepository();

        [HttpGet]
        public IEnumerable<TipoEncomenda> Get()
        {
            try
            {
                return _repositoryTipoEncomenda.Get();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
