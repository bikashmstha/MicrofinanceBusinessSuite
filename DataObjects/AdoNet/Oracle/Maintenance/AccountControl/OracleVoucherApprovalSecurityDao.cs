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
    public class OracleVoucherApprovalSecurityDao:IVoucherApprovalSecurityDao
    {
        private List<OracleParameter> PrepareParameterList(VoucherApprovalSecurity voucherApprovalSecurity)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            /*p_user_code              IN     VARCHAR2,
      p_voucher_type           IN     VARCHAR2,
      p_max_approval_limit     IN     VARCHAR2,
      p_insert_update_delete   IN     VARCHAR2,
      v_out_result_code           OUT VARCHAR2,
      v_out_result_msg            OUT VARCHAR2*/


            paramList.Add(SqlHelper.GetOraParam(":p_user_code", voucherApprovalSecurity.UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_voucher_type", voucherApprovalSecurity.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_max_approval_limit", voucherApprovalSecurity.MaxApprovalAmount, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", voucherApprovalSecurity.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[4].Size = 10;
            paramList[5].Size = 100;

            return paramList;

        }
        public List<VoucherApprovalSecurity> GetVoucherApprovalSecurity(string officeCode)
        {
            try
            {
                string SP = "GL_ACCOUNT_CONTROL_PKG.p_voucher_approval_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", officeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                
                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<VoucherApprovalSecurity> lst = new List<VoucherApprovalSecurity>();


                VoucherApprovalSecurity obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new VoucherApprovalSecurity();
                    /*USER_CODE,VOUCHER_TYPE,MAX_APPROVAL_AMOUNT */
                    obj.UserCode = drow["USER_CODE"].ToString();//APPLICATION_ID
                    obj.VoucherType = drow["VOUCHER_TYPE"].ToString();//APPLICATION_DESCRIPTION
                    if (!string.IsNullOrEmpty(drow["MAX_APPROVAL_AMOUNT"].ToString()))
                        obj.MaxApprovalAmount = int.Parse(drow["MAX_APPROVAL_AMOUNT"].ToString());//APPLICATION_ID
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

        public OutMessage SaveVoucherApprovalSecurity(VoucherApprovalSecurity voucherApprovalSecurity)
        {
            string SP = "GL_ACCOUNT_CONTROL_PKG.p_account_category"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(voucherApprovalSecurity);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[4].Value.ToString();
                oMsg.OutResultMessage = paramList[5].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}