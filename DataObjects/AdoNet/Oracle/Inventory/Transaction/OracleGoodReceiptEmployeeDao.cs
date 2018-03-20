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
    public class OracleGoodReceiptEmployeeDao : IGoodReceiptEmployeeDao
    {
        public object SaveGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee)
        {
            string sp = "goodReceiptEmployee_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", goodReceiptEmployee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", goodReceiptEmployee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", goodReceiptEmployee.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee)
        {
            string sp = "goodReceiptEmployee_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", goodReceiptEmployee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", goodReceiptEmployee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GoodReceiptEmployee> lst = new List<GoodReceiptEmployee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GoodReceiptEmployee obj = new GoodReceiptEmployee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetGoodReceiptEmp()
        {
            string sp = "in_inventory_utility_pkg.p_good_receipt_emp_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GoodReceiptEmployee> lst = new List<GoodReceiptEmployee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GoodReceiptEmployee obj = new GoodReceiptEmployee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();

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
