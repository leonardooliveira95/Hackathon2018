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
    public class TipoEncomendaRepository:ITipoEncomendaRepository
    {
        PostgreSql _PostgreSql; 
        Parametros _Parametros;
        public TipoEncomendaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }
        public IEnumerable<TipoEncomenda> Get()
        {
            try
            {
                _PostgreSql.Script = "select * from tipo_encomenda order by desc_encomenda ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TipoEncomenda> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            try
            {
                List<TipoEncomenda> lstTipoEncomendas = new List<TipoEncomenda>();
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstTipoEncomendas = (from TipoEncomenda in dtbResultado.AsEnumerable()
                                          select new TipoEncomenda(int.Parse(TipoEncomenda["id_tipo_encomenda"].ToString()), TipoEncomenda["desc_encomenda"].ToString())).ToList<TipoEncomenda>();
                        }
                    }
                }
                return lstTipoEncomendas.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}