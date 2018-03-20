using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleTransferCenterToAnotherCenterDao : ITransferCenterToAnotherCenterDao
    {
        public object Get()
        {
            string sp = "TransferCenterToAnotherCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<TransferCenterToAnotherCenter> lst = new List<TransferCenterToAnotherCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    TransferCenterToAnotherCenter obj = new TransferCenterToAnotherCenter();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.OldGroupCode = drow["OldGroupCode"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.NewGroupCode = drow["NewGroupCode"].ToString();
                    obj.UserName = drow["UserName"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(TransferCenterToAnotherCenter TransferCenterToAnotherCenter)
        {
            string sp = "member_transfer_pkg.p_tranfer_cntrtoanothercenter";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_client_no", TransferCenterToAnotherCenter.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_old_group_code", TransferCenterToAnotherCenter.OldGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_new_group_code", TransferCenterToAnotherCenter.NewGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_new_center_code", TransferCenterToAnotherCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_username", TransferCenterToAnotherCenter.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", TransferCenterToAnotherCenter.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_client_code", TransferCenterToAnotherCenter.ClientCode, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.Result = paramList[paramList.Count - 3].Value.ToString(); 
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object Search(TransferCenterToAnotherCenter TransferCenterToAnotherCenter)
        {
            string sp = "TransferCenterToAnotherCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", TransferCenterToAnotherCenter.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OldGroupCode", TransferCenterToAnotherCenter.OldGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", TransferCenterToAnotherCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NewGroupCode", TransferCenterToAnotherCenter.NewGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserName", TransferCenterToAnotherCenter.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", TransferCenterToAnotherCenter.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", TransferCenterToAnotherCenter.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<TransferCenterToAnotherCenter> lst = new List<TransferCenterToAnotherCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    TransferCenterToAnotherCenter obj = new TransferCenterToAnotherCenter();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.OldGroupCode = drow["OldGroupCode"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.NewGroupCode = drow["NewGroupCode"].ToString();
                    obj.UserName = drow["UserName"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
