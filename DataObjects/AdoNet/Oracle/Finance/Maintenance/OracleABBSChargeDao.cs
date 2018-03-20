using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleABBSChargeDao : IABBSChargeDao
    {
        private List<OracleParameter> PrepareParameterList(ABBSCharge abbsCharge)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            /*p_tran_office_code  IN  fn_abbs_charge_list.tran_office_code%TYPE,
                                             p_to_office_code   IN   fn_abbs_charge_list.to_office_code%TYPE,
                                             p_abbs_type      IN    fn_abbs_charge_list.abbs_type%TYPE,
                                             p_abbs_min_amount               IN fn_abbs_charge_list.abbs_min_amount%TYPE,
                                             p_abbs_max_amount           IN    fn_abbs_charge_list.abbs_max_amount%TYPE,
                                             p_abbs_charge_amount      IN fn_abbs_charge_list.abbs_charge_amount%TYPE,
                                             p_active_flag    IN  fn_abbs_charge_list.active_flag%TYPE,
                                             p_insert_update  IN       VARCHAR2,
                                             v_out_result_code                  OUT VARCHAR2,
                                             v_out_result_msg                   OUT VARCHAR2)*/

            paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", abbsCharge.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_to_office_code", abbsCharge.ToOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_abbs_type", abbsCharge.ABBSType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_abbs_min_amount", abbsCharge.ABBSMinAmount, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_abbs_max_amount", abbsCharge.ABBSMaxAmount, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_abbs_charge_amount", abbsCharge.ABBSChargAmount, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active_flag", abbsCharge.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", abbsCharge.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;


            return paramList;

        }
        public List<ABBSCharge> GetABBSCharge(string office,string toOffice, string abbsType)
        {
            try
            {

                string SP = "FN_SAVING_UTILITY_PKG.p_get_abbs_charge_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                /*
                 * p_tran_office_code            IN   FN_ABBS_CHARGE_LIST.tran_office_code%TYPE,
                                                      p_to_office_code        IN   FN_ABBS_CHARGE_LIST.to_office_code%TYPE,
                                                      p_abbs_type              IN   FN_ABBS_CHARGE_LIST.abbs_type%TYPE,
                                                       v_out_record            OUT   SYS_REFCURSOR
                 * */
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", office, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_to_office_code", toOffice, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_abbs_type", abbsType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<ABBSCharge> lst = new List<ABBSCharge>();


                ABBSCharge obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new ABBSCharge();
                    /*
  SELECT tran_office_code,
         to_office_code,
         abbs_type,
         abbs_min_amount,
         abbs_max_amount,
         abbs_charge_amount,
         active_flag,
         ms_ref_code_pkg.f_ref_dtl_name ('ABBS_TYPE', abbs_type) abbs_type_name
    FROM fn_abbs_charge_list
ORDER BY tran_office_code, to_office_code;*/
                    obj.TranOfficeCode = drow["tran_office_code"].ToString();
                    obj.ToOfficeCode = drow["to_office_code"].ToString();
                    obj.ABBSType = drow["abbs_type"].ToString();
                    obj.ABBSMinAmount =long.Parse( drow["abbs_min_amount"].ToString());
                    obj.ABBSMaxAmount =long.Parse( drow["abbs_max_amount"].ToString());
                    obj.ABBSChargAmount =long.Parse( drow["abbs_charge_amount"].ToString());
                    obj.Active = drow["active_flag"].ToString();
                    obj.ABBSTypeDesc = drow["abbs_type_name"].ToString();
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

        public OutMessage SaveABBSCharge(ABBSCharge aBBSCharge)
        {
            string SP = "FN_SAVING_UTILITY_PKG.P_ABBS_CHARGE";
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(aBBSCharge);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[paramList.Count-2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count-1].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
