using apiInovaPP.Models;
using apiInovaPP.Models.Repository;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Net.Http;
using System.Web.Http;

namespace apiInovaPP.Controllers
{    
    public class EmpresaController : ApiController
    {
        //static readonly IHistoricoEntregaRepository _repositoryEmpresa = new EmpresaRepository();

        //[HttpGet]
        //public IHttpActionResult Get()
        //{


        //    try
        //    {
        //        var result = _repositoryEmpresa.Get();

        //        if (result != null)
        //        {
        //            return Ok(result);
        //        }
        //        else
        //        {
        //           return  NotFound();
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

        //// GET api/<controller>/5
        //[HttpGet]
        //public IHttpActionResult Get(int id)
        //{
        //    try
        //    {
        //        var result = _repositoryEmpresa.Get(id);
        //        if (result != null)
        //        {
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            return NotFound();
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

        //// GET api/<controller>/5

        //[ActionName("getnome")]
        //[HttpGet]
        //public IHttpActionResult GetByNome(string descricao)
        //{
        //    try
        //    {
        //        var result = _repositoryEmpresa.Get(descricao);
        //        if (result != null)
        //        {
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            return NotFound();
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

        // POST api/<controller>
        //[HttpPost]
        //public IHttpActionResult Post([FromBody]Empresa empresa)
        //{
        //    if (empresa == null)
        //        return BadRequest("Parametro inválido.");

        //    try
        //    {
        //        if (_repositoryEmpresa.Add(empresa))
        //        {
        //            return Created<Empresa>(Request.RequestUri + empresa.id.ToString(), empresa);
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

        // PUT api/<controller>/5
        //[HttpPut]
        //public IHttpActionResult Put([FromBody]Empresa empresa)
        //{
        //    if (empresa == null)
        //        return BadRequest("Parametro inválido.");

        //    try
        //    {
        //        if (_repositoryEmpresa.Update(empresa))
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

        // DELETE api/<controller>/5
        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    try
        //    {
        //        if (id > 0)
        //        {
        //            if (_repositoryEmpresa.Delete(id))
        //            {
        //                return Ok();
        //            }
        //            else
        //                return Conflict();
        //        }
        //        else
        //            return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //         HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        //        response.Content = new StringContent(ex.Message);
        //        response.RequestMessage = Request;
        //        return ResponseMessage(response);
        //    }
            
        //}
    }
}