﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Registros
{
    public partial class rReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
                EliminarButton.Enabled = false;
                int Id;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilitarios.ToInt(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Reservaciones reservacion = new Reservaciones();
                        if (!reservacion.Buscar(Id))
                        {
                            Utilitarios.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            ReservacionIdTextBox.Text = Id.ToString();
                            DevolverDatos(reservacion);
                        }
                    }
                }
            }
        }

        public void Limpiar()
        {
            ReservacionIdTextBox.Text = string.Empty;
            UsuarioIdDropDownList.SelectedIndex = 0;
            LugarTextBox.Text = string.Empty;
            CantidadAsientoTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
            esActivaCheckBox.Checked = false;
            EliminarButton.Enabled = false;
        }

        public void LlenarDropDownList()
        {
            Usuarios usuario = new Usuarios();

            UsuarioIdDropDownList.DataSource = usuario.Listado(" * ", " 1=1 ", " ");
            UsuarioIdDropDownList.DataTextField = "Nombres";
            UsuarioIdDropDownList.DataValueField = "UsuarioId";
            UsuarioIdDropDownList.DataBind();
        }

        public void LlenarCampos(Reservaciones reservacion)
        {
            reservacion.UsuarioId = Utilitarios.ToInt(UsuarioIdDropDownList.SelectedValue);
            reservacion.Lugar = LugarTextBox.Text;
            reservacion.CantidadAsientos = Utilitarios.ToInt(CantidadAsientoTextBox.Text);
            reservacion.Fecha = Utilitarios.ToDatetime(FechaTextBox.Text);

            if (esActivaCheckBox.Checked)
            {
                reservacion.esActiva = 1;
            }
            else
            {
                reservacion.esActiva = 0;
            }

        }

        public void DevolverDatos(Reservaciones reservacion)
        {
            UsuarioIdDropDownList.SelectedValue = reservacion.UsuarioId.ToString();
            LugarTextBox.Text = reservacion.Lugar;
            CantidadAsientoTextBox.Text = reservacion.CantidadAsientos.ToString();
            FechaTextBox.Text = reservacion.Fecha.ToString("yyyy-MM-dd");

            if (reservacion.esActiva == 1)
            {
                esActivaCheckBox.Checked = true;
            }
            else
            {
                esActivaCheckBox.Checked = false;
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Reservaciones reservacion = new Reservaciones();


            if (ReservacionIdTextBox.Text.Length == 0)
            {
                LlenarCampos(reservacion);
                if (reservacion.Insertar())
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
                reservacion.ReservacionId = Utilitarios.ToInt(ReservacionIdTextBox.Text);
                if (reservacion.ReservacionId > 0)
                {
                    if (reservacion.Buscar(reservacion.ReservacionId))
                    {
                        LlenarCampos(reservacion);
                        if (reservacion.Editar())
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

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Reservaciones reservacion = new Reservaciones();

            if (ReservacionIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                reservacion.ReservacionId = Utilitarios.ToInt(ReservacionIdTextBox.Text);
                if (reservacion.ReservacionId > 0)
                {
                    if (reservacion.Buscar(reservacion.ReservacionId))
                    {
                        reservacion.Eliminar();
                        Utilitarios.ShowToastr(this, "Eliminado Corectamente", "Mensaje", "Success");
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Reservaciones reservacion = new Reservaciones();

            if (ReservacionIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this, "Introduzca un ID", "Alerta", "Warning");
            }
            else
            {
                reservacion.ReservacionId = Utilitarios.ToInt(ReservacionIdTextBox.Text);
                if (reservacion.ReservacionId > 0)
                {
                    if (reservacion.Buscar(reservacion.ReservacionId))
                    {
                        DevolverDatos(reservacion);
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