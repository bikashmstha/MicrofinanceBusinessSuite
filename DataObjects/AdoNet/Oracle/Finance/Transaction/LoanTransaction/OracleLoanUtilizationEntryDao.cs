using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanUtilizationEntryDao : ILoanUtilizationEntryDao
    {
        public object Get()
        {
            string sp = "loanUtilizationEntry_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanUtilizationEntry> lst = new List<LoanUtilizationEntry>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanUtilizationEntry obj = new LoanUtilizationEntry();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.InspectionDate = drow["INSPECTION_DATE"].ToString();
                    obj.UtilizationPc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UTILIZATION_PC"].ToString()));
                    obj.ManagerUtilization_Pc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANAGER_UTILIZATION_PC"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ManagerInspection_Date = drow["MANAGER_INSPECTION_DATE"].ToString();
                    obj.FieldRemarks = drow["FIELD_REMARKS"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanUtilizationEntry loanUtilizationEntry)
        {
            string sp = "fn_loan_pkg.p_loan_utilization_entry";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", loanUtilizationEntry.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", loanUtilizationEntry.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanUtilizationEntry.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSPECTION_DATE", loanUtilizationEntry.InspectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UTILIZATION_PC", loanUtilizationEntry.UtilizationPc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_UTILIZATION_PC", loanUtilizationEntry.ManagerUtilization_Pc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", loanUtilizationEntry.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_INSPECTION_DATE", loanUtilizationEntry.ManagerInspection_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIELD_REMARKS", loanUtilizationEntry.FieldRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", loanUtilizationEntry.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanUtilizationEntry.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(LoanUtilizationEntry loanUtilizationEntry)
        {
            string sp = "loanUtilizationEntry_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", loanUtilizationEntry.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", loanUtilizationEntry.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanUtilizationEntry.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSPECTION_DATE", loanUtilizationEntry.InspectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UTILIZATION_PC", loanUtilizationEntry.UtilizationPc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_UTILIZATION_PC", loanUtilizationEntry.ManagerUtilization_Pc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", loanUtilizationEntry.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_INSPECTION_DATE", loanUtilizationEntry.ManagerInspection_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIELD_REMARKS", loanUtilizationEntry.FieldRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", loanUtilizationEntry.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanUtilizationEntry> lst = new List<LoanUtilizationEntry>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanUtilizationEntry obj = new LoanUtilizationEntry();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.InspectionDate = drow["INSPECTION_DATE"].ToString();
                    obj.UtilizationPc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UTILIZATION_PC"].ToString()));
                    obj.ManagerUtilization_Pc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANAGER_UTILIZATION_PC"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ManagerInspection_Date = drow["MANAGER_INSPECTION_DATE"].ToString();
                    obj.FieldRemarks = drow["FIELD_REMARKS"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();

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
