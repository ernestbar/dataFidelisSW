using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyDataFidelis
{
    public partial class cuentas_admin : System.Web.UI.Page
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
                    lblIDCliente.Text = Session["ID_CLIENTE"].ToString();
                    lblClienteNombreTitulo.Text = Session["NOMBRE_CLIENTE"].ToString();
                    //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}
                    Repeater1.DataBind();
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                
                lblCuenta.Text = id;
                Clases.Cuentas dom = new Clases.Cuentas(lblCuenta.Text);
                Panel_alta.Visible = false;
                Panel_baja.Visible = false;
                Panel_edicion.Visible = true;
                lblNombreCliente.Text = lblClienteNombreTitulo.Text;
                if (dom.PD_FECHA_INGRESO == DateTime.Parse("01/01/3000"))
                {
                    DateTime fecha1 = DateTime.Now;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();
                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
                else
                {
                    DateTime fecha1 = dom.PD_FECHA_INGRESO;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();

                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }

                ddlBanco.SelectedValue =dom.PV_BANCO;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cuentas_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                lblNombreCliente.Text = lblClienteNombreTitulo.Text;
                lblCuenta.Text = datos[0];
                lblFechaDesde.Text= datos[1];
                
                Panel_baja.Visible = true;
                Panel_alta.Visible = false;
                Panel_edicion.Visible = false;
                DateTime fecha1 = DateTime.Parse(lblFechaDesde.Text);
                string dia = "";
                string mes = "";
                if (fecha1.Day.ToString().Length == 1)
                    dia = "0" + fecha1.Day.ToString();
                else
                    dia = fecha1.Day.ToString();
                if (fecha1.Month.ToString().Length == 1)
                    mes = "0" + fecha1.Month.ToString();
                else
                    mes = fecha1.Month.ToString();
                hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                hfFechaRetorno.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaRetorno();", true);

               
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cuentas_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha_retorno = "01/01/3000";
                if (hfFechaRetorno.Value != "")
                    fecha_retorno = hfFechaRetorno.Value;
                string fecha_salida = "01/01/3000";
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaSalida.Value;
                if (lblCuenta.Text == "")
                {
                    Clases.Cuentas dom = new Clases.Cuentas("I",txtCuenta.Text,Int64.Parse(lblIDCliente.Text), DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlCasoUso.SelectedValue, ddlBanco.SelectedValue, lblUsuario.Text);
                    lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", ""); ;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    if (Panel_baja.Visible == false)
                    {
                        Clases.Cuentas dom = new Clases.Cuentas("U", lblCuenta.Text, Int64.Parse(lblIDCliente.Text), DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlCasoUso.SelectedValue, ddlBanco.SelectedValue, lblUsuario.Text);
                        lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                        MultiView1.ActiveViewIndex = 0;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        if (DateTime.Parse(hfFechaRetorno.Value) < DateTime.Parse(lblFechaDesde.Text))
                        {
                            lblAviso.Text = "La fecha de baja no puede ser menor a la fecha de ingreso: " + DateTime.Parse(lblFechaDesde.Text).ToShortDateString();
                        }
                        else
                        {
                            Clases.Cuentas dom = new Clases.Cuentas("D", lblCuenta.Text, Int64.Parse(lblIDCliente.Text), DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlCasoUso.SelectedValue, ddlBanco.SelectedValue, lblUsuario.Text);
                            lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                            MultiView1.ActiveViewIndex = 0;
                            Repeater1.DataBind();
                        }
                        
                    }
                }
               
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cuentas_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            Panel_alta.Visible = true;
            Panel_baja.Visible = false;
            Panel_edicion.Visible = true;
            lblNombreCliente.Text = lblClienteNombreTitulo.Text;
            MultiView1.ActiveViewIndex = 1;
            DateTime fecha1 = DateTime.Now;
            string dia = "";
            string mes = "";
            if (fecha1.Day.ToString().Length == 1)
                dia = "0" + fecha1.Day.ToString();
            else
                dia = fecha1.Day.ToString();
            if (fecha1.Month.ToString().Length == 1)
                mes = "0" + fecha1.Month.ToString();
            else
                mes = fecha1.Month.ToString();
            hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }
        public void limpiar_controles()
        {
            txtCuenta.Text = "";
            lblCuenta.Text = "";
            lblAviso.Text = "";
            ddlBanco.DataBind();
            ddlCasoUso.DataBind();
            
        }
       

        protected void ddlCasoUso_DataBound(object sender, EventArgs e)
        {
            ddlCasoUso.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlBanco_DataBound(object sender, EventArgs e)
        {
            ddlBanco.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnVolverClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clientes_admin.aspx");
        }
    }
}