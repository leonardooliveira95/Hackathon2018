using apiInovaPP.AcessoDados;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Repository
{
    public class CidadeRepository:ICidadeRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public CidadeRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }
        public IEnumerable<Cidade> Get()
        {
            try
            {
                _PostgreSql.Script = "select * from cidade order by nome ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Cidade> Get(string nome)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = "select * from cidade where nome ilike (@nome) order by nome ";
                _Parametros.Add("@nome", "%"+nome+"%");
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Cidade> GetUf(string estado)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = "select * from cidade where uf = @uf order by nome ";
                _Parametros.Add("@uf", "%"+estado+"%");
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      

        public bool Add(Cidade _Cidade)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@uf", _Cidade.uf);
                _Parametros.Add("@cidade", _Cidade.nome);
                _PostgreSql.Script = "insert into cidade (nome, uf) values(@cidade,@uf)";

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

        public bool Update(Cidade _Cidade)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@id_cidade", _Cidade.id);
                _Parametros.Add("@uf", _Cidade.uf);
                _Parametros.Add("@nome", _Cidade.nome);

                _PostgreSql.Script = "update cidades set nome = @cidade , uf = @uf where id_cidade = @id_cidade";

                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro: " + _PostgreSql.msg);
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
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@id_cidade", _Id);
                _PostgreSql.Script = "delete from  cidade  where id_cidade = @id_cidade";
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro: " + _PostgreSql.msg);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Cidade> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            try
            {
                List<Cidade> lstCidades = new List<Cidade>();
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstCidades = (from cidade in dtbResultado.AsEnumerable()
                                             select new Cidade(int.Parse(cidade["id_cidade"].ToString()),cidade["nome"].ToString(),cidade["uf"].ToString())).ToList<Cidade>();
                        }
                    }
                }
                return lstCidades.ToArray();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}