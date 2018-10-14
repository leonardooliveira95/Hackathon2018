using apiInovaPP.AcessoDados;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using apiInovaPP.Models;
using apiInovaPP.Models.Entrega;

namespace apiInovaPP.Models.Repository
{
    public class HistoricoEntregaRepository:IHistoricoEntregaRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public HistoricoEntregaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }     
        public IEnumerable<Historico> Get(int IdEntrega)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@id_entrega", IdEntrega);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                _PostgreSql.Script = "select * from historico_entrega where id_entrega = @IdEntrega ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Historico> Get(string CodigoRastreio)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@codigo_rastreio", CodigoRastreio);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                _PostgreSql.Script = "select * from historico_entrega where codigo_rastreio = @codigo_rastreio ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(IEnumerable<Historico> historico)
        {
            try
            {
                
                _PostgreSql.Script = "insert into historico_entrega (id_entrega, data_hist, msg_historico) values (@id_entrega, @data_hist,@msg_historico)";

                
                historico.ToList<Historico>().ForEach(hist =>
                {
                    if (hist.Id_Historico == 0)
                    {
                        _PostgreSql.Parametros.Clear();
                        _Parametros.Add("@data_hist", hist.Data_Historico);
                        _Parametros.Add("@msg_historico", hist.Mensagem);
                        _Parametros.Add("@id_entrega", hist.IdEntrega);


                        _PostgreSql.Parametros.AddRange(_Parametros.Params);

                        if (!_PostgreSql.ExecuteNonQuery())
                        {
                            throw new Exception("Erro: " + _PostgreSql.msg);
                        }
                    }                 
                }

                );       
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public IEnumerable<Historico> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            List<Historico> lstHistorico = new List<Historico>();
            try
            {
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstHistorico = (from historico in dtbResultado.AsEnumerable()
                                            select new Historico()
                                            {
                                                IdEntrega = Convert.ToInt32(historico["id_entrega"].ToString()),
                                                Id_Historico = Convert.ToInt32(historico["id_historico"].ToString()),
                                                Mensagem = historico["msg_historico"].ToString(),
                                                Data_Historico = Convert.ToDateTime(historico["data_hist"].ToString())                                 

                                            }
                                          ).ToList<Historico>();
                        }
                    }
                }


                return lstHistorico.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }     
    }
}