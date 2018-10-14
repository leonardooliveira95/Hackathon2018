using apiInovaPP.AcessoDados;
using apiInovaPP.Models.Entrega;
using apiInovaPP.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Repository
{
    public class EntregaDespesaRepository: IEntregaDespesaRepository
    {
        PostgreSql _PostgreSql;
        Parametros _Parametros;
        public EntregaDespesaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }


        public bool Add(IEnumerable<EntregaDespesa>  entregaDespesa)
        {

            try
            {
                _PostgreSql.Script = "insert into entrega_despesa (id_entrega, data_despesa, valor) values (@id_entrega, @data_despesa,@valor)";

                entregaDespesa.ToList<EntregaDespesa>().ForEach(despesa =>
                {
                    if (despesa.Id_Edespesa == 0)
                    {
                        _PostgreSql.Parametros.Clear();
                        _Parametros.Add("@id_entrega", despesa.IdEntrega);
                        _Parametros.Add("@data_despesa", despesa.Data_Despesa);
                        _Parametros.Add("@valor", despesa.Valor);

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
    }
}