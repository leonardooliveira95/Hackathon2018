using apiInovaPP.Models;
using apiInovaPP.Models.Entrega;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apiInovaPP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntregaController : ApiController
    {
        static readonly IEntregaRepository _repositoryEntregaRepository = new EntregaRepository();

        [HttpGet]
        public IHttpActionResult Get(string codigoRastreio)
        {
            try
            {
                var result = _repositoryEntregaRepository.Get(codigoRastreio);

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

        //[Route("api/CorrecaoValoresDivida/{vencimentoInicial}/{vencimentoFinal}")]
        [HttpGet]
        public IHttpActionResult Get(int idCidade, int distancia)
        {
            try
            {

                var result = _repositoryEntregaRepository.GetCalcularTrocaEndereco(idCidade, distancia);

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




        //POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Entrega entrega,  int idCidade, int distancia, string Logradouro2)
        {
            try
            {
                var result = _repositoryEntregaRepository.PostTrocarEnderecoEntrega(entrega, idCidade, distancia, Logradouro2);
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

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]Entrega entrega)
        {
            if (entrega == null)
                return BadRequest("Parametro inválido.");

            try
            {
                if (_repositoryEntregaRepository.Update(entrega))
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

                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Message);
                response.RequestMessage = Request;
                return ResponseMessage(response);
            }

        }

        //[HttpPut]
        //public IHttpActionResult Post([FromBody]Entrega entrega)
        //{
        //    if (entrega == null)
        //        return BadRequest("Parametro inválido.");

        //    try
        //    {
        //        if (_repositoryEntregaRepository.Add(entrega))
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            return Conflict();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        //        response.Content = new StringContent(ex.Message);
        //        response.RequestMessage = Request;
        //        return ResponseMessage(response);
        //    }

        //}


    }
}