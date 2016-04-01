using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Choferes : ClaseMaestra
    {
        public int ChoferId { get; set; }
        public int AutobusId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public int AnosServicios { get; set; }
        public string Telefono { get; set; }

        public Choferes()
        {
            this.ChoferId = 0;
            this.AutobusId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Cedula = "";
            this.AnosServicios = 0;
            this.Telefono = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Choferes(AutobusId,Nombres,Apellidos,Cedula,AnosServicios,Telefono) values({0},'{1}','{2}','{3}',{4},'{5}')",
                this.AutobusId,this.Nombres,this.Apellidos,this.Cedula,this.AnosServicios,this.Telefono));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Update Choferes set AutobusId = {0}, Nombres = '{1}', Apellidos = '{2}', Cedula = '{3}', AnosServicios = {4}, Telefono = '{5}' where ChoferId = {6}",
                this.AutobusId,this.Nombres,this.Apellidos,this.Cedula,this.AnosServicios,this.Telefono,this.ChoferId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Delete from Choferes where ChoferId = {0}",this.ChoferId));

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos("Select *from Choferes where ChoferId = " + idBuscado);

            if (dt.Rows.Count > 0)
            {
                this.AutobusId = (int)dt.Rows[0]["AutobusId"];
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Cedula = dt.Rows[0]["Cedula"].ToString();
                this.AnosServicios = (int)dt.Rows[0]["AnosServicios"];
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (Orden.Equals(""))
            {
                ordenFinal = " Order by " + Orden;
            }

            return conexion.ObtenerDatos("Select " + Campos + " From Choferes Where " + Condicion + " " + ordenFinal);
        }
    }
}
