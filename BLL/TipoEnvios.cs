using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class TipoEnvios:ClaseMaestra
    {
        public int TipoEnvioId { get; set; }
        public string Descripcion { get; set; }

        public TipoEnvios()
        {
            this.TipoEnvioId = 0;
            this.Descripcion = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into TipoEnvios(Descripcion) values('{0}')",this.Descripcion));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Update TipoEnvios set Descripcion = '{0}' where TipoEnvioId = {1}",this.Descripcion,this.TipoEnvioId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Delete from TipoEnvios where TipoEnvioId = {0}",this.TipoEnvioId));

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            dt = conexion.ObtenerDatos("Select * from TipoEnvios where TipoEnvioId = " + idBuscado);

            if(dt.Rows.Count > 0)
            {
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (Orden.Equals(""))
            {
                ordenFinal = "Order by" + Orden;
            }

            return conexion.ObtenerDatos("Select " + Campos + " from TipoEnvios where " + Condicion + " " + ordenFinal);
        }
    }
}
