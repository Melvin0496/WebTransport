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
            NombresTextBox.Text = string.Empty;
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

            LlenarDatos(pasajeros);
            if (PasajeroIdTextBox.Text.Length == 0)
            {
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
                if (pasajeros.Editar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al editar", "Error", "Danger");
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Pasajeros pasajero = new Pasajeros();

            if (PasajeroIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Seleccione un ID", "Alerta", "Warning");
            }
            else
            {
                if (pasajero.Buscar(Utilitarios.ToInt(PasajeroIdTextBox.Text)))
                {
                    DevolverDatos(pasajero);
                }
                else 
                {
                    Utilitarios.ShowToastr(this, "No existe ese ID", "Error", "Danger");
                }
            }

        }
    }
}