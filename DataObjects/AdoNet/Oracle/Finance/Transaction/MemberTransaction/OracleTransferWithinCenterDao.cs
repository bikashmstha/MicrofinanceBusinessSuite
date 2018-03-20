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
    public class OracleTransferWithinCenterDao : ITransferWithinCenterDao
    {
        public object Get()
        {
            string sp = "transferwithincenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<TransferWithinCenter> lst = new List<TransferWithinCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    TransferWithinCenter obj = new TransferWithinCenter();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.OldGroupCode = drow["OldGroupCode"].ToString();
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

        public object Save(TransferWithinCenter transferwithincenter)
        {
            string sp = "member_transfer_pkg.p_tranfer_withina_center";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {

                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_client_no", transferwithincenter.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_old_group_code", transferwithincenter.OldGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_new_group_code", transferwithincenter.NewGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_username", transferwithincenter.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", transferwithincenter.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_client_code", transferwithincenter.ClientCode, OracleDbType.Varchar2, ParameterDirection.Output));
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


        public object Search(TransferWithinCenter transferwithincenter)
        {
            string sp = "transferwithincenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", transferwithincenter.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OldGroupCode", transferwithincenter.OldGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NewGroupCode", transferwithincenter.NewGroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserName", transferwithincenter.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", transferwithincenter.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", transferwithincenter.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<TransferWithinCenter> lst = new List<TransferWithinCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    TransferWithinCenter obj = new TransferWithinCenter();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.OldGroupCode = drow["OldGroupCode"].ToString();
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
