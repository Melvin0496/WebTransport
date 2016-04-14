using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Consultas
{
    public partial class cVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string condicion;
            Ventas ventas = new Ventas();
            if (CamposTextBox.Text.Trim().Length == 0)
            {
                condicion = " 1=1 ";
            }
            else
            {
                condicion = CamposDropDownList.SelectedItem.Text + " = " + CamposTextBox.Text;
            }
            DatosGridView.DataSource = ventas.Listado(" * ", condicion, " ");
            DatosGridView.DataBind();
        }
    }
}