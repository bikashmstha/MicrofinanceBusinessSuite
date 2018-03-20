using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
using DataObjects.Interfaces.Maintenance;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.Maintenance
{
    public class OracleInstallmentPeriodDao:IInstallmentPeriodDao
    {
        private List<OracleParameter> PrepareParameterList(InstallmentPeriod installmentPeriod)
        {
            /*
             * p_install_period            IN     NUMBER,
      p_install_desc              IN     VARCHAR2,
      p_installment_period_type   IN     VARCHAR2,
      p_install_type              IN     VARCHAR2,
      p_grace_days                IN     NUMBER,
      p_created_modified_on       IN     DATE,
      p_created_modified_by       IN     VARCHAR2,
      p_active                    IN     VARCHAR2,
      p_insert_update             IN     VARCHAR2,
      v_out_result_code              OUT VARCHAR2,
      v_out_result_msg               OUT VARCHAR2*/

            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_install_period", installmentPeriod.InstallmentPeriods, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_install_desc", installmentPeriod.InstallmentPeriodDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_installment_period_type", installmentPeriod.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_install_type", installmentPeriod.InstallmentType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_grace_days", installmentPeriod.MaxGraceDays, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", installmentPeriod.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", installmentPeriod.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", installmentPeriod.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", installmentPeriod.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[9].Size = 10;
            paramList[10].Size = 100;

            return paramList;

        }
        public List<InstallmentPeriod> GetInstallmentPeriod()
        {
            try
            {
                string SP = "ms_general_definition_pkg.p_installment_period_dtl";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<InstallmentPeriod> lst = new List<InstallmentPeriod>();


                InstallmentPeriod obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new InstallmentPeriod();
                    /*INSTALL_PERIOD, 
                                 INSTALL_DESC, 
                                 INSTALLMENT_PERIOD_TYPE, 
                                 MS_REF_CODE_PKG.F_REF_DTL_NAME('INSTALLMENT_PERIOD_TYPE',INSTALLMENT_PERIOD_TYPE) INSTALLMENT_PERIOD_TYPE_DET, 
                                 INSTALL_TYPE, 
                                 MS_REF_CODE_PKG.F_REF_DTL_NAME('INSTALLMENT_TYPE',INSTALL_TYPE) INSTALL_TYPE_DET, 
                                 GRACE_DAYS, 
                                 CREATED_ON, 
                                 CREATED_BY, 
                                 MODIFIED_ON, 
                                 MODIFIED_BY, 
                                 ACTIVE */
                    obj.InstallmentPeriods = drow["INSTALL_PERIOD"].ToString();//APPLICATION_ID
                    obj.InstallmentPeriodDesc = drow["INSTALL_DESC"].ToString();//APPLICATION_DESCRIPTION
                    obj.InstallmentPeriodType = drow["INSTALLMENT_PERIOD_TYPE"].ToString();//APPLICATION_ID
                    obj.InstallmentPeriodTypeDesc = drow["INSTALLMENT_PERIOD_TYPE_DET"].ToString();//APPLICATION_DESCRIPTION
                    obj.InstallmentType = drow["INSTALL_TYPE"].ToString();//APPLICATION_ID
                    obj.InstallmentType = drow["INSTALL_TYPE_DET"].ToString();//APPLICATION_DESCRIPTION
                    obj.MaxGraceDays = Int16.Parse(drow["GRACE_DAYS"].ToString());
                    obj.CreatedOn = drow["CREATED_ON"].ToString();//APPLICATION_DESCRIPTION
                    obj.CreatedBy = drow["CREATED_BY"].ToString();//APPLICATION_ID
                    obj.ModifiedOn = drow["MODIFIED_ON"].ToString();//APPLICATION_DESCRIPTION
                    obj.ModifiedBy = drow["MODIFIED_BY"].ToString();//APPLICATION_ID
                    obj.Active = drow["ACTIVE"].ToString();//APPLICATION_DESCRIPTION
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveInstallmentPeriod(InstallmentPeriod installmentPeriod)
        {
            string SP = "ms_general_definition_pkg.p_insert_update_install_period"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(installmentPeriod);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[9].Value.ToString();
                oMsg.OutResultMessage = paramList[10].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
