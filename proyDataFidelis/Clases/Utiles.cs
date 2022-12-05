using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace proyDataFidelis.Clases
{
    public class Utiles
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades

        #endregion

        #region Constructores

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_GET_CASO_USO1A(string PV_TIPO_OPERACION, string PV_CUENTA, string PV_TRIMESTRE,
           decimal PD_FEE_SF, decimal PD_FEE_BANCO, decimal PV_MONTO1, decimal PV_MONTO2, decimal PV_MONTO3,string PV_USUARIO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CASO_USO1");

                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, PV_CUENTA);
                db1.AddInParameter(cmd, "PV_TRIMESTRE", DbType.String, PV_TRIMESTRE);
                db1.AddInParameter(cmd, "PD_FEE_SF", DbType.Decimal, PD_FEE_SF);
                db1.AddInParameter(cmd, "PD_FEE_BANCO", DbType.Decimal, PD_FEE_BANCO);
                db1.AddInParameter(cmd, "PV_MONTO1", DbType.Decimal, PV_MONTO1);
                db1.AddInParameter(cmd, "PV_MONTO2", DbType.Decimal, PV_MONTO2);
                db1.AddInParameter(cmd, "PV_MONTO3", DbType.Decimal, PV_MONTO3);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                db1.AddOutParameter(cmd, "PD_FEE_SF_OUT", DbType.String, 30);
                db1.AddOutParameter(cmd, "PD_FEE_BANCO_OUT", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
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
        public static string PR_GET_CASO_USO1B(string PV_TIPO_OPERACION, string PV_CUENTA, string PV_TRIMESTRE,
          decimal PD_FEE_SF, decimal PD_FEE_BANCO, decimal PV_MONTO1, decimal PV_MONTO2, decimal PV_MONTO3, string PV_USUARIO)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CASO_USO1");

                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, PV_CUENTA);
                db1.AddInParameter(cmd, "PV_TRIMESTRE", DbType.String, PV_TRIMESTRE);
                db1.AddInParameter(cmd, "PD_FEE_SF", DbType.Decimal, PD_FEE_SF);
                db1.AddInParameter(cmd, "PD_FEE_BANCO", DbType.Decimal, PD_FEE_BANCO);
                db1.AddInParameter(cmd, "PV_MONTO1", DbType.Decimal, PV_MONTO1);
                db1.AddInParameter(cmd, "PV_MONTO2", DbType.Decimal, PV_MONTO2);
                db1.AddInParameter(cmd, "PV_MONTO3", DbType.Decimal, PV_MONTO3);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                db1.AddOutParameter(cmd, "PD_FEE_SF_OUT", DbType.String, 30);
                db1.AddOutParameter(cmd, "PD_FEE_BANCO_OUT", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);

                string PD_FEE_SF_OUT = "";
                string PD_FEE_BANCO_OUT = "";
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PD_FEE_SF_OUT").ToString()))
                    PD_FEE_SF_OUT = "";
                else
                    PD_FEE_SF_OUT = (string)db1.GetParameterValue(cmd, "PD_FEE_SF_OUT");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PD_FEE_BANCO_OUT").ToString()))
                    PD_FEE_BANCO_OUT = "";
                else
                    PD_FEE_BANCO_OUT = (string)db1.GetParameterValue(cmd, "PD_FEE_BANCO_OUT");
              

                resultado = PD_FEE_SF_OUT + "|" + PD_FEE_BANCO_OUT ;
                return resultado;
            }
            catch (Exception ex)
            {
                
               
                return ex.ToString();
            }

        }
        public static DataTable PR_GET_CASO_USO1C(string PV_TIPO_OPERACION, string PV_CUENTA, string PV_TRIMESTRE,
           decimal PD_FEE_SF, decimal PD_FEE_BANCO, decimal PV_MONTO1, decimal PV_MONTO2, decimal PV_MONTO3, string PV_USUARIO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CASO_USO1");

                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, PV_CUENTA);
                db1.AddInParameter(cmd, "PV_TRIMESTRE", DbType.String, PV_TRIMESTRE);
                db1.AddInParameter(cmd, "PD_FEE_SF", DbType.Decimal, PD_FEE_SF);
                db1.AddInParameter(cmd, "PD_FEE_BANCO", DbType.Decimal, PD_FEE_BANCO);
                db1.AddInParameter(cmd, "PV_MONTO1", DbType.Decimal, PV_MONTO1);
                db1.AddInParameter(cmd, "PV_MONTO2", DbType.Decimal, PV_MONTO2);
                db1.AddInParameter(cmd, "PV_MONTO3", DbType.Decimal, PV_MONTO3);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                db1.AddOutParameter(cmd, "PD_FEE_SF_OUT", DbType.String, 30);
                db1.AddOutParameter(cmd, "PD_FEE_BANCO_OUT", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[1];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_GET_ESQUEMA_CONTABLE(decimal PV_PORTP_1, decimal PV_PORTP_2, decimal PV_PORTP_3,
            decimal PV_FEESP_1, decimal PV_FEESP_2, decimal PV_FEESP_3)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_ESQUEMA_CONTABLE");

                db1.AddInParameter(cmd, "PV_PORTP_1", DbType.Decimal, PV_PORTP_1);
                db1.AddInParameter(cmd, "PV_PORTP_2", DbType.Decimal, PV_PORTP_2);
                db1.AddInParameter(cmd, "PV_PORTP_3", DbType.Decimal, PV_PORTP_3);
                db1.AddInParameter(cmd, "PV_FEESP_1", DbType.Decimal, PV_FEESP_1);
                db1.AddInParameter(cmd, "PV_FEESP_2", DbType.Decimal, PV_FEESP_2);
                db1.AddInParameter(cmd, "PV_FEESP_3", DbType.Decimal, PV_FEESP_3);
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

        public static DataTable PR_GET_TRIMESTRES(string PV_CUENTA)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_TRIMESTRES");

                db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, PV_CUENTA);
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

    }
}