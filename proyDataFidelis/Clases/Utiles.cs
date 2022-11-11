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

        
        public static DataTable PR_GET_ESQUEMA_CONTABLE(decimal PV_PORTP_1, decimal PV_PORTP_2, decimal PV_PORTP_3,
            decimal PV_FEESP_1, decimal PV_FEESP_2, decimal PV_FEESP_3)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_ESQUEMA_CONTABLE");

                db1.AddInParameter(cmd, "@PV_PORTP_1", DbType.Decimal, PV_PORTP_1);
                db1.AddInParameter(cmd, "@PV_PORTP_2", DbType.Decimal, PV_PORTP_2);
                db1.AddInParameter(cmd, "@PV_PORTP_3", DbType.Decimal, PV_PORTP_3);
                db1.AddInParameter(cmd, "@PV_FEESP_1", DbType.Decimal, PV_FEESP_1);
                db1.AddInParameter(cmd, "@PV_FEESP_2", DbType.Decimal, PV_FEESP_2);
                db1.AddInParameter(cmd, "@PV_FEESP_3", DbType.Decimal, PV_FEESP_3);
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