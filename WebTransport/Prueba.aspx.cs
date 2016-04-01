using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTransport
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            //TextBox.Text = System.IO.File.ReadAllText(@"C:\Users\Junior Gabriel\Desktop\Nuevo documento de texto (6).txt");
            label.Text = Multiplicar(TextBox.Text).ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox.Text = string.Empty;
        }

        public float Multiplicar(string campo)
        {
            return Convert.ToSingle(campo) * 10;
        }
    }
}