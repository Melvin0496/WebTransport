using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;

namespace PruebaDeMelvin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Email = EmailTextBox.Text;
            usuario.Contrasena = PasswordTextBox.Text;
            if (usuario.Accder())
            {
                FormsAuthentication.RedirectFromLoginPage(EmailTextBox.Text, RecuerdameCheckBox.Checked);
            }
            else
            {
                MansajeErrorLabel.Text = "Inavalid credentials. Please try again";
                //Response.Write("<SCRIPT>alert('Invalid credentials. Please try again')</SCRIPT>");
            }
        }
    }
}