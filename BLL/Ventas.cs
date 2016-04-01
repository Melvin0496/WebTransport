using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VentaId { get; set; }
        public int ChoferId { get; set; }
        public string Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int AutobusId { get; set; }
        public float Total { get; set; }
        public List<Envios> Envio { get; set; }
        public List<Pasajeros> Pasajero { get; set; }

        public Ventas()
        {
            this.VentaId = 0;
            this.ChoferId = 0;
            this.Fecha = "";
            this.UsuarioId = 1;
            this.AutobusId = 0;
            this.Total = 0.0f;
            this.Envio = new List<Envios>();
            this.Pasajero = new List<Pasajeros>();
        }

        public void AgregarEnvios(string descripcion, string tipoEnvio, float precio, string emisor, string receptor)
        {
            this.Envio.Add(new Envios(descripcion, tipoEnvio, precio, emisor, receptor));
        }

        public void AgregarPasajeros(int pasajeroId)
        {
            this.Pasajero.Add(new Pasajeros(pasajeroId));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            ConexionDb conexion = new ConexionDb();
            object identity;
            try
            {

                identity = conexion.ObtenerValor(
                    string.Format("Insert Into Ventas(ChoferId,Fecha,UsuarioId,AutobusId,Total) values({0},'{1}',{2},{3},{4}) select @@Identity"
                    , this.ChoferId, this.Fecha, this.UsuarioId, this.AutobusId, this.Total));


                int.TryParse(identity.ToString(), out retorno);

                this.VentaId = retorno;
                foreach (Envios item in this.Envio)
                {
                    conexion.Ejecutar(string.Format("Insert into EnviosDetalle(VentaId,Descripcion,TipoEnvio,Precio,Emisor,Receptor) Values ({0},'{1}','{2}',{3},'{4}','{5}')",
                        retorno,item.Descripcion,item.TipoEnvio,(float)item.Precio,item.Emisor,item.Receptor));
                }

                foreach (Pasajeros item in this.Pasajero)
                {
                    conexion.Ejecutar(string.Format("Insert into PasajerosDetalle(VentaId,PasajeroId) values({0},{1})", retorno, item.PasajeroId));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            try
            {
                retorno = conexion.Ejecutar(string.Format("Update Ventas set ChoferId = {0}, Fecha = {1}, UsuarioId = {2}, AutobusId = {3}, Total = {4} where VentaId = {5}",this.ChoferId,this.Fecha,this.UsuarioId,this.AutobusId,this.Total,this.VentaId));
                if (retorno)
                {
                    conexion.Ejecutar("Delete from EnviosDetalle Where VentaId=" + this.VentaId.ToString());
                    foreach (Envios item in this.Envio)
                    {
                        conexion.Ejecutar(string.Format("Insert into EnviosDetalle(VentaId,Descripcion,TipoEnvio,Precio,Emisor,Receptor) Values ({0},'{1}','{2}',{3},'{4}','{5}')",
                            retorno, item.Descripcion, item.TipoEnvio, (float)item.Precio, item.Emisor, item.Receptor));
                    }

                    conexion.Ejecutar("Delete from PasajerosDetalle where VentaId = " + this.VentaId.ToString());
                    foreach (Pasajeros item in this.Pasajero)
                    {
                        conexion.Ejecutar(string.Format("Insert into PasajerosDetalle(VentaId,PasajeroId) values({0},{1})", retorno, item.PasajeroId));
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retono = false;

            try
            {
                retono = conexion.Ejecutar("Delete from EnviosDetalle where VentaId = " + this.VentaId + ";"
                                            +"Delete from PasajerosDetalle where VentaId = " + this.VentaId + ";"
                                            + "Delete from Ventas where VentaId = " + this.VentaId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retono;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtVentaDetalle = new DataTable();

            dt = conexion.ObtenerDatos("Select * from Ventas where VentaId = " + idBuscado);

            if (dt.Rows.Count > 0)
            {
                this.ChoferId = (int)dt.Rows[0]["ChoferId"];
                this.Fecha = dt.Rows[0]["Fecha"].ToString();
                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.AutobusId = (int)dt.Rows[0]["AutobusId"];
                this.Total = Convert.ToSingle(dt.Rows[0]["Total"]);

                dtVentaDetalle = conexion.ObtenerDatos("Select vd.Descripcion,vd.TipoEnvio,vd.Precio,vd.Emisor,vd.Receptor from Ventas v inner join EnviosDetalle vd on v.VentaId = vd.VentaId where v.VentaId = " + idBuscado);

                this.Envio.Clear();
                foreach (DataRow item in dtVentaDetalle.Rows)
                {
                    this.AgregarEnvios(item["Descripcion"].ToString(),item["TipoEnvio"].ToString(),Convert.ToSingle(item["Precio"]),item["Emisor"].ToString(),item["Receptor"].ToString());
                }
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

            return conexion.ObtenerDatos("Select " + Campos + "from Ventas where " + Condicion + " " + ordenFinal);
        }
    }
}
