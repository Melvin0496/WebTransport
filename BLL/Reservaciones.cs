using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public class Reservaciones:ClaseMaestra
   {
        public int ReservacionId { get; set; }
        public int UsuarioId { get; set; }
        public string Lugar { get; set; }
        public int CantidadAsientos { get; set; }
        public DateTime Fecha { get; set; }
        public int esActiva { get; set; }

        public Reservaciones()
        {
            ReservacionId = 0;
            UsuarioId = 0;
            Lugar = "";
            CantidadAsientos = 0;
            Fecha = new DateTime();
            esActiva = 0;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Reservaciones(UsuarioId,Lugar,CantidadAsiento,Fecha,esActiva) values({0},'{1}',{2},'{3}',{4})",this.UsuarioId,this.Lugar,this.CantidadAsientos,this.Fecha.ToString("yyyy-MM-dd"),this.esActiva));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Update Reservaciones set UsuarioId = {0}, Lugar = '{1}', CantidadAsiento = {2}, Fecha = '{3}' esActiva = {4} where ResevacionId = {5}", this.UsuarioId, this.Lugar, this.CantidadAsientos,this.Fecha.ToString("yyyy-MM-dd"),this.esActiva,this.ReservacionId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Delete From Reservaciones where ResevacionId = {0}",this.ReservacionId));

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            

            dt = conexion.ObtenerDatos("Select * from Reservaciones Where ResevacionId = " + idBuscado);

            if (dt.Rows.Count > 0)
            {
                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.Lugar = dt.Rows[0]["Lugar"].ToString();
                this.CantidadAsientos = (int)dt.Rows[0]["CantidadAsiento"];
                this.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                this.esActiva = Convert.ToInt32(dt.Rows[0]["esActiva"]);
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (Orden.Equals(""))
            {
                ordenFinal = "Order by" + Orden;
            }

            return conexion.ObtenerDatos("Select " + Campos + "From Reservaciones where " 
                                            + Condicion + " " + ordenFinal);
        }

        public DataTable Listado(int id)
        {
            ConexionDb conexion = new ConexionDb();

            return conexion.ObtenerDatos("Select r.Lugar, r.CantidadAsiento, r.Fecha, r.esActiva, u.Nombres from Reservaciones r inner join Usuarios u on r.UsuarioId = u.UsuarioId where u.UsuarioId = " + id);
        }
    }
}
