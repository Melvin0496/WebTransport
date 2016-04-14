using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rPasajeros : System.Web.UI.Page
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
                        Pasajeros pasajero = new Pasajeros();
                        if (!pasajero.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            PasajeroIdTextBox.Text = Id.ToString();
                            DevolverDatos(pasajero);
                        }

                    }
                }
            }
        }

        public void Limpiar()
        {
            PasajeroIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            EliminarButton.Enabled = false;
        }

        public void LlenarDatos(Pasajeros pasajero)
        {
            pasajero.Nombres = NombresTextBox.Text;
        }

        public void DevolverDatos(Pasajeros pasajero)
        {
            NombresTextBox.Text = pasajero.Nombres;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Pasajeros pasajeros = new Pasajeros();


            if (PasajeroIdTextBox.Text.Length == 0)
            {
                LlenarDatos(pasajeros);
                if (pasajeros.Insertar())
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
                pasajeros.PasajeroId = Utilitarios.ToInt(PasajeroIdTextBox.Text);
                if (pasajeros.PasajeroId > 0)
                {
                    if (pasajeros.Buscar(pasajeros.PasajeroId))
                    {
                        LlenarDatos(pasajeros);
                        if (pasajeros.Editar())
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
            Pasajeros pasajero = new Pasajeros();

            if (PasajeroIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                pasajero.PasajeroId = Utilitarios.ToInt(PasajeroIdTextBox.Text);
                if (pasajero.PasajeroId > 0)
                {
                    if (pasajero.Buscar(pasajero.PasajeroId))
                    {
                        DevolverDatos(pasajero);
                        EliminarButton.Enabled = true;
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('ID no encontrado')</SCRIPT>");
                        Limpiar();
                    }
                }
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Pasajeros pasajero = new Pasajeros();

            if (PasajeroIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                pasajero.PasajeroId = Utilitarios.ToInt(PasajeroIdTextBox.Text);
                if (pasajero.PasajeroId > 0)
                {
                    if (pasajero.Buscar(pasajero.PasajeroId))
                    {
                        pasajero.Eliminar();
                        Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('ID incorrecto')</SCRIPT>");
                        Limpiar();
                    }
                }
            }
        }
    }
}