using System;
using System.Web.Http;
using apiInovaPP.Models;
using apiInovaPP.Models.Repository.Interface;
using apiInovaPP.Models.Repository;

namespace apiInovaPP.Controllers
{
    public class PessoaController : ApiController
    {

        static readonly IPessoaRepository _repositoryPessoa = new PessoaRepository();

        String _msgRetorno = string.Empty;

        
        [ActionName("delete")]
        [HttpPost]
        public IHttpActionResult Delete(int Id)
        {
            if (Id > 0)
            {
                if (_repositoryPessoa.Delete(Id))
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

        
        [HttpPost]
        public IHttpActionResult Post([FromBody]Pessoa pessoa)
        {
            if (pessoa==null)            
                Conflict();
            
            if (_repositoryPessoa.Add(pessoa))
            {
                return Created<Pessoa>(Request.RequestUri + pessoa.id.ToString(), pessoa);
            }
            else
            {
                return Conflict();
            }            
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]Pessoa pessoa)
        {
            if (pessoa == null)
                Conflict();


            if (_repositoryPessoa.Update(pessoa))
            {
                return Ok(); ;
            }
            else
            {
                return Conflict();
            }
        }
        #region Metodos get
        
        [HttpGet]
        public IHttpActionResult GetAllPessoa()
        {
            try
            {
                var result = _repositoryPessoa.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }
       
        [HttpGet]
        [Route("api/pessoa/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = _repositoryPessoa.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }
        
        [ActionName("getnome")]
        [HttpGet]
        [Route("api/pessoa/getnome/{campos}")]
        public IHttpActionResult GetByNome(string campos)
        {
            try
            {
                string[] camposArray = campos.Split('|');
                if (camposArray.Length < 2)
                {
                    throw new Exception("Falta de informações para realizar a pesquisa");
                }

                var result = _repositoryPessoa.GetByNome(camposArray[0], camposArray[1]);//tipopessoa|nome
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
            
        }

        [ActionName("getidtipo")]
        [HttpGet]
        [Route("api/pessoa/getidtipo/{id:int}")]
        public IHttpActionResult GetByTipo(int id)
        {
            try
            {
                var result =  _repositoryPessoa.GetByTipo(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict();
            }

        }

        [ActionName("getcpf")]
        [HttpGet]
        [Route("api/pessoa/getcpf/{campos}")]
        public IHttpActionResult GetByCpfCnpj(string campos)
        {
            try
            {
                string[] camposArray = campos.Split('|');
                var result = _repositoryPessoa.GetByCpfCnpj(camposArray[0], camposArray[1]);//tipo|cpf
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict();
            }    
        }
        #endregion
    }
}
