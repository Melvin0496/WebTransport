using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Envios
    {
        public string Descripcion { get; set; }
        public string TipoEnvio { get; set; }
        public float Precio { get; set; }
        public string Emisor { get; set; }
        public string Receptor { get; set; }

        public Envios()
        {
            Descripcion = "";
            TipoEnvio = "";
            Precio = 0.0f;
            Emisor = "";
            Receptor = "";
        }

        public Envios(string descripcion, string tipoEnvio, float precio, string emisor, string receptor)
        {
            this.Descripcion = descripcion;
            this.TipoEnvio = tipoEnvio;
            this.Precio = precio;
            this.Emisor = emisor;
            this.Receptor = receptor;
        }
    }
}

//        public override bool Insertar()
//        {
//            bool retorno = false;
//            ConexionDb conexion = new ConexionDb();

//            retorno = conexion.Ejecutar(string.Format("Insert into Envios(ChoferId,UsuarioId,Descripcion,TipoEnvio,Precio,Emisor,Receptor,Fecha) values({0},{1},'{2}','{3}',{4},'{5}','{6}','{7}')",this.ChoferId, this.UsuarioId, this.Descripcion, this.TipoEnvio, this.Precio, this.Emisor, this.Receptor,this.Fecha));

//            return retorno;
//        }

//        public override bool Editar()
//        {
//            bool retorno = false;
//            ConexionDb conexion = new ConexionDb();

//            retorno = conexion.Ejecutar(string.Format("Update Envios set ChoferId = {0}, UsuarioId = {1}, Descripcion = '{2}', TipoEnvio = '{3}', Precio = {4}, Emisor = '{5}', Receptor = '{6}', Fecha = '{7}' where EnvioId = {8}", this.ChoferId, this.UsuarioId, this.Descripcion, this.TipoEnvio, this.Precio, this.Emisor, this.Receptor, this.Fecha));

//            return retorno;
//        }

//        public override bool Eliminar()
//        {
//            bool retorno = false;
//            ConexionDb conexion = new ConexionDb();

//            retorno = conexion.Ejecutar(string.Format("Delete from Envios where EnvioId = {0}", this.EnvioId));

//            return retorno;
//        }

//        public override bool Buscar(int idBuscado)
//        {
//            ConexionDb conexion = new ConexionDb();
//            DataTable dt = new DataTable();

//            dt = conexion.ObtenerDatos("Select * from Envios where EnvioId = " + idBuscado);

//            if (dt.Rows.Count > 0)
//            {
//                this.ChoferId = (int)dt.Rows[0]["ChoferId"];
//                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
//                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
//                this.TipoEnvio = dt.Rows[0]["TipoEnvio"].ToString();
//                this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
//                this.Emisor = dt.Rows[0]["Emisor"].ToString();
//                this.Receptor = dt.Rows[0]["Receptor"].ToString();
//                this.Fecha = dt.Rows[0]["Fecha"].ToString();
//            }

//            return dt.Rows.Count > 0;
//        }

//        public override DataTable Listado(string Campos, string Condicion, string Orden)
//        {
//            string ordenFinal = "";
//            ConexionDb conexion = new ConexionDb();

//            if (Orden.Equals(""))
//            {
//                ordenFinal = " Order by " + Orden;
//            }

//            return conexion.ObtenerDatos("Select " + Campos + " From Envios where " + Condicion + " " + ordenFinal);
//        }
//    }
//}
