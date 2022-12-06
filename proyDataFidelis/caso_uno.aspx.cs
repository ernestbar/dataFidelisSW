using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyDataFidelis
{
    public partial class caso_uno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {

                    lblUsuario.Text = Session["usuario"].ToString();
                    //btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void ddlBanco_DataBound(object sender, EventArgs e)
        {
            ddlBanco.Items.Insert(0,"SELECCIONAR");
        }

        protected void ddlCuenta_DataBound(object sender, EventArgs e)
        {
            ddlCuenta.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Repeater1.DataSource = Clases.Utiles.PR_GET_CASO_USO1A("C", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue, 0, 0, 0, 0, 0, lblUsuario.Text);
            Repeater1.DataBind();
            Repeater2.DataSource = Clases.Utiles.PR_GET_CASO_USO1C("C", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue, 0, 0, 0, 0, 0, lblUsuario.Text);
            Repeater2.DataBind();
            string[] aux= Clases.Utiles.PR_GET_CASO_USO1B("C", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue, 0, 0, 0, 0, 0, lblUsuario.Text).Split('|');
            txtFEEFS.Text = aux[0];
            txtFEEBANCO.Text = aux[1];
            string[] aux2 = ddlCuenta.SelectedItem.Text.Split('/');
            lblNomCliente.Text = aux2[1];
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ibtnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            decimal p1 = 0;
            decimal p2 = 0;
            decimal p3 = 0;
            int p = 0;
            List<string> listaPictet = new List<string>();
            foreach (RepeaterItem Item in Repeater1.Items)
            {
                TextBox text1 = (TextBox)Item.FindControl("TextBox1");
                if (p == 0)
                    p1 = decimal.Parse(text1.Text.Replace("$","").Replace(" ","").Replace(".", decSep).Replace(",", decSep));
                if (p == 1)
                    p2 = decimal.Parse(text1.Text.Replace("$", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep));
                if (p == 2)
                    p3 = decimal.Parse(text1.Text.Replace("$", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep));
                p++;
            }

            Repeater1.DataSource = Clases.Utiles.PR_GET_CASO_USO1A("A", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue,decimal.Parse(txtFEEFS.Text.Replace("%", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), decimal.Parse(txtFEEBANCO.Text.Replace("$", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), p1,p2, p3, lblUsuario.Text);
            Repeater1.DataBind();
            Repeater2.DataSource = Clases.Utiles.PR_GET_CASO_USO1C("A", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue, decimal.Parse(txtFEEFS.Text.Replace("%", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), decimal.Parse(txtFEEBANCO.Text.Replace("$", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), p1, p2, p3, lblUsuario.Text);
            Repeater2.DataBind();
            string[] aux = Clases.Utiles.PR_GET_CASO_USO1B("A", ddlCuenta.SelectedValue, ddlTrimestre.SelectedValue, decimal.Parse(txtFEEFS.Text.Replace("%", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), decimal.Parse(txtFEEBANCO.Text.Replace("$", "").Replace(" ", "").Replace(".", decSep).Replace(",", decSep)), p1, p2, p3, lblUsuario.Text).Split('|');
            txtFEEFS.Text = aux[0].Replace(".", decSep).Replace(",", decSep);
            txtFEEBANCO.Text = aux[1].Replace(".", decSep).Replace(",", decSep);
        }

        protected void ddlTrimestre_DataBound(object sender, EventArgs e)
        {
            ddlTrimestre.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}