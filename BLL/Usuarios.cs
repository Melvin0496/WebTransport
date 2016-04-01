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
        public DateTime FechaNacimiento { get; set; }

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Email = "";
            this.Contrasena = "";
            this.TipoUsuario = 0;
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

            return conexion.ObtenerDatos("Select TipoUsuario from Usuarios where Email = '" + email +"'");
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(string.Format("Insert into Usuarios(Nombres,Apellidos,Email,Contrasena,TipoUsuario) values('{0}','{1}','{2}','{3}',{4})",this.Nombres,this.Apellidos,this.Email,this.Contrasena,this.TipoUsuario));

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Update Usuarios Set Nombres = '{0}', Apellidos = '{1}', Email = '{2}', Contrasena = '{3}', TipoUsuario = {4}, Fecha = '{5}' Where UsuarioId = {6}", this.Nombres, this.Apellidos, this.Email, this.Contrasena, this.TipoUsuario, this.FechaNacimiento, this.UsuarioId));

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Delete from Usuarios where UsuarioId = {0}",this.UsuarioId));

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
                //this.FechaNacimiento = (DateTime)dt.Rows[0]["Fecha"];
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

        public int ControlUsuario()
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            int retorno = 0;

            dt = conexion.ObtenerDatos("Select TipoUsuario from Usuarios");

            if(dt.Rows.Count > 0)
            {
                this.TipoUsuario = (int)dt.Rows[0]["TipoUsuario"];
                retorno = 1;
            }

            return retorno;

           
        }
    }
}
