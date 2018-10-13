using System;
using System.Web.Http;
using apiInovaPP.Models;
using apiInovaPP.Models.Repository.Interface;
using apiInovaPP.Models.Repository;
using apiInovaPP.Excecao;
using System.Net.Http;

namespace apiInovaPP.Controllers
{   
    public class TipoPessoaController : ApiController
    {
          
        static readonly ITipoPessoaRepository _repositoryTipoPessoa = new TipoPessoaRepository();        
        
        [HttpGet]
        public IHttpActionResult Get()
        {           
            try
            {
                var result  = _repositoryTipoPessoa.Get();
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
        
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                
                var result = _repositoryTipoPessoa.Get(id);


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
        
        [ActionName("descricao")]
        [HttpGet]
        public IHttpActionResult Get(String descricao)
        {

            try
            {
                var result = _repositoryTipoPessoa.Get(descricao);
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

        
        
        [HttpPost]
        public IHttpActionResult Post([FromBody]TipoPessoa _TipoPessoa)
        {
            if (_TipoPessoa == null)
                return Conflict();


            try
            {
                if (_repositoryTipoPessoa.Add(_TipoPessoa))
                {
                    return Created<TipoPessoa>(Request.RequestUri + _TipoPessoa.Id.ToString(), _TipoPessoa);
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

        [HttpPut]
        public IHttpActionResult Put([FromBody]TipoPessoa _TipoPessoa)
        {
            if (_TipoPessoa == null)
                return Conflict();
            try
            {
                if (_repositoryTipoPessoa.Update(_TipoPessoa))
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


        [HttpDelete]        
        public IHttpActionResult Delete(int _Id)
        {
            if (_Id > 0)
            {
                if (_repositoryTipoPessoa.Delete(_Id))
                {
                    return Ok();
                }
                else
                    return Conflict();
            }
            else
                return NotFound();
            
        }
    }
}
