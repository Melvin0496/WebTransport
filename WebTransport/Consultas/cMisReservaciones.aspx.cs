using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebTransport.Consultas
{
    public partial class cMisReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Reservaciones reservaciones = new Reservaciones();
            Usuarios usuario = new Usuarios();

            DatosGridView.DataSource = reservaciones.Listado(Utilitarios.ToInt(usuario.ObtenerUsuario(Context.User.Identity.Name).ToString()));
            DatosGridView.DataBind();
        }
    }
}