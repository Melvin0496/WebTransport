using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Autobuses : ClaseMaestra
    {
        public int AutobusId { get; set; }
        public string Ficha { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int CantidadPasajeros { get; set; }
        public int Aire { get; set; }

        public Autobuses()
        {
            this.AutobusId = 0;
            this.Ficha = "";
            this.Marca = "";
            this.Modelo = "";
            this.Ano = 0;
            this.CantidadPasajeros = 0;
            this.Aire = 0;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Insert into Autobuses(Ficha,Marca,Modelo,Ano,CantidadPasajeros,Aire) values('{0}','{1}','{2}',{3},{4},{5})",this.Ficha,this.Marca,this.Modelo,this.Ano,this.CantidadPasajeros,this.Aire));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Update Autobuses set Ficha = '{0}', Marca = '{1}', Modelo = '{2}', Ano = {3}, CantidadPasajeros = {4}, Aire = {5} where AutobusId = {6}", this.Ficha, this.Marca, this.Modelo, this.Ano, this.CantidadPasajeros, this.Aire,this.AutobusId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Delete from Autobuses where AutobusId = {0}",this.AutobusId));

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            dt = conexion.ObtenerDatos("Select * from Autobuses Where AutobusId = " + idBuscado);
            
            if(dt.Rows.Count > 0)
            {
                this.Ficha = dt.Rows[0]["Ficha"].ToString();
                this.Marca = dt.Rows[0]["Marca"].ToString();
                this.Modelo = dt.Rows[0]["Modelo"].ToString();
                this.Ano = (int)dt.Rows[0]["Ano"];
                this.CantidadPasajeros = (int)dt.Rows[0]["CantidadPasajeros"];
                this.Aire = Convert.ToInt32(dt.Rows[0]["Aire"]);
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

            return conexion.ObtenerDatos("Select " + Campos + " From Autobuses where " + Condicion + " " + ordenFinal); 
        }
    }
}
