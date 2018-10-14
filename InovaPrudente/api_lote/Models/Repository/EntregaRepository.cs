using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiInovaPP.Models.Entrega;
using apiInovaPP.AcessoDados;
using System.Text;
using System.Data;

namespace apiInovaPP.Models.Repository
{
    public class EntregaRepository : IEntregaRepository
    {

        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public EntregaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }

        public bool Add(Entrega.Entrega entrega)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                sb.Append("INSERT INTO entrega(desc_entrega, nome_cliente, id_endereco, data_prevista, id_tipo_entrega, id_empresa, status, codigo_rastreio) ");
                sb.Append("	VALUES (@desc_entrega,@nome_cliente,@id_endereco,@data_prevista,@id_tipo_entrega,@id_empresa,@status,@codigo_rastreio) ");
                _Parametros.Add("@desc_entrega", entrega.Descricao);
                _Parametros.Add("@nome_cliente", entrega.Nome_Cliente);
                _Parametros.Add("@id_endereco", entrega.IdEndereco);
                _Parametros.Add("@data_prevista", entrega.DataPrevista);
                _Parametros.Add("@id_tipo_entrega", entrega.IdTipoEntrega);
                _Parametros.Add("@id_empresa", entrega.IdEmpresa);
                _Parametros.Add("@status", entrega.Status);
                _Parametros.Add("@codigo_rastreio", entrega.CodigoRastreio);                

                _PostgreSql.Script = sb.ToString();                
                _PostgreSql.Parametros.AddRange(_Parametros.Params);

                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro: " + _PostgreSql.msg);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        public Entrega.Entrega Get(string codigoRastreio)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@codigo_rastreio", codigoRastreio);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                sb.Append("SELECT e.*, hist.id_historico, hist.data_hist, hist.msg_historico from entrega e  ");
                sb.Append("left join historico_entrega hist on hist.id_entrega = e.id_entrega ");
                sb.Append(" where e.codigo_rastreio = @codigo_rastreio");
                _PostgreSql.Script = sb.ToString();
                return ExecutarConsulta(_PostgreSql).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entrega.Entrega Get(int idEntrega)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@id_entrega", idEntrega);

                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                sb.Append("SELECT e.*, hist.id_historico, hist.data_hist, hist.msg_historico from entrega e  ");
                sb.Append("left join historico_entrega hist on hist.id_entrega = e.id_entrega ");
                sb.Append(" where e.id_entrega = @id_entrega");
                _PostgreSql.Script = sb.ToString();
                return ExecutarConsulta(_PostgreSql).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Entrega.Entrega entrega)
        {
            IHistoricoEntregaRepository _repoHistorico = new HistoricoEntregaRepository();
            IEntregaDespesaRepository _repoDespesa = new EntregaDespesaRepository();

            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                sb.Append("update entrega set logradouro = @logradouro where id_entrega = @id_entrega ");       
                _Parametros.Add("@logradouro", entrega.Logradouro);
                _Parametros.Add("@id_entrega", entrega.Id_Entrega);

                _PostgreSql.Script = sb.ToString();
                _PostgreSql.Parametros.AddRange(_Parametros.Params);

                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro: " + _PostgreSql.msg);
                }

                _repoHistorico.Add(entrega.Historico);
                _repoDespesa.Add(entrega.Despesas);


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }            
        }

        public bool ExtenderPrazoColeta(Entrega.Entrega entrega)
        {
            IHistoricoEntregaRepository _repoHistorico = new HistoricoEntregaRepository();
            IEntregaDespesaRepository _repoDespesa = new EntregaDespesaRepository();

            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                sb.Append("update entrega set data_prevista = @data_prevista where id_entrega = @id_entrega ");
                _Parametros.Add("@data_prevista", entrega.DataPrevista);
                _Parametros.Add("@id_entrega", entrega.Id_Entrega);

                _PostgreSql.Script = sb.ToString();
                _PostgreSql.Parametros.AddRange(_Parametros.Params);

                if (!_PostgreSql.ExecuteNonQuery())
                {
                    throw new Exception("Erro: " + _PostgreSql.msg);
                }

                Historico hist = new Historico();
                hist.Mensagem = string.Format("Alteração da data de entrega para {0}", entrega.DataPrevista);
                hist.IdEntrega = entrega.Id_Entrega;
                entrega.Historico.Add(hist);
                _repoHistorico.Add(entrega.Historico);

                //_repoDespesa.Add(entrega.Despesas);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        public string GetCalcularTrocaEndereco(int idCidade, decimal distancia)
        {
            string retValor = string.Empty;
            if (idCidade > 0 && distancia > 0)
            {
                ICustoFreteRepository _repoCustoFrete = new CustoFreteRepository();
                var custo = _repoCustoFrete.Get(idCidade);

                if (custo != null)
                {
                    distancia = distancia < 1000 ? 1 : distancia / 1000;
                     

                    retValor = (distancia * custo.Custo ).ToString();
                }
            }
            return retValor;
        }

        public bool PostTrocarEnderecoEntrega(Entrega.Entrega entrega, int idCidade, int distancia, string Logradouro)
        {            
            string custo = GetCalcularTrocaEndereco(idCidade, distancia);

            Historico historico = new Historico()
            {
                Data_Historico = DateTime.Now,
                Mensagem = string.Format("Alteração de endereço de entrega. De {0} para {1}, Custo: {2}", entrega.Id_Entrega, entrega.Logradouro, Logradouro, custo)
            };
            entrega.Historico.Add(historico);

            entrega.Logradouro = Logradouro;

            EntregaDespesa despesa = new EntregaDespesa();
            despesa.Id_Despesa = 1;
            despesa.Valor = custo;
            entrega.Despesas.Add(despesa);           

            return Update(entrega);
        }



        public IEnumerable<Entrega.Entrega> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            List<Entrega.Entrega> lstEntrega = new List<Entrega.Entrega>();
            try
            {
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            Entrega.Entrega entrega = new Entrega.Entrega() { 
                                                Id_Entrega = Convert.ToInt32(dtbResultado.Rows[0]["id_entrega"].ToString()),
                                                //IdEndereco = Convert.ToInt32(dtbResultado.Rows[0]["id_endereco"].ToString()),
                                                Nome_Cliente = dtbResultado.Rows[0]["nome_cliente"].ToString(),
                                                DataPrevista = Convert.ToDateTime(dtbResultado.Rows[0]["data_prevista"].ToString()),
                                                //IdTipoEntrega = Convert.ToInt32(dtbResultado.Rows[0]["id_tipo_entrega"].ToString()),
                                                //IdEmpresa = Convert.ToInt32(dtbResultado.Rows[0]["id_empresa"].ToString()),
                                                CodigoRastreio = dtbResultado.Rows[0]["codigo_rastreio"].ToString(),
                                                Logradouro = dtbResultado.Rows[0]["Logradouro"].ToString(),
                                                //Status = dtbResultado.Rows[0]["status"].ToString()
                            };

                            List<Entrega.Historico> lstHistorico = new List<Historico>();

                            for (int i = 0; i < dtbResultado.Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(dtbResultado.Rows[i]["id_historico"].ToString()))
                                {
                                    lstHistorico.Add(new Entrega.Historico()
                                    {
                                        Id_Historico = Convert.ToInt32(dtbResultado.Rows[0]["id_historico"].ToString()),
                                        IdEntrega = Convert.ToInt32(dtbResultado.Rows[0]["id_entrega"].ToString()),
                                        Mensagem = dtbResultado.Rows[0]["nome_cliente"].ToString(),
                                        Data_Historico = Convert.ToDateTime(dtbResultado.Rows[0]["data_prevista"].ToString())
                                    });
                                }
                            }                          
                            entrega.Historico = lstHistorico;
                            lstEntrega.Add(entrega);
                        }
                    }
                }


                return lstEntrega.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}