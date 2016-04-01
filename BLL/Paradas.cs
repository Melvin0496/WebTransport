using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Paradas : ClaseMaestra
    {
        public int ParadaId { get; set; }
        public string Lugar { get; set; }
        public string Telefono { get; set; }

        public Paradas()
        {
            this.ParadaId = 0;
            this.Lugar = "";
            this.Telefono = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Paradas(Lugar,Telefono) values('{0}','{1}')",this.Lugar,this.Telefono));

            return retorno;
            
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Update Paradas Set Lugar = '{0}', Telefono = '{1}' where ParadaId = {2}",this.Lugar,this.Telefono,this.ParadaId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Delete from Paradas where ParadaId = {0}",this.ParadaId));

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos("Select * from Paradas where ParadaId = " + idBuscado);

            if(dt.Rows.Count > 0)
            {
                this.Lugar = dt.Rows[0]["Lugar"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (!Orden.Equals(""))
            {
                ordenFinal = "Orden by" + Orden;
            }

            return conexion.ObtenerDatos("Select " + Campos + " from Paradas where "
                                        + Condicion + " " + Orden);
        }
    }
}
