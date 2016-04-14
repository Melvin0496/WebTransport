using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LlenarDatos(Usuarios usuario)
        {
            usuario.Nombres = NombresTextBox.Text;
            usuario.Apellidos = ApellidosTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Contrasena = PasswordTextBox.Text;
            usuario.TipoUsuario = 1;
            //usuario.FechaNacimiento = DateTime.Now;
        }

        public void Limpiar()
        {
            NombresTextBox.Text = String.Empty;
            ApellidosTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            PasswordTextBox.Text = String.Empty;
            ComfirmPasswordTextBox.Text = String.Empty;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (PasswordTextBox.Text == ComfirmPasswordTextBox.Text)
            {
                if (NombresTextBox.Text == string.Empty || ApellidosTextBox.Text == string.Empty || EmailTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || ComfirmPasswordTextBox.Text == string.Empty)
                {
                    Utilitarios.ShowToastr(this, "Debe llenar todos los campos", "Alerta", "Warning");
                }
                else
                {
                    LlenarDatos(usuario);

                    if (usuario.Insertar())
                    {
                        Utilitarios.ShowToastr(this, "Registrado correctamente", "Mensaje", "Success");
                        Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        Utilitarios.ShowToastr(this, "Error al registrar", "Error", "Danger");
                    }
                }
            }
            else
            {
                Utilitarios.ShowToastr(this, "Las contraseñas no coinciden", "Alerta", "warning");
            }
        }

        protected void CancelarButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}