using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiInovaPP.Models.Financeiro;
using apiInovaPP.AcessoDados;
using System.Text;
using System.Data;

namespace apiInovaPP.Models.Repository
{
    public class CustoFreteRepository : ICustoFreteRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public CustoFreteRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }

        public CustoFrete Get(int idCidade)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@idCidade", idCidade);
                _PostgreSql.Parametros.AddRange(_Parametros.Params);
                sb.Append("select * from custo_frete where id_cidade = @id_cidade ");

                _PostgreSql.Script = sb.ToString();
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public CustoFrete ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            CustoFrete custo = new CustoFrete();
            try
            {
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            custo = new CustoFrete()
                            {
                                IdCidade = Convert.ToInt32(dtbResultado.Rows[0]["id_custo"].ToString()),
                                Km = Convert.ToInt32(dtbResultado.Rows[0]["km"].ToString()),
                                //IdTipoEncomenda = Convert.ToInt32(dtbResultado.Rows[0]["id_tipo_encomenda"].ToString()),
                                Custo = Convert.ToDecimal(dtbResultado.Rows[0]["custo"].ToString())
                            };
                        }
                    }
                }
                return custo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}