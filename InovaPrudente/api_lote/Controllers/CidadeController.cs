using System;
using System.Collections.Generic;
using System.Web.Http;
using apiInovaPP.Models;
using apiInovaPP.Models.Repository.Interface;
using apiInovaPP.Models.Repository;

namespace apiInovaPP.Controllers
{
    public class CidadeController : ApiController
    {
        static readonly ICidadeRepository _repositoryCidade = new CidadeRepository();
                
        [HttpGet]
        public IEnumerable<Cidade> Get()
        {
            try
            {
                return _repositoryCidade.Get();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [ActionName("cidade")]
        [HttpGet]
        public IEnumerable<Cidade> Get(string descricao)
        {
            try
            {
                return _repositoryCidade.Get(descricao);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [ActionName("uf")]
        [HttpGet]
        public IEnumerable<Cidade> GetUf(string descricao)
        {
            try
            {
                return _repositoryCidade.GetUf(descricao);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        } 

        
        [HttpPost]
        public IHttpActionResult Add([FromBody]Cidade cidade)
        {
            if (cidade == null)
                Conflict();
            try
            {
                if (_repositoryCidade.Add(cidade))
                {
                    return Created<Cidade>(Request.RequestUri + cidade.id.ToString(), cidade);
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
        public IHttpActionResult Update([FromBody]Cidade cidade)
        {
            if (cidade == null)
                Conflict();
            try
            {
                if (_repositoryCidade.Update(cidade))
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
                    if (_repositoryCidade.Delete(_Id))
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
