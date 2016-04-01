using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BLL;

namespace WebTransport.Registros
{
    public partial class rAutobuses : System.Web.UI.Page
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
                        Autobuses autobus = new Autobuses();
                        if (!autobus.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            AutobusIdTextBox.Text = Id.ToString();
                            DevolverDatos(autobus);
                        }

                    }
                }
            }
        }

        public void Limpiar()
        {
            AutobusIdTextBox.Text = string.Empty;
            FichaTextBox.Text = string.Empty;
            MarcaTextBox.Text = string.Empty;
            ModeloTextBox.Text = string.Empty;
            AnoTextBox.Text = string.Empty;
            CantidadPasajerosTextBox.Text = string.Empty;
            AireCheckBox.Checked = false;
        }

        public void LlenarDatos(Autobuses autobus)
        {
            autobus.Ficha = FichaTextBox.Text;
            autobus.Marca = MarcaTextBox.Text;
            autobus.Modelo = ModeloTextBox.Text;
            autobus.Ano = Utilitarios.ToInt(AnoTextBox.Text);
            autobus.CantidadPasajeros = Utilitarios.ToInt(CantidadPasajerosTextBox.Text);

            if (AireCheckBox.Checked)
            {
                autobus.Aire = 1;
            }
            else
            {
                autobus.Aire = 0;
            }
        }

        public void DevolverDatos(Autobuses autobus)
        {
            FichaTextBox.Text = autobus.Ficha;
            MarcaTextBox.Text = autobus.Marca;
            ModeloTextBox.Text = autobus.Modelo;
            AnoTextBox.Text = autobus.Ano.ToString();
            CantidadPasajerosTextBox.Text = autobus.CantidadPasajeros.ToString();

            if(autobus.Aire == 1)
            {
                AireCheckBox.Checked = true;
            }
            else
            {
                AireCheckBox.Checked = false;
            }
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Autobuses autobus = new Autobuses();

                if (AutobusIdTextBox.Text.Length == 0)
                {
                    LlenarDatos(autobus);
                    if (autobus.Insertar())
                    {
                        Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Utilitarios.ShowToastr(this, "Error al Insertar", "Error", "Danger");
                    }
                }
                else
                {
                    LlenarDatos(autobus);
                    autobus.AutobusId = Utilitarios.ToInt(AutobusIdTextBox.Text);
                    if (autobus.Editar())
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

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Autobuses autobus = new Autobuses();

            if(AutobusIdTextBox.Text.Length == 0)
            {
               Utilitarios.ShowToastr(this,"Seleccione un id","Alerta","Warning");
            }
            else
            {
                autobus.AutobusId = Utilitarios.ToInt(AutobusIdTextBox.Text);

                if (autobus.Eliminar())
                {
                    Utilitarios.ShowToastr(this, "Eliminacion completada", "Mensaje", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al eliminar", "Error", "Danger");
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Autobuses autobus = new Autobuses();

            if(AutobusIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Seleccione un id", "Alerta", "Warning");
            }
            else
            {
                if (autobus.Buscar(Utilitarios.ToInt(AutobusIdTextBox.Text)))
                {
                    DevolverDatos(autobus);
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error tratando de buscar", "Error", "Danger");
                }
                
            }
        }
    }
}