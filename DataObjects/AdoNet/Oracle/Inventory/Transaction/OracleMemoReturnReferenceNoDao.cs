using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using DataObjects.Interfaces.Inventory;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Inventory
{
    public class OracleMemoReturnReferenceNoDao : IMemoReturnReferenceNoDao
    {
        public object SaveMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo)
        {
            string sp = "memoreturnReferenceNo_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoreturnReferenceNo.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoreturnReferenceNo.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", memoreturnReferenceNo.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoreturnReferenceNo.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoreturnReferenceNo.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", memoreturnReferenceNo.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", memoreturnReferenceNo.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoreturnReferenceNo.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", memoreturnReferenceNo.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", memoreturnReferenceNo.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memoreturnReferenceNo.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo)
        {
            string sp = "memoreturnReferenceNo_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoreturnReferenceNo.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoreturnReferenceNo.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", memoreturnReferenceNo.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoreturnReferenceNo.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoreturnReferenceNo.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", memoreturnReferenceNo.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", memoreturnReferenceNo.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoreturnReferenceNo.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", memoreturnReferenceNo.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", memoreturnReferenceNo.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemoReturnReferenceNo> lst = new List<MemoReturnReferenceNo>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoReturnReferenceNo obj = new MemoReturnReferenceNo();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemoReturnRefNo(string ReferenceNo)
        {
            string sp = "in_inventory_utility_pkg.p_memo_return_ref_no_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_REFERENCE_NO", ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemoReturnReferenceNo> lst = new List<MemoReturnReferenceNo>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoReturnReferenceNo obj = new MemoReturnReferenceNo();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

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
