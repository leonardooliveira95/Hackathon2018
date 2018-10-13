using apiInovaPP.AcessoDados;
using apiInovaPP.Excecao;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace apiInovaPP.Models.Repository
{
    public class TipoPessoaRepository : ITipoPessoaRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public TipoPessoaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }
        public IEnumerable<TipoPessoa> Get()
        {
            try
            {
                _Parametros.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = "select * from tipo_pessoa  order by descricao_tipo ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TipoPessoa Get(int id)
        {
            try
            {
                //if (id == 0)
                //{                    
                //    throw new ParametroInvalidoException(String.Format(ParametroInvalidoException.ParametroInvalido, "Id", id.ToString()));
                //}

                _Parametros.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = "select * from tipo_pessoa where id_tipo = @id_tipo ";
                _Parametros.Add("@id_tipo", id);

                return ExecutarConsulta(_PostgreSql).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TipoPessoa> Get(string descricao)
        {
            try
            {
                _Parametros.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = "select * from tipo_pessoa where descricao_tipo ilike(@descricao_tipo)";
                _Parametros.Add("@descricao_tipo","%"+ descricao+"%");
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Add(TipoPessoa _TipoPessoa)
        {

            try
            {
                _Parametros.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@descricao_tipo", _TipoPessoa.Descricao);
                _PostgreSql.Script = "insert into tipo_pessoa (descricao_tipo) values(@descricao_tipo) returning id_tipo ";
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                int id = 0;
                if (!_PostgreSql.ExecuteNonQuery(out id))
                {
                    throw new Exception("Erro:" + _PostgreSql.msg);
                }
                _TipoPessoa.Id = id;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(TipoPessoa _TipoPessoa)
        {
            try
            {
                _Parametros.Clear();
                _Parametros.Add("@descricao_tipo", _TipoPessoa.Descricao);
                _Parametros.Add("@id_tipo", _TipoPessoa.Id);
                _PostgreSql.Script = "update tipo_pessoa set descricao_tipo = @descricao_tipo where id_tipo = @id_tipo";
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Parametros.AddRange(_Parametros.Params);

                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro:" + _PostgreSql.msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int _Id)
        {
            try
            {
                if (ValidarDadosAntes(_Id))
                {
                    _PostgreSql.Parametros.Clear();
                    _Parametros.Clear();
                    _Parametros.Add("@id", _Id);
                    _PostgreSql.Script = "delete from tipo_pessoa where id_tipo =@id_tipo";
                    _PostgreSql.Parametros.AddRange(_Parametros.Params);
                    if (!_PostgreSql.ExecuteNonQuery())
                    {
                        throw new Exception("Erro:" + _PostgreSql.msg);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ValidarDadosAntes(int _id)
        {
            try
            {
                _Parametros.Clear();
                _PostgreSql.Script = "select 1 from pessoa where pes_tipo = @id";
                _Parametros.Add("@id", _id);
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Parametros.AddRange(_Parametros.Params);

                DataTable dt;
                if (!_PostgreSql.ExecuteQuery(out dt))
                {
                    if (dt != null)
                    {

                        if (dt.Rows.Count == 0)
                            return true;
                        return false;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public IEnumerable<TipoPessoa> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            List<TipoPessoa> lstTipoPessoa = new List<TipoPessoa>();
            try
            {
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstTipoPessoa = (from tipo in dtbResultado.AsEnumerable()
                                             select new TipoPessoa(Int32.Parse(tipo[0].ToString()), tipo[1].ToString())).ToList<TipoPessoa>();
                        }
                    }
                }


                return lstTipoPessoa.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}