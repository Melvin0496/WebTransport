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
                EliminarButton.Enabled = false;
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
            usuarios.Email = REmailTextBox.Text;
            usuarios.Contrasena = RContrasenaTextBox.Text;
            usuarios.FechaNacimiento = FechaDeNacimientoTextBox.Text;

            if (TipoUsuarioDropDownList.SelectedIndex == 0)
            {
                usuarios.TipoUsuario = 0;
            }
            else
            {
                usuarios.TipoUsuario = 1;
            }

        }

        public void DevolverDatos(Usuarios usuario)
        {
            NombresTextBox.Text = usuario.Nombres;
            ApellidosTextBox.Text = usuario.Apellidos;
            REmailTextBox.Text = usuario.Email;
            RContrasenaTextBox.Text = usuario.Contrasena;

            if (usuario.TipoUsuario == 0)
            {
                TipoUsuarioDropDownList.SelectedIndex = 0;
            }
            else
            {
                TipoUsuarioDropDownList.SelectedIndex = 1;
            }

        }

        public void Limpiar()
        {
            UsuarioIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            REmailTextBox.Text = string.Empty;
            RContrasenaTextBox.Text = string.Empty;
            TipoUsuarioDropDownList.SelectedIndex = 0;
            EliminarButton.Enabled = false;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();


            if (UsuarioIdTextBox.Text.Length == 0)
            {
                LlenarCampos(usuario);
                if (usuario.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
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
                if (usuario.UsuarioId > 0)
                {
                    if (usuario.Buscar(usuario.UsuarioId))
                    {
                        LlenarCampos(usuario);
                        if (usuario.Editar())
                        {
                            Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                            Limpiar();
                        }
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('No se pudo editar...ID incorrecto')</SCRIPT>");
                        Limpiar();
                    }
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (UsuarioIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                if (usuario.Buscar(Utilitarios.ToInt(UsuarioIdTextBox.Text)))
                {
                    DevolverDatos(usuario);
                    EliminarButton.Enabled = true;
                }
                else
                {
                    Response.Write("<SCRIPT>alert('ID incorrecto')</SCRIPT>");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();

            if (UsuarioIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                usuarios.UsuarioId = Utilitarios.ToInt(UsuarioIdTextBox.Text);
                if (usuarios.UsuarioId > 0)
                {
                    if (usuarios.Buscar(usuarios.UsuarioId))
                    {
                        usuarios.Eliminar();
                        Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('ID incorrecto')</SCRIPT>");
                        Limpiar();
                    }
                }
                else
                {
                    Utilitarios.ShowToastr(this, "ID no encontrado", "Error", "Danger");
                }
            }
        }
    }
}