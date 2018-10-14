using apiInovaPP.Models;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apiInovaPP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PontoRetiradaController : ApiController
    {
        static readonly IPontoRetiradaRepository _repositoryPontoRetirada = new PontoRetiradaRepository();

        [HttpGet]
        public IEnumerable<PontoRetirada> Get()
        {
            try
            {
                return _repositoryPontoRetirada.Get();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }        
    }
}
