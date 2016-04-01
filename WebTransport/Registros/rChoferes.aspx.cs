using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rChoferes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
                int Id;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilitarios.ToInt(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Choferes chofer = new Choferes();
                        if (!chofer.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            ChoferIdTextBox.Text = Id.ToString();
                            DevolverDatos(chofer);
                        }

                    }
                }
            }
        }

        public void LlenarDropDownList()
        {
            Autobuses autobus = new Autobuses();

            AutobusIdDropDownList.DataSource = autobus.Listado(" * ", " 1=1 ", " ");
            AutobusIdDropDownList.DataTextField = "Ficha";
            AutobusIdDropDownList.DataValueField = "AutobusId";
            AutobusIdDropDownList.DataBind();
        }

        public void Limpiar()
        {
            ChoferIdTextBox.Text = string.Empty;
            AutobusIdDropDownList.SelectedIndex = 0;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            AnoServicioTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
        }

        public void LlenarCampos(Choferes chofer)
        {
            chofer.AutobusId = Convert.ToInt32(AutobusIdDropDownList.SelectedValue);
            chofer.Nombres = NombresTextBox.Text;
            chofer.Apellidos = ApellidosTextBox.Text;
            chofer.Cedula = CedulaTextBox.Text;
            chofer.AnosServicios = Convert.ToInt32(AnoServicioTextBox.Text);
            chofer.Telefono = TelefonoTextBox.Text;
        }

        public void DevolverDatos(Choferes chofer)
        {
            AutobusIdDropDownList.SelectedValue = chofer.AutobusId.ToString();
            NombresTextBox.Text = chofer.Nombres;
            ApellidosTextBox.Text = chofer.Apellidos;
            CedulaTextBox.Text = chofer.Cedula;
            AnoServicioTextBox.Text = chofer.AnosServicios.ToString();
            TelefonoTextBox.Text = chofer.Telefono; 
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Choferes chofer = new Choferes();

            if(ChoferIdTextBox.Text.Length == 0)
            {
                LlenarCampos(chofer);
                if (chofer.Insertar())
                {
                    Utilitarios.ShowToastr(this,"Transaccion exitosa","Mensaje","Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al insertar", "Error", "Danger");
                }

            }
            else
            {
                LlenarCampos(chofer);
                chofer.ChoferId = Utilitarios.ToInt(ChoferIdTextBox.Text);
                if (chofer.Editar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa", "Mensaje", "Success");
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
            Choferes chofer = new Choferes();

            if(ChoferIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Selecciona un id", "Alerta", "Warning");
            }
            else
            {
                chofer.ChoferId =  Utilitarios.ToInt(ChoferIdTextBox.Text);
                if (chofer.Eliminar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa", "Mensaje", "Success");
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
            Choferes chofer = new Choferes();

            if (ChoferIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Selecciona un id", "Alerta", "Warning");
            }
            else
            {
                
                if (chofer.Buscar(Utilitarios.ToInt(ChoferIdTextBox.Text)))
                {
                    DevolverDatos(chofer);
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al buscar", "Error", "Danger");
                }
            }
        }
    }
}