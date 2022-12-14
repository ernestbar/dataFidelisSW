using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace proyDataFidelis
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    txtUsuario.Focus();
                    lblAviso.Text = "";
                    //string path = Server.MapPath("~/wkhtmltopdf/wkhtmltopdf.exe");
                    //string ruta_Archivo = Server.MapPath("~/Reportes/Seguro");


                    //ProcessStartInfo oProcessStarInfo = new ProcessStartInfo();
                    //oProcessStarInfo.UseShellExecute = false;
                    //oProcessStarInfo.FileName = path;
                    //oProcessStarInfo.Arguments = ruta_Archivo + "\\seguro1.aspx " + ruta_Archivo + "\\mipdf2.pdf";
                    ////oProcessStarInfo.Arguments = ruta_Archivo + "http://hdeleon.net/ "+ ruta_Archivo+ "\\mipdf.pdf";

                    //using (Process oProcess = Process.Start(oProcessStarInfo))
                    //{
                    //    oProcess.WaitForExit();

                    //}

                    //Console.WriteLine("pdf creado");
                    //Console.Read(); }
                }
                catch (Exception ex)
                {
                    string aux = ex.ToString();
                }
                
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string[] datos= Clases.Usuarios.Ingreso_usuario(txtUsuario.Text, txtPassword.Text).Split('|');
            if (datos[1] == "Login correcto")
            {
                if (datos[2] == "1")
                {
                    Session["sistema"] = ddlSistema.SelectedValue;
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("cambio_password.aspx?temp=1");
                }
                else
                {
                    Session["sistema"] = ddlSistema.SelectedValue;
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("dashboard.aspx");
                    lblAviso.Text = "";
                }
                //Clases.enviar_correo objC = new Clases.enviar_correo();
                //string resp_email = objC.enviar("ernesto.barron@gmail.com", "Confirmacion de requisitos", "Pruebas de envio de correo.", "");
                
                
            }
            else
            { lblAviso.Text = "Usuario y contraseña incorrectas!"; txtUsuario.Focus(); }
            
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clases.Usuarios per = new Clases.Usuarios("R", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", txtUsuario.Text, "", "", "", DateTime.Now, DateTime.Now, "", txtUsuario.Text);
            string[] datos = per.ABM().Split('|');
            //if (datos[2] == "PASSWORD CORRECTAMENTE REGISTRADO")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password se reseteo correctamente a 123');", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password NO se reseteo correctamente a 123');", true);
            //}
            Clases.enviar_correo objC = new Clases.enviar_correo();
            string resultado2 = objC.enviar(txtUsuario.Text, "Reseteo de contraseña del usuario " + txtUsuario.Text, "Estimado usuario :" + "<br/><br/> Su password temporal es el 123: <br/><br/>" + " <br/><br/> Ahora debe ingresar al sistema del siguiente link: <br/><br/>" + "https://200.105.209.42:5559" + "<br/><br/>Saludos coordiales.", "");
            lblAviso.Text = "Te enviamos un correo con tu password temporal para ingresar, muchas gracias!!!!";
        }

        protected void ddlSistema_DataBound(object sender, EventArgs e)
        {
            ddlSistema.Items.Insert(0, "SELEECIONAR SISTEMA");
        }
    }
}