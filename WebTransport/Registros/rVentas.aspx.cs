using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace WebTransport.Registros
{
    public partial class rVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarButton.Enabled = false;
                LlenarDropDownList();
                ValidarDropDownList();
                int Id;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilitarios.ToInt(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Ventas venta = new Ventas();
                        if (!venta.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            LimpiarClase();
                            LimpiarLista();
                        }
                        else
                        {
                            VentaIdTextBox.Text = Id.ToString();
                            DevolverDatos(venta);
                        }

                    }
                }
            }

        }

        public void LlenarDropDownList()
        {
            Choferes chofer = new Choferes();
            Usuarios usuario = new Usuarios();
            Autobuses autobus = new Autobuses();
            Pasajeros pasajero = new Pasajeros();
            TipoEnvios tipoEnvio = new TipoEnvios();


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

            TipoEnvioDropDownList.DataSource = tipoEnvio.Listado(" * ", " 1=1 ", " ");
            TipoEnvioDropDownList.DataTextField = "Descripcion";
            TipoEnvioDropDownList.DataValueField = "TipoEnvioId";
            TipoEnvioDropDownList.DataBind();

        }

        public void ValidarDropDownList()
        {
            if(UsuarioIdDropDownList.Items.Count == 0)
            {
                Response.Redirect("/Registros/rUsuarios.aspx");

            }else if(ChoferIdDropDownList.Items.Count == 0)
            {
                Response.Redirect("/Registros/rChoferes.aspx");

            }else if(AutobusIdDropDownList.Items.Count == 0)
            {
                Response.Redirect("/Registros/rAutobuses.aspx");

            }else if(NombresDropDownList.Items.Count == 0)
            {
                Response.Redirect("/Registros/rPasajeros.aspx");

            }else if(TipoEnvioDropDownList.Items.Count == 0)
            {
                Response.Redirect("/Registros/rTipoEnvios.aspx");
            }
        }

        public void LimpiarClase()
        {
            VentaIdTextBox.Text = string.Empty;
            ChoferIdDropDownList.SelectedIndex = 0;
            FechaTextBox.Text = string.Empty;
            UsuarioIdDropDownList.SelectedIndex = 0;
            AutobusIdDropDownList.SelectedIndex = 0;
            TotalLabel.Text = string.Empty;
            EliminarButton.Enabled = false;

        }

        public void LimpiarLista()
        {
            Ventas venta = new Ventas();

            Session["Venta"] = new Ventas();
            venta.Envio.Clear();
            EnviosGridView.DataSource = null;
            EnviosGridView.DataBind();

            Session["VentaPasajero"] = new Ventas();
            venta.Pasajero.Clear();
            PasajerosGridView.DataSource = null;
            PasajerosGridView.DataBind();

        }

        public void LimpiarEnvio()
        {
            DescripcionTextBox.Text = string.Empty;
            TipoEnvioDropDownList.SelectedIndex = 0;
            PrecioTextBox.Text = string.Empty;
            EmisorTextBox.Text = string.Empty;
            ReceptorTextBox.Text = string.Empty;

        }
        float total = 0f, vari = 0f;
        public void LlenarCampos(Ventas venta)
        {
            venta.Fecha = Utilitarios.ToDatetime(FechaTextBox.Text);
            venta.ChoferId = Utilitarios.ToInt(ChoferIdDropDownList.SelectedValue);
            venta.AutobusId = Utilitarios.ToInt(AutobusIdDropDownList.SelectedValue);
            venta.UsuarioId = Utilitarios.ToInt(UsuarioIdDropDownList.SelectedValue);
            venta.AutobusId = Utilitarios.ToInt(AutobusIdDropDownList.SelectedValue);


            foreach (GridViewRow row in EnviosGridView.Rows)
            {
                float.TryParse(row.Cells[2].Text, out vari);
                venta.AgregarEnvios(row.Cells[0].Text, Utilitarios.ToInt(row.Cells[1].Text), vari, row.Cells[3].Text, row.Cells[4].Text);
                total += vari;
            }


            //foreach (GridViewRow row in PasajerosGridView.Rows)
            //{
            //    venta.AgregarPasajeros(Utilitarios.ToInt(NombresDropDownList.SelectedValue));
            //}


            venta.Total = total;

        }

        public void DevolverDatos(Ventas venta)
        {
            FechaTextBox.Text = venta.Fecha.ToString("yyyy-MM-dd");
            ChoferIdDropDownList.SelectedValue = venta.ChoferId.ToString();
            UsuarioIdDropDownList.SelectedValue = venta.UsuarioId.ToString();
            AutobusIdDropDownList.SelectedValue = venta.AutobusId.ToString();

            EnviosGridView.DataSource = venta.Envio;
            EnviosGridView.DataBind();

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarClase();
            LimpiarLista();
        }

        //protected void EnviosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    DataTable dt = (DataTable)Session["Venta"];
        //    dt.Rows[Utilitarios.ToInt(e.RowIndex.ToString())].Delete();
        //    Session["Venta"] = dt;
        //    EnviosGridView.DataSource = Session["Venta"] as DataTable;
        //    EnviosGridView.DataBind();

        //}

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();

            if (VentaIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                venta.VentaId = Utilitarios.ToInt(VentaIdTextBox.Text);

                if (venta.VentaId > 0)
                {
                    if (venta.Buscar(venta.VentaId))
                    {
                        DevolverDatos(venta);
                        EliminarButton.Enabled = true;
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('ID incorrecto')</SCRIPT>");
                        LimpiarClase();
                    }
                }
            }
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();

            if (EnviosGridView.Rows.Count == 0)
            {
                Utilitarios.ShowToastr(this, "Debes añadir envios o pasajeros a la venta", "Alerta", "Warning");
            }
            else
            {
                if (VentaIdTextBox.Text.Length == 0)
                {
                    LlenarCampos(venta);
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

                    if (venta.VentaId > 0)
                    {
                        if (venta.Buscar(venta.VentaId))
                        {
                            LlenarCampos(venta);
                            if (venta.Editar())
                            {
                                Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                                LimpiarClase();
                                LimpiarLista();
                            }
                        }
                        else
                        {
                            Response.Write("<SCRIPT>alert('No se pudo editar...ID incorrecto')</SCRIPT>");
                            LimpiarLista();
                            LimpiarClase();
                        }
                    }
                }
            }
        }

        protected void EnviosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Ventas venta = new Ventas();
            DataTable dt = (DataTable)Session["Venta"];
            dt.Rows[Utilitarios.ToInt(e.RowIndex.ToString())].Delete();
            Session["Venta"] = dt;
            EnviosGridView.DataSource = venta.Envio;
            EnviosGridView.DataBind();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();

            if (VentaIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                venta.VentaId = Utilitarios.ToInt(VentaIdTextBox.Text);

                if (venta.Buscar(venta.VentaId))
                {
                    venta.Eliminar();
                    Utilitarios.ShowToastr(this, "Transaccion exitosa!!!", "Mensaje", "Success");
                    LimpiarClase();
                    LimpiarLista();
                }
                else
                {
                    Response.Write("<SCRIPT>alert('ID incorrecto')</SCRIPT>");
                    LimpiarClase();
                    LimpiarLista();
                }
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {

            Ventas venta;

            if (Session["Venta"] == null)
            {
                Session["Venta"] = new Ventas();
            }

            venta = (Ventas)Session["Venta"];

            venta.AgregarEnvios(DescripcionTextBox.Text, Utilitarios.ToInt(TipoEnvioDropDownList.SelectedValue), Utilitarios.ToFloat(PrecioTextBox.Text), EmisorTextBox.Text, ReceptorTextBox.Text);

            Session["Venta"] = venta;

            EnviosGridView.DataSource = venta.Envio;
            EnviosGridView.DataBind();

            LimpiarEnvio();
            float sust = 0;
            foreach (GridViewRow row in EnviosGridView.Rows)
            {
                float.TryParse(row.Cells[2].Text, out vari);
                TotalLabel.Text = (sust += vari).ToString();
            }

        }
    }
}