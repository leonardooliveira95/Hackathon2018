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
    public class TipoEntregaRepository:ITipoEntregaRepository
    {
        PostgreSql _PostgreSql; 
        Parametros _Parametros;
        public TipoEntregaRepository()
        {
            _PostgreSql = new PostgreSql();
            _Parametros = new Parametros();
        }
        public IEnumerable<TipoEntrega> Get()
        {
            try
            {
                _PostgreSql.Script = "select * from tipo_entrega order by desc_entrega ";
                return ExecutarConsulta(_PostgreSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Add(TipoEntrega _TipoEntrega)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@IdTipoEntrega", _TipoEntrega.IdTipoEntrega);
                _Parametros.Add("@DescricaoTipoEntrega", _TipoEntrega.DescricaoTipoEntrega);
                _PostgreSql.Script = "insert into tipo_entrega (id_tipo_entrega, desc_entrega) values(@IdTipoEntrega, @DescricaoTipoEntrega)";

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

        public bool Update(TipoEntrega _TipoEntrega)
        {
            try
            {
                _Parametros.Params.Clear();
                _PostgreSql.Parametros.Clear();
                _Parametros.Add("@id_TipoEntrega", _TipoEntrega.IdTipoEntrega);
                _Parametros.Add("@desc_TipoEntrega", _TipoEntrega.DescricaoTipoEntrega);

                _PostgreSql.Script = "update tipo_entrega set desc_entrega = @desc_TipoEntrega where id_tipo_entrega = @id_TipoEntrega";

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
                _Parametros.Add("@id_TipoEntrega", _Id);
                _PostgreSql.Script = "delete from tipo_entrega where id_tipo_entrega = @id_TipoEntrega";
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

        public IEnumerable<TipoEntrega> ExecutarConsulta(PostgreSql _PostgreSql)
        {
            DataTable dtbResultado;
            try
            {
                List<TipoEntrega> lstTipoEntregas = new List<TipoEntrega>();
                if (_PostgreSql.ExecuteQuery(out dtbResultado))
                {
                    if (dtbResultado != null)
                    {
                        if (dtbResultado.Rows.Count > 0)
                        {
                            lstTipoEntregas = (from TipoEntrega in dtbResultado.AsEnumerable()
                                          select new TipoEntrega(int.Parse(TipoEntrega["id_tipo_entrega"].ToString()), TipoEntrega["desc_entrega"].ToString())).ToList<TipoEntrega>();
                        }
                    }
                }
                return lstTipoEntregas.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}