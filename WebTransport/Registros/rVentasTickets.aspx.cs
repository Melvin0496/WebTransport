using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rVentasTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
            }
        }

        public void LlenarDropDownList()
        {
            Choferes chofer = new Choferes();
            Usuarios usuario = new Usuarios();
            Autobuses autobus = new Autobuses();
            Pasajeros pasajero = new Pasajeros();

            UsuarioIdDropDownList.DataSource = usuario.Listado(" * ", " 1=1 ", " ");
            UsuarioIdDropDownList.DataTextField = "Nombres";
            UsuarioIdDropDownList.DataValueField = "UsuarioId";
            UsuarioIdDropDownList.DataBind();

            ChoferIdDropDownList.DataSource = chofer.Listado(" * ", " 1=1 ", " ");
            ChoferIdDropDownList.DataTextField = "Nombres";
            ChoferIdDropDownList.DataValueField = "ChoferId";
            ChoferIdDropDownList.DataBind();

            AutobusIdDropDownList.DataSource = autobus.Listado(" * ", " 1=1 ", " ");
            AutobusIdDropDownList.DataTextField = "Ficha";
            AutobusIdDropDownList.DataValueField = "AutobusId";
            AutobusIdDropDownList.DataBind();

            NombresDropDownList.DataSource = pasajero.Listado(" * ", " 1=1 ", " ");
            NombresDropDownList.DataTextField = "Nombres";
            NombresDropDownList.DataValueField = "PasajeroId";
            NombresDropDownList.DataBind();
        }

        public void LimpiarClase()
        {
            VentaIdTextBox.Text = string.Empty;
            ChoferIdDropDownList.SelectedIndex = 0;
            FechaTextBox.Text = string.Empty;
            UsuarioIdDropDownList.SelectedIndex = 0;
            AutobusIdDropDownList.SelectedIndex = 0;
            TotalLabel.Text = string.Empty;
        }

        public void LimpiarLista()
        {
            Ventas venta = new Ventas();

            Session["Venta"] = new Ventas();
            venta.Envio.Clear();
            EnviosGridView.DataSource = null;

            Session["VentaPasajero"] = new Ventas();
            venta.Pasajero.Clear();
            PasajerosGridView.DataSource = null;
        }

        public void LimpiarEnvio()
        {
            DescripcionTextBox.Text = string.Empty;
            TipoEnvioTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            EmisorTextBox.Text = string.Empty;
            ReceptorTextBox.Text = string.Empty;
        }

        float total = 0f, vari = 0f;
        public void LlenarCampos(Ventas venta)
        {

            venta.Fecha = FechaTextBox.Text;
            venta.ChoferId = Utilitarios.ToInt(ChoferIdDropDownList.SelectedValue);
            venta.AutobusId = 0;
            venta.UsuarioId = Utilitarios.ToInt(UsuarioIdDropDownList.SelectedValue);
            venta.AutobusId = Utilitarios.ToInt(AutobusIdDropDownList.SelectedValue);

            foreach (GridViewRow row in EnviosGridView.Rows)
            {
                float.TryParse(row.Cells[2].Text, out vari);
                venta.AgregarEnvios(row.Cells[0].Text, row.Cells[1].Text, vari, row.Cells[3].Text, row.Cells[4].Text);
                total += vari;
            }

            foreach (GridViewRow row in PasajerosGridView.Rows)
            {
                venta.AgregarPasajeros(Utilitarios.ToInt(NombresDropDownList.SelectedValue));
            }

            venta.Total = total;
        }
        public void DevolverDatos(Ventas venta)
        {
            FechaTextBox.Text = venta.Fecha;
            ChoferIdDropDownList.SelectedValue = venta.ChoferId.ToString();
            UsuarioIdDropDownList.SelectedValue = venta.UsuarioId.ToString();
            AutobusIdDropDownList.SelectedValue = venta.AutobusId.ToString();

            EnviosGridView.DataSource = venta.Envio;
            EnviosGridView.DataBind();

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Ventas venta;

            if (Session["Venta"] == null)
            {
                Session["Venta"] = new Ventas();
            }

            venta = (Ventas)Session["Venta"];

            

            venta.AgregarEnvios(DescripcionTextBox.Text, TipoEnvioTextBox.Text, Utilitarios.ToFloat(PrecioTextBox.Text), EmisorTextBox.Text, ReceptorTextBox.Text);


            Session["Venta"] = venta;

            EnviosGridView.DataSource = venta.Envio;
            EnviosGridView.DataBind();

            LimpiarEnvio();
            float sust = 0;
            foreach (GridViewRow row in EnviosGridView.Rows)
            {
                float.TryParse(row.Cells[2].Text, out vari);
                TotalLabel.Text= (sust += vari).ToString();
            }


        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            LlenarCampos(venta);
            if (VentaIdTextBox.Text.Length == 0)
            {
                if (venta.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                    LimpiarClase();
                    LimpiarLista();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al insertar", "Error", "Danger");
                }
            }
            else
            {
                venta.VentaId = Utilitarios.ToInt(VentaIdTextBox.Text);
                if (venta.Buscar(venta.VentaId))
                {
                    venta.Editar();
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                    LimpiarClase();
                    LimpiarLista();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al editar", "Error", "Danger");
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            Envios envio = new Envios();

            if (VentaIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Seleccione un ID", "Alerta", "Warning");
            }
            else
            {
                if (venta.Buscar(Utilitarios.ToInt(VentaIdTextBox.Text)))
                {
                    DevolverDatos(venta);
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al Buscar", "Error", "Danger");
                }
            }
        }

        protected void AgregarPasajerosButton_Click(object sender, EventArgs e)
        {
            Ventas venta;
            if (Session["VentaPasajero"] == null)
            {
                Session["VentaPasajero"] = new Ventas();
            }

            venta = (Ventas)Session["VentaPasajero"];

            venta.AgregarPasajeros(Utilitarios.ToInt(NombresDropDownList.SelectedValue));


            Session["VentaPasajero"] = venta;

            PasajerosGridView.DataSource = venta.Pasajero;
            PasajerosGridView.DataBind();
            float sust = 0;
            foreach (GridViewRow row in EnviosGridView.Rows)
            {
                float.TryParse(row.Cells[2].Text, out vari);
                TotalLabel.Text = (sust += vari).ToString();
            }
            LimpiarEnvio();

            

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarLista();
            LimpiarClase();
            LimpiarEnvio();
        }
    }
}