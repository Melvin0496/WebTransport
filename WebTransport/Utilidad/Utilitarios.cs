using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebTransport
{
    public static class Utilitarios
    {
        public static void ShowToastr(Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static int ToInt(string campo)
        {
            int id;
            int.TryParse(campo, out id);
            return id;
        }
        
        public static float ToFloat(string campo)
        {
            float variable;
            float.TryParse(campo, out variable);
            return variable;
        }
    }
}