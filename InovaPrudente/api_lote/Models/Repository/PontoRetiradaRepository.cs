using apiInovaPP.AcessoDados;
using apiInovaPP.Models.Entrega;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Repository
{
    public class PontoRetiradaRepository:IPontoRetiradaRepository
    {
        PostgreSql _PostgreSql; 
        Parametros _Parametros;
        public PontoRetiradaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }
        public IEnumerable<PontoRetirada> Get()
        {
            try
            {
                _PostgreSql.Script = "select pr.id_ponto, p.nome as nome_ponto, p.endereco || ', ' || coalesce(p.complemento,'') || ' - ' || coalesce(p.bairro,'') || ' - ' || c.nome as endereco_ponto, pr.nome_contato, te.desc_encomenda, pr.data_convenio " +
                                     "    from ponto_retirada pr "+
                                     "         join pessoa p on pr.id_pessoa = p.id_pessoa "+
                                     "         join cidade c on p.id_cidade = c.id_cidade "+
                                     "         join tipo_encomenda te on pr.id_tipo_encomenda = te.id_tipo_encomenda "+
                                     "   order by p.nome ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PontoRetirada> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            try
            {
                List<PontoRetirada> lstPontoRetiradas = new List<PontoRetirada>();
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstPontoRetiradas = (from PontoRetirada in dtbResultado.AsEnumerable()
                                          select new PontoRetirada(int.Parse(PontoRetirada["id_ponto"].ToString()), PontoRetirada["nome_ponto"].ToString(), PontoRetirada["endereco_ponto"].ToString(), PontoRetirada["desc_encomenda"].ToString(), PontoRetirada["nome_contato"].ToString(), DateTime.Parse(PontoRetirada["data_convenio"].ToString()))).ToList<PontoRetirada>();
                        }
                    }
                }
                return lstPontoRetiradas.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}