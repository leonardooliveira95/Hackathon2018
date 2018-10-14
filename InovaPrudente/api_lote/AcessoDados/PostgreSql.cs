using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;


namespace apiInovaPP.AcessoDados
{
    
    public class PostgreSql
    {


        private string strcon = "Server=pgsql.99codgo.com.br;Port=5432;User Id=99codgo1;Password=inovapp@123;Database=99codgo1;";

        public NpgsqlConnection Connection = null;
        private NpgsqlTransaction trans = null;
        public string msg = String.Empty;
        public bool Transacao { get; set; }
        public String Script { get; set; }
        public List<Parametro> Parametros { get; set; }

        public PostgreSql()
        {
            Parametros = new List<Parametro>();
            Transacao = false;
        }
        
        public bool Conectar()
        {
            try
            {
                if (Connection == null )
                    Connection = new NpgsqlConnection(strcon);

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                return Connection.State == ConnectionState.Open;
            }
            catch (NpgsqlException ex)
            {
                msg = ex.Message;
                return false;
            }
           
            
        }
        public bool Desconectar()
        {
            try
            {
                if ((Connection != null) && (Connection.State == ConnectionState.Open))
                {
                    Connection.Close();
                    Connection = null;
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            
        }
        public bool ExecuteQuery(String sql, out DataTable dt)
        {
            dt = new DataTable();
            try
            {
                Conectar();
                Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, Connection);
                Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                return true;
            }
            catch (NpgsqlException ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
        

        public bool ExecuteQuery(out DataTable dt)
        {
            dt = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(Script))
                {
                    Conectar();
                    using ( Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(Script, Connection))
                    {
                        Parametros.ForEach(x => cmd.Parameters.AddWithValue(x.Parameter.ToString(), x.Valor));
                        Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    return true;
                }
                msg = "Comando inválido.";
                return false;

            }
            catch (NpgsqlException ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (Transacao == false)
                {
                    Desconectar();
                }
                
            }
        }
        public bool ExecuteNonQuery()
        {
            try
            {
                if (!string.IsNullOrEmpty(Script))
                {
                    if (Conectar())
                    {
                        using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(Script, Connection))
                        {
                            int linhasAfetadas = 0;
                            Parametros.ForEach(x => cmd.Parameters.AddWithValue(x.Parameter.ToString(), x.Valor));
                            linhasAfetadas = cmd.ExecuteNonQuery();
                        }                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                msg = "Comando inválido.";
                return false;

            }
            catch (NpgsqlException ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (Transacao == false)
                {
                    Desconectar();
                }
            }
        }
        public bool ExecuteNonQuery(out int Id)
        {
            Id = 0;
            try
            {
                if (!string.IsNullOrEmpty(Script))
                {
                    if (Conectar())
                    {
                        using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(Script, Connection))
                        {

                            Parametros.ForEach(x => cmd.Parameters.AddWithValue(x.Parameter.ToString(), x.Valor));
                            Id = (Int32)cmd.ExecuteScalar();
                            return true;

                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                msg = "Comando inválido.";
                return false;

            }
            catch (NpgsqlException ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (Transacao == false)
                {
                    Desconectar();
                }
            }
        }

        public int Sequencial()
        {
            
            string scriptTemp = "select nextval('sequencial')";
            DataTable dt = new DataTable();
            if (ExecuteQuery(scriptTemp,out dt))
            {
                if (dt != null && dt.Rows.Count >0)
                {
                    return Int32.Parse(dt.Rows[0][0].ToString());

                }
                return -1;

            }
            else
            {                
                return -1;
            }
            
        }
       
       
    }
    
    
}
