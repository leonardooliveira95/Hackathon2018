using apiInovaPP.Models.Entrega;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiInovaPP.Controllers
{
    public class TipoEntregaController : ApiController
    {
        static readonly ITipoEntregaRepository _repositoryTipoEntrega = new TipoEntregaRepository();

        [HttpGet]
        public IEnumerable<TipoEntrega> Get()
        {
            try
            {
                return _repositoryTipoEntrega.Get();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]TipoEntrega tipoEntrega)
        {
            if (tipoEntrega == null)
                Conflict();
            try
            {
                if (_repositoryTipoEntrega.Add(tipoEntrega))
                {
                    return Created<TipoEntrega>(Request.RequestUri + tipoEntrega.IdTipoEntrega.ToString(), tipoEntrega);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]TipoEntrega tipoEntrega)
        {
            if (tipoEntrega == null)
                Conflict();
            try
            {
                if (_repositoryTipoEntrega.Update(tipoEntrega))
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IHttpActionResult Delete(int _Id)
        {
            try
            {
                if (_Id > 0)
                {
                    if (_repositoryTipoEntrega.Delete(_Id))
                    {
                        return Ok();
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
