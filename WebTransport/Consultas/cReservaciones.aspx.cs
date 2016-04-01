﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace WebTransport.Consultas
{
    public partial class cReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string condicion;
            Reservaciones reservacion = new Reservaciones();
            if (CamposTextBox.Text.Trim().Length == 0)
            {
                condicion = " 1=1 ";
            }
            else
            {
                if (CamposDropDownList.SelectedIndex == 0)
                {
                    condicion = CamposDropDownList.SelectedItem.Text + " = " + CamposTextBox.Text;
                }
                else
                {
                    condicion = CamposDropDownList.SelectedItem.Text + " like " + "'%" + CamposTextBox.Text + "%'";
                }
            }
            DatosGridView.DataSource = reservacion.Listado(" * ", condicion, " ");
            DatosGridView.DataBind();
        }
    }
}