using System;
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

            if (CamposCheckBox.Checked)
            {
                if (CamposTextBox.Text.Trim().Length == 0)
                {
                    condicion = " 1=1 ";
                }

                else
                {
                    condicion = CamposDropDownList.SelectedItem.Text + " = " + CamposTextBox.Text;
                }
                DatosGridView.DataSource = reservacion.Listado(" * ", condicion, " ");
                DatosGridView.DataBind();
            }
            else if (FechaCheckBox.Checked)
            {
                condicion = "Fecha between '" + FechaDesdeTextBox.Text + "' and '" + FechaHastaTextBox.Text + "'";

                DatosGridView.DataSource = reservacion.Listado(" * ", condicion, " ");
                DatosGridView.DataBind();
            }
        }
    }
}