﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Consultas
{
    public partial class cPasajeros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string condicion;
           Pasajeros pasajero = new Pasajeros();
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
            DatosGridView.DataSource = pasajero.Listado(" * ", condicion, " ");
            DatosGridView.DataBind();
        }
    }
}