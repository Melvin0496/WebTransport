using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace WebTransport
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLabel.Text = Context.User.Identity.Name;

            if (!IsPostBack)
            {
                Usuarios usuarios = new Usuarios();
                DataTable dt = new DataTable();
                int variable;

                dt = usuarios.ValidarUsuario(Context.User.Identity.Name);
                int.TryParse(dt.Rows[0]["TipoUsuario"].ToString(), out variable);

                if (variable == 1)
                {
                    UserControl();
                }
                else
                {
                    MiReservacionesLi.Visible = false;
                }
            }
        }

        public void UserControl()
        {
            UsuariosLi.Visible = false;
            PasajerosLi.Visible = false;
            VentasLi.Visible = false;
            ChoferesLi.Visible = false;
            ParadaLi.Visible = false;
            AutobusesLi.Visible = false;
            TipoEnvioLi.Visible = false;
            ReservacionesConsultaLi.Visible = false;
        }

    }
}
