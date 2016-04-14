using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Pasajeros : ClaseMaestra
    {
        [Browsable(false)]
        public int PasajeroId { get; set; }
        public string Nombres { get; set; }

        public Pasajeros()
        {
            this.PasajeroId = 0;
            this.Nombres = "";
        }

        public Pasajeros(int pasajeroId)
        {
            this.PasajeroId = pasajeroId;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Pasajeros(Nombres) values('{0}')", this.Nombres));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Update Pasajeros set Nombres = '{0}' where PasajeroId = {1}", this.Nombres, this.PasajeroId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar("Alter table PasajerosDetalle NOCHECK constraint ALL" + " ; " 
                                        +"Delete from Pasajeros where PasajeroId = " + this.PasajeroId + " ; " 
                                        + "Alter table PasajerosDetalle CHECK constraint ALL");

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos("Select * from Pasajeros where PasajeroId = " + idBuscado);

            if (dt.Rows.Count > 0)
            {
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (Orden.Equals(""))
            {
                ordenFinal = " Order by " + Orden;
            }

            return conexion.ObtenerDatos("Select " + Campos + " from Pasajeros Where " + Condicion + " " + ordenFinal);
        }
    }
}
