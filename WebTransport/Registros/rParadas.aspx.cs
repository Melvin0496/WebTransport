using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rParadas : System.Web.UI.Page
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
                        Paradas parada = new Paradas();
                        if (!parada.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            ParadaIdTextBox.Text = Id.ToString();
                            DevolverDatos(parada);
                        }

                    }
                }
            }
        }

        public void Limpiar()
        {
            ParadaIdTextBox.Text = string.Empty;
            LugarTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            EliminarButton.Enabled = false;
        }

        public void LlenarCampos(Paradas parada)
        {
            parada.Lugar = LugarTextBox.Text;
            parada.Telefono = TelefonoTextBox.Text;
        }

        public void DevolverDatos(Paradas parada)
        {
            LugarTextBox.Text = parada.Lugar;
            TelefonoTextBox.Text = parada.Telefono;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Paradas parada = new Paradas();

            if (ParadaIdTextBox.Text.Length == 0)
            {
                LlenarCampos(parada);
                if (parada.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Transaccion exitosa", "Mensaje", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error al insertar", "Error", "Danger");
                }
            }
            else
            {
                parada.ParadaId = Utilitarios.ToInt(ParadaIdTextBox.Text);
                if (parada.ParadaId > 0)
                {
                    if (parada.Buscar(parada.ParadaId))
                    {
                        LlenarCampos(parada);
                        if (parada.Editar())
                        {
                            Utilitarios.ShowToastr(this, "Transaccion exitosa", "Mensaje", "Success");
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

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Paradas parada = new Paradas();

            if (ParadaIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un id", "Alerta", "Warning");
            }
            else
            {
                parada.ParadaId = Utilitarios.ToInt(ParadaIdTextBox.Text);
                if (parada.ParadaId > 0)
                {
                    if (parada.Buscar(parada.ParadaId))
                    {
                        parada.Eliminar();
                        Utilitarios.ShowToastr(this, "Transaccion exitosa", "Mensaje", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('ID Incorrecto')</SCRIPT>");
                        Limpiar();
                    }
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Paradas parada = new Paradas();

            if (ParadaIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Selecciona un id", "Alerta", "Warning");
            }
            else
            {
                parada.ParadaId = Utilitarios.ToInt(ParadaIdTextBox.Text);
                if (parada.ParadaId > 0)
                {
                    if (parada.Buscar(parada.ParadaId))
                    {
                        DevolverDatos(parada);
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
    }
}