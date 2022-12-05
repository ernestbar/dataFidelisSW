using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace proyDataFidelis.Clases
{
    public class Cuentas
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_CUENTA = "";
        private Int64 _PB_ID_CLIENTE = 0;
        private DateTime _PD_FECHA_INGRESO = DateTime.Now;
        private DateTime _PD_FECHA_SALIDA = DateTime.Now;
        private string _PV_CASO_USO = "";
        private string _PV_BANCO = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_CUENTA { get { return _PV_CUENTA; } set { _PV_CUENTA = value; } }
        public Int64 PB_ID_CLIENTE { get { return _PB_ID_CLIENTE; } set { _PB_ID_CLIENTE = value; } }
        public DateTime PD_FECHA_INGRESO { get { return _PD_FECHA_INGRESO; } set { _PD_FECHA_INGRESO = value; } }
        public DateTime PD_FECHA_SALIDA { get { return _PD_FECHA_SALIDA; } set { _PD_FECHA_SALIDA = value; } }
        public string PV_CASO_USO { get { return _PV_CASO_USO; } set { _PV_CASO_USO = value; } }
        public string PV_BANCO { get { return _PV_BANCO; } set { _PV_BANCO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Cuentas(string pV_CUENTA)
        {
            _PV_CUENTA = pV_CUENTA;
            RecuperarDatos();
        }
        public Cuentas(string pV_TIPO_OPERACION, string pV_CUENTA, Int64 pB_ID_CLIENTE, DateTime pD_FECHA_INGRESO,
         DateTime pD_FECHA_SALIDA, string pV_CASO_USO,string pV_BANCO, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_CUENTA = pV_CUENTA;
            _PD_FECHA_INGRESO = pD_FECHA_INGRESO;
            _PD_FECHA_SALIDA = pD_FECHA_SALIDA;
            _PV_CASO_USO = pV_CASO_USO;
            _PV_BANCO = pV_BANCO;
            _PB_ID_CLIENTE = pB_ID_CLIENTE;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable Lista(string CLI_ID_CLIENTE)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CUENTAS");

                db1.AddInParameter(cmd, "CLI_ID_CLIENTE", DbType.String, CLI_ID_CLIENTE);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_GET_CUENTASCLIENTES(string PV_BANCO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CUENTASCLIENTES");

                db1.AddInParameter(cmd, "PV_BANCO", DbType.String, PV_BANCO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CUENTAS_IND");
                db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, _PV_CUENTA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["CLI_ID_CLIENTE"].ToString()))
                        { _PB_ID_CLIENTE = 0; }
                        else
                        { _PB_ID_CLIENTE = Int64.Parse(dr["CLI_ID_CLIENTE"].ToString()); }

                        if (string.IsNullOrEmpty(dr["FECHA_INGRESO"].ToString()))
                        { _PD_FECHA_INGRESO = DateTime.Parse("01/01/3000"); }
                        else
                        { _PD_FECHA_INGRESO = DateTime.Parse(dr["FECHA_INGRESO"].ToString()); }

                        if (string.IsNullOrEmpty(dr["FECHA_SALIDA"].ToString()))
                        { _PD_FECHA_SALIDA = DateTime.Parse("01/01/3000"); }
                        else
                        { _PD_FECHA_SALIDA = DateTime.Parse(dr["FECHA_SALIDA"].ToString()); }

                        if (string.IsNullOrEmpty(dr["CUENTA"].ToString()))
                        { _PV_CUENTA = ""; }
                        else
                        { _PV_CUENTA = (string)dr["CUENTA"]; }

                        if (string.IsNullOrEmpty(dr["CASO_USO"].ToString()))
                        { _PV_CASO_USO = ""; }
                        else
                        { _PV_CASO_USO = (string)dr["CASO_USO"]; }

                        if (string.IsNullOrEmpty(dr["BANCO"].ToString()))
                        { _PV_BANCO =""; }
                        else
                        { _PV_BANCO = (string)dr["BANCO"]; }



                    }

                }
            }
            catch (Exception ex)
            {

            }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CUENTAS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if(_PV_CUENTA=="")
                    db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, _PV_CUENTA);
                db1.AddInParameter(cmd, "PB_ID_CLIENTE", DbType.Int64, _PB_ID_CLIENTE);
                db1.AddInParameter(cmd, "PD_FECHA_INGRESO", DbType.DateTime, _PD_FECHA_INGRESO);
                if(_PV_TIPO_OPERACION=="D")
                    db1.AddInParameter(cmd, "PD_FECHA_SALIDA", DbType.DateTime, _PD_FECHA_SALIDA);
                else
                    db1.AddInParameter(cmd, "PD_FECHA_SALIDA", DbType.DateTime, null);

                db1.AddInParameter(cmd, "PV_CASO_USO", DbType.String, _PV_CASO_USO);
                db1.AddInParameter(cmd, "PV_BANCO", DbType.String, _PV_BANCO);
             
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
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


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "|Se produjo un error al registrar|";
                return resultado;
            }
        }

        #endregion
    }
}