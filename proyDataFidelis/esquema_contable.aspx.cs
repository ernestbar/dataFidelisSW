using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyDataFidelis
{
    public partial class esquema_contable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["usuario"] = "admin";
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {

                    //lblUsuario.Text = Session["usuario"].ToString();
                    ////btnNuevo.Visible = false;
                    //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    ////DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    ////if (dt.Rows.Count > 0)
                    ////{
                    ////    foreach (DataRow dr in dt.Rows)
                    ////    {
                    ////        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    ////            btnNuevo.Visible = true;
                    ////    }

                    ////}
                    Repeater1.DataSource = Clases.Utiles.PR_GET_ESQUEMA_CONTABLE(0,0, 0, 0, 0, 0);
                    Repeater1.DataBind();
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void ibtnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            decimal p1 = 0;
            decimal p2 = 0;
            decimal p3 = 0;
            decimal f1 = 0;
            decimal f2 = 0;
            decimal f3 = 0;
            int p = 0;
            int f = 0;
            List<string> listaPictet = new List<string>();
            foreach (RepeaterItem Item in Repeater1.Items)
            {
                TextBox text1 = (TextBox)Item.FindControl("TextBox1");
                if (p == 0)
                    p1 =decimal.Parse(text1.Text);
                if (p == 1)
                    p2 = decimal.Parse(text1.Text);
                if (p == 2)
                    p3 = decimal.Parse(text1.Text);
                p++;
            }
            List<string> listaFees = new List<string>();
            foreach (RepeaterItem Item in Repeater1.Items)
            {
                TextBox text2 = (TextBox)Item.FindControl("TextBox2");
                if (f == 0)
                    f1 = decimal.Parse(text2.Text);
                if (f == 1)
                    f2 = decimal.Parse(text2.Text);
                if (f == 2)
                    f3 = decimal.Parse(text2.Text);
                f++;
            }
            
            Repeater1.DataSource = Clases.Utiles.PR_GET_ESQUEMA_CONTABLE(p1,p2, p3, f1, f2, f3);
            Repeater1.DataBind();

        }
    }
}