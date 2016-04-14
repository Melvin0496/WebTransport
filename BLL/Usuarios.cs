using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int TipoUsuario { get; set; }
        public string FechaNacimiento { get; set; }

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Email = "";
            this.Contrasena = "";
            this.TipoUsuario = 0;
            this.FechaNacimiento = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }
        public bool Accder()
        {
            ConexionDb conexion = new ConexionDb();
            if (conexion.ObtenerDatos(string.Format("Select *from Usuarios where Email = '{0}' and Contrasena = '{1}'", this.Email, this.Contrasena)).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable ValidarUsuario(string email)
        {
            ConexionDb conexion = new ConexionDb();

            return conexion.ObtenerDatos("Select TipoUsuario from Usuarios where Email = '" + email + "'");
        }

        public DataTable ObtenerUsuario(string email)
        {
            ConexionDb conexion = new ConexionDb();

            return conexion.ObtenerDatos("Select UsuarioId from Usuarios where Email = '" + email + "'");
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Usuarios(Nombres,Apellidos,Email,Contrasena,TipoUsuario,Fecha) values('{0}','{1}','{2}','{3}',{4},'{5}')",this.Nombres,this.Apellidos,this.Email,this.Contrasena,this.TipoUsuario,this.FechaNacimiento));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Update Usuarios Set Nombres = '{0}', Apellidos = '{1}', Email = '{2}', Contrasena = '{3}', TipoUsuario = {4} Where UsuarioId = {5}", this.Nombres, this.Apellidos, this.Email, this.Contrasena, this.TipoUsuario, this.UsuarioId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar("Alter table Reservaciones NOCHECK constraint ALL" + " ; " 
                                        +"Delete from Usuarios where UsuarioId = " + this.UsuarioId + " ; "
                                        + "Alter table Reservaciones CHECK constraint ALL");

            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos("Select * from Usuarios where UsuarioId = " + idBuscado);

            if(dt.Rows.Count > 0)
            {
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                this.TipoUsuario = (int)dt.Rows[0]["TipoUsuario"];
                this.FechaNacimiento = dt.Rows[0]["Fecha"].ToString();
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

            return conexion.ObtenerDatos("Select " +Campos+ " from Usuarios where " 
                                        +Condicion+ " " +Orden);
        }
    }
}
