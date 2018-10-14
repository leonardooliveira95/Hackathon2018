using apiInovaPP.AcessoDados;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace apiInovaPP.Models.Repository
{
    public class PessoaRepository: IPessoaRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        StringBuilder sbSql;
        public PessoaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
            sbSql = new StringBuilder();            
            sbSql.Append(" select p.*,t.descricao_tipo,c.nome from pessoa p ");
            sbSql.Append(" inner join cidade c on c.id_cidade = p.id_cidade ");
            sbSql.Append(" inner join tipo_pessoa t on t.id_tipo = p.id_tipo ");
        }
        public IEnumerable<Pessoa> GetAll()
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = sbSql.ToString() + " order by p.data_cad desc limit 30 ";
                return ExecutarConsulta(_PostgreSql);       
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
               
        }

        
        public Pessoa GetById(int _Id)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = sbSql.ToString() + "  where id_pessoa = @id_pessoa order by p.nome ";
                _Parametros.Add("@id_pessoa", _Id);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                return ExecutarConsulta(_PostgreSql).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }

        public IEnumerable<Pessoa> GetByNome(string tipo, string nome)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = sbSql.ToString() + " where t.id_tipo = @id_tipo and p.nome ilike(@nome) order by p.nome ";
                _Parametros.Add("@nome","%"+ nome+"%");
                _Parametros.Add("@id_tipo", tipo);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
           
        }

        public IEnumerable<Pessoa> GetByTipo(int _Tipo)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = sbSql.ToString() + " where t.id_tipo = @id_tipo order by p.data_cad desc limit 30 ";
                _Parametros.Add("@id_tipo", _Tipo);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public IEnumerable<Pessoa> GetByCpfCnpj(string _Tipo, string _CpfCnpj)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _PostgreSql.Script = sbSql.ToString()  + " where t.id_tipo = @id_tipo and CpfCnpj = @CpfCnpj order by p.nome ";
                _Parametros.Add("@CpfCnpj", _CpfCnpj);
                _Parametros.Add("@id_tipo", _Tipo);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
          
        }

        public bool Add(Pessoa pessoa)
        {
            //try
            //{
            //    StringBuilder sbSql = new StringBuilder();

            //    sbSql.Append("insert into pessoa( nome, cpfcnpj, rg, endereco, complemento, bairro, cep, fone_res, fone_cel, fone_com, id_tipo, id_cidade, data_cad, id_usuario, estado_civil, nome_conjugue)");
            //    sbSql.Append("  values(@nome, @cpfcnpj, @rg, @endereco, @complemento, @bairro, @cep, @fone_res, @fone_cel, @fone_com, @id_tipo, @id_cidade, @data_cad, @id_usuario, @estado_civil, @nome_conjugue) ");
            //    _Parametros.Params.Clear();
            //    _PostgreSql.Parametros.Clear();    

            //    _Parametros.Add("@nome", pessoa.nome);
            //    _Parametros.Add("@cpfcnpj", pessoa.cpf);
            //    _Parametros.Add("@rg", pessoa.rg);
            //    _Parametros.Add("@endereco", pessoa.endereco);
            //    _Parametros.Add("@complemento", pessoa.complemento);
            //    _Parametros.Add("@bairro", pessoa.bairro);
            //    _Parametros.Add("@cep", pessoa.cep);
            //    _Parametros.Add("@fone_res", pessoa.foneRes);
            //    _Parametros.Add("@fone_cel", pessoa.foneCel);
            //    _Parametros.Add("@fone_com", pessoa.foneCom);
            //    _Parametros.Add("@id_tipo", pessoa.tipo);
            //    _Parametros.Add("@id_cidade", pessoa.cidadeId);
            //    _Parametros.Add("@data_cad", DateTime.Now);
            //    _Parametros.Add("@id_usuario", pessoa.usuarioId);
            //    _Parametros.Add("@estado_civil", pessoa.estadoCivil);
            //    _Parametros.Add("@nome_conjugue", pessoa.nomeConjugue);

            //    _PostgreSql.Parametros.AddRange(_Parametros.Params);
            //    _PostgreSql.Script = sbSql.ToString();

            //    if (!_PostgreSql.ExecuteNonQuery())
            //    {
            //        throw new Exception("Erro: " + _PostgreSql.msg);
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            return true;
        }

        public bool Delete(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    _Parametros.Params.Clear();
                    _PostgreSql.Parametros.Clear();
                    _PostgreSql.Script = "delete from pessoa where id_pessoa = @id_pessoa ";
                    _Parametros.Add("@id_pessoa", Id);
                    _PostgreSql.Parametros.AddRange(_Parametros.Params);
                    if (!_PostgreSql.ExecuteNonQuery())
                    {
                        return false;
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Update(Pessoa pessoa)
        {
            //try
            //{
            //    StringBuilder sbSql = new StringBuilder();

            //    sbSql.Append(" UPDATE pessoa SET nome=@nome, cpfcnpj= @cpfcnpj, rg=@rg, endereco=@endereco, complemento=@complemento,  ");
            //    sbSql.Append(" bairro=@bairro, cep=@cep, fone_res=@fone_res, fone_cel=@fone_cel, fone_com=@fone_com, id_tipo=@id_tipo, id_cidade=@id_cidade, ");
            //    sbSql.Append(" estado_civil = @estado_civil, nome_conjugue = @nome_conjugue ");

            //    sbSql.Append(" where id_pessoa = @id_pessoa ");

            //    _Parametros.Params.Clear();
            //    _PostgreSql.Parametros.Clear();

            //    _Parametros.Add("@nome", pessoa.nome);
            //    _Parametros.Add("@cpfcnpj", pessoa.cpf);
            //    _Parametros.Add("@rg", pessoa.rg);
            //    _Parametros.Add("@endereco", pessoa.endereco);
            //    _Parametros.Add("@complemento", pessoa.complemento);
            //    _Parametros.Add("@bairro", pessoa.bairro);
            //    _Parametros.Add("@cep", pessoa.cep);
            //    _Parametros.Add("@fone_res", pessoa.foneRes);
            //    _Parametros.Add("@fone_cel", pessoa.foneCel);
            //    _Parametros.Add("@fone_com", pessoa.foneCom);
            //    _Parametros.Add("@id_tipo", pessoa.tipo);
            //    _Parametros.Add("@id_cidade", pessoa.cidadeId);
            //    _Parametros.Add("@id_pessoa", pessoa.id);
            //    _Parametros.Add("@estado_civil", pessoa.estadoCivil);
            //    _Parametros.Add("@nome_conjugue", pessoa.nomeConjugue);

            //     _PostgreSql.Script = sbSql.ToString();
            //     _PostgreSql.Parametros.AddRange(_Parametros.Params);

            //     if (!_PostgreSql.ExecuteNonQuery())
            //     {
            //         return false;
            //     }
            //     return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return true;
        }

        public IEnumerable<Pessoa> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            //try
            //{
            //    List<Pessoa> lstPessoa = new List<Pessoa>();
            //    DataTable dtbResultado;
            //    if (!_PostgreSql.ExecuteQuery(out dtbResultado))
            //    {
            //        throw new Exception("Ocorreu um erro ao tentar realizar a operação de consulta: " + _PostgreSql.msg);
            //    }

            //    if (dtbResultado != null)
            //    {
            //        if (dtbResultado.Rows.Count > 0)
            //        {
            //            lstPessoa = (from pessoa in dtbResultado.AsEnumerable()
            //                         select new Pessoa(
            //                                  Int32.Parse(pessoa["id_pessoa"].ToString()),
            //                                    DateTime.Parse(pessoa["Data_cad"].ToString()),
            //                                    pessoa["nome"].ToString(),
            //                                    pessoa["cpfcnpj"].ToString(),
            //                                    pessoa["rg"].ToString(),
            //                                    Int32.Parse(pessoa["id_tipo"].ToString()),
            //                                    pessoa["endereco"].ToString(),
            //                                    pessoa["complemento"].ToString(),
            //                                    pessoa["bairro"].ToString(),
            //                                    pessoa["cep"].ToString(),
            //                                    pessoa["fone_res"].ToString(),
            //                                    pessoa["fone_cel"].ToString(),
            //                                    pessoa["fone_com"].ToString(),
            //                                    Int32.Parse(pessoa["id_cidade"].ToString()),
            //                                    Int32.Parse(pessoa["id_usuario"].ToString()),
            //                                    pessoa["estado_civil"].ToString(),
            //                                    pessoa["nome_conjugue"].ToString()
            //                                    )).ToList<Pessoa>();
            //        }                 
            //    }
            //    return lstPessoa.ToArray();
            //}
            //catch (Exception ex )
            //{

            //    throw new Exception(ex.Message); 
            //}
            throw new NotImplementedException();
           
        }
    }
}