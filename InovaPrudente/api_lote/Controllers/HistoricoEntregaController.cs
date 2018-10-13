using apiInovaPP.Models;
using apiInovaPP.Models.Entrega;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Net.Http;
using System.Web.Http;

namespace apiInovaPP.Controllers
{    
    public class HistoricoEntregaController : ApiController
    {
        static readonly IHistoricoEntregaRepository _repositoryHistoricoEntrega = new HistoricoEntregaRepository();

   

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = _repositoryHistoricoEntrega.Get(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Message);
                response.RequestMessage = Request;
                return ResponseMessage(response);
            }
        }

        // GET api/<controller>/5

        [ActionName("getnome")]
        [HttpGet]
        public IHttpActionResult GetByNome(string descricao)
        {
            try
            {
                var result = _repositoryHistoricoEntrega.Get(descricao);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Message);
                response.RequestMessage = Request;
                return ResponseMessage(response);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Historico historico)
        {
            if (historico == null)
                return BadRequest("Parametro inválido.");

            try
            {
                if (_repositoryHistoricoEntrega.Add(historico))
                {
                    return Created<Historico>(Request.RequestUri + historico.Id_Historico.ToString(), historico);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Message);
                response.RequestMessage = Request;
                return ResponseMessage(response);
            }
          
        }

       


    }
}