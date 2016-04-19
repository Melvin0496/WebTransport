using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ConexionDb
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public ConexionDb()
        {
            //Data Source=tcp:webtrasport01.database.windows.net,1433;Initial Catalog=WebTransportDb;User ID=admin01@webtrasport01;Password=Melvin1996, 
            //Data Source = MASTER - PC\\ROOT; Initial Catalog = WebTransportDb; Integrated Security = true 
            conexion = new SqlConnection(@"Data Source=tcp:webtrasport01.database.windows.net,1433;Initial Catalog=WebTransportDb;User ID=admin01@webtrasport01;Password=Melvin1996,");
            comando = new SqlCommand();
        }
        public bool Ejecutar(String ComandoSql)
        {
            bool retorno = false;
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = ComandoSql;
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }
        public DataTable ObtenerDatos(String ComandoSql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;


            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = ComandoSql;

                adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return dt;
        }
        public Object ObtenerValor(String ComandoSql)
        {
            Object retorno = null;


            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = ComandoSql;
                retorno = comando.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return retorno;
        }
    }

}

