using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilitarios.ToInt(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Usuarios usuario = new Usuarios();
                        if (!usuario.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            UsuarioIdTextBox.Text = Id.ToString();
                            DevolverDatos(usuario);
                        }

                    }
                }
            }
        }

        public void LlenarCampos(Usuarios usuarios)
        {
            usuarios.Nombres = NombresTextBox.Text;
            usuarios.Apellidos = ApellidosTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Contrasena = ContrasenaTextBox.Text;
            
            if(TipoUsuarioDropDownList.SelectedIndex == 0)
            {
                usuarios.TipoUsuario = 0;
            }
            if(TipoUsuarioDropDownList.SelectedIndex == 1)
            {
                usuarios.TipoUsuario = 1;
            }
            else
            {
                usuarios.TipoUsuario = 2;
            }
        }

        public void DevolverDatos(Usuarios usuario)
        {
            NombresTextBox.Text = usuario.Nombres;
            ApellidosTextBox.Text = usuario.Apellidos;
            EmailTextBox.Text = usuario.Email;
            ContrasenaTextBox.Text = usuario.Contrasena;

            if(usuario.TipoUsuario == 0)
            {
                TipoUsuarioDropDownList.SelectedIndex = 0;
            }
            if (usuario.TipoUsuario == 1)
            {
                TipoUsuarioDropDownList.SelectedIndex = 1;
            }
            else
            {
                TipoUsuarioDropDownList.SelectedIndex = 2;
            }
        }

        public void Limpiar()
        {
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ContrasenaTextBox.Text = string.Empty;
            TipoUsuarioDropDownList.SelectedIndex = 0;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            LlenarCampos(usuario);
            if(UsuarioIdTextBox.Text.Length == 0)
            {
                if (usuario.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!","Mensaje","Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al insertar", "Error", "Danger");
                }
            }
            else
            {
                usuario.UsuarioId = Utilitarios.ToInt(UsuarioIdTextBox.Text);
                if (usuario.Buscar(usuario.UsuarioId))
                {
                    usuario.Editar();
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al editar", "Error","Danger");
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if(UsuarioIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Seleccione un ID", "Alerta", "Warning");
            }
            else
            {
                if (usuario.Buscar(Utilitarios.ToInt(UsuarioIdTextBox.Text)))
                {
                    DevolverDatos(usuario);
                }
                else
                {
                    Utilitarios.ShowToastr(this,"Error al buscar","Error","Danger");
                }
            }
        }
    }
}