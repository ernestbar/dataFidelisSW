using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace proyDataFidelis.Clases
{
    public class Clientes
    {

        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        // JURIDICA
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_CLIENTE =0;
        private string _PV_RAZON_SOCIAL = "";
        private string _PV_CONTACTO = "";
        private string _PV_TELEFONO = "";
        private string _PV_EMAIL = "";
        private string _PV_PAIS = "";
        private string _PV_CIUDAD = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        private Int64 _PB_ID_CLIENTEOUT = 0;
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_CLIENTE { get { return _PB_ID_CLIENTE; } set { _PB_ID_CLIENTE = value; } }
        public string PV_RAZON_SOCIAL { get { return _PV_RAZON_SOCIAL; } set { _PV_RAZON_SOCIAL = value; } }
        public string PV_CONTACTO { get { return _PV_CONTACTO; } set { _PV_CONTACTO = value; } }
        public string PV_TELEFONO { get { return _PV_TELEFONO; } set { _PV_TELEFONO = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public string PV_PAIS { get { return _PV_PAIS; } set { _PV_PAIS = value; } }
        public string PV_CIUDAD { get { return _PV_CIUDAD; } set { _PV_CIUDAD = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public Int64 PB_ID_CLIENTEOUT { get { return _PB_ID_CLIENTEOUT; } set { _PB_ID_CLIENTEOUT = value; } }
        #endregion

        #region Constructores
        public Clientes(Int64 CLI_ID_CLIENTE)
        {
            _PB_ID_CLIENTE = CLI_ID_CLIENTE;
            RecuperarDatos();
        }
        public Clientes(string pV_TIPO_OPERACION, Int64 pB_ID_CLIENTE,
            string pV_RAZON_SOCIAL, string pV_CONTACTO, string pV_TELEFONO,
        string pV_EMAIL, string pV_PAIS, string pV_CIUDAD, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_CLIENTE = pB_ID_CLIENTE;
            _PV_RAZON_SOCIAL = pV_RAZON_SOCIAL;
            _PV_CONTACTO = pV_CONTACTO;
            _PV_TELEFONO = pV_TELEFONO;
            _PV_EMAIL = pV_EMAIL;
            _PV_PAIS = pV_PAIS;
            _PV_CIUDAD = pV_CIUDAD;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_CLIENTES()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CLIENTES");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CLIENTES_IND");
                db1.AddInParameter(cmd, "PB_CLI_ID_CLIENTE", DbType.Int64, _PB_ID_CLIENTE);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["CLI_RAZON_SOCIAL"].ToString()))
                        { _PV_RAZON_SOCIAL = ""; }
                        else
                        { _PV_RAZON_SOCIAL = dr["CLI_RAZON_SOCIAL"].ToString(); }
                        if (string.IsNullOrEmpty(dr["CLI_CONTACTO"].ToString()))
                        { _PV_CONTACTO= ""; }
                        else
                        { _PV_CONTACTO = dr["CLI_CONTACTO"].ToString(); }

                        if (string.IsNullOrEmpty(dr["CLI_TELEFONO"].ToString()))
                        { _PV_TELEFONO = ""; }
                        else
                        { _PV_TELEFONO = dr["CLI_TELEFONO"].ToString(); }

                        if (string.IsNullOrEmpty(dr["CLI_EMAIL"].ToString()))
                        { _PV_EMAIL = ""; }
                        else
                        { _PV_EMAIL = dr["CLI_EMAIL"].ToString(); }

                        if (string.IsNullOrEmpty(dr["CLI_PAIS"].ToString()))
                        { _PV_PAIS = ""; }
                        else
                        { _PV_PAIS = (string)dr["CLI_PAIS"]; }

                        if (string.IsNullOrEmpty(dr["CLI_CIUDAD"].ToString()))
                        { _PV_CIUDAD = ""; }
                        else
                        { _PV_CIUDAD = (string)dr["CLI_CIUDAD"]; }
                    }
                }
            }
            catch { }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CLIENTES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if(_PB_ID_CLIENTE==0)
                    db1.AddInParameter(cmd, "PB_ID_CLIENTE", DbType.Int64, null);
                else
                    db1.AddInParameter(cmd, "PB_ID_CLIENTE", DbType.Int64, _PB_ID_CLIENTE);
                db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, _PV_RAZON_SOCIAL);
                db1.AddInParameter(cmd, "PV_CONTACTO", DbType.String, _PV_CONTACTO);
                db1.AddInParameter(cmd, "PV_TELEFONO", DbType.String, _PV_TELEFONO);
                db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                db1.AddInParameter(cmd, "PV_PAIS", DbType.String, _PV_PAIS);
                db1.AddInParameter(cmd, "PV_CIUDAD", DbType.String, _PV_CIUDAD);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
              
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PB_ID_CLIENTEOUT", DbType.Int64, 32);
                db1.ExecuteNonQuery(cmd);

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCION").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PB_ID_CLIENTEOUT").ToString()))
                    PB_ID_CLIENTEOUT = 0;
                else
                    PB_ID_CLIENTEOUT = (Int64)db1.GetParameterValue(cmd, "PB_ID_CLIENTEOUT");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR+"| ID: "+ PB_ID_CLIENTEOUT;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                //resultado = "Se produjo un error al registrar";
                resultado = ex.ToString() + "|";
                return resultado;
            }
        }
        
        #endregion
    }
}