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
    public class OracleLnUtilizationDetailDao : ILnUtilizationDetailDao
    {
        public object Get()
        {
            string sp = "lnUtilizationDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationDetail> lst = new List<LnUtilizationDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationDetail obj = new LnUtilizationDetail();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.InspectionDate = drow["INSPECTION_DATE"].ToString();
                    obj.FieldRemarks = drow["FIELD_REMARKS"].ToString();
                    obj.UtilizationPc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UTILIZATION_PC"].ToString()));
                    obj.ManagerInspection_Date = drow["MANAGER_INSPECTION_DATE"].ToString();
                    obj.ManagerUtilization_Pc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANAGER_UTILIZATION_PC"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LnUtilizationDetail lnUtilizationDetail)
        {
            string sp = "lnUtilizationDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lnUtilizationDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lnUtilizationDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lnUtilizationDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lnUtilizationDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_DESC", lnUtilizationDetail.LoanPurpose_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", lnUtilizationDetail.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lnUtilizationDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSPECTION_DATE", lnUtilizationDetail.InspectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIELD_REMARKS", lnUtilizationDetail.FieldRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UTILIZATION_PC", lnUtilizationDetail.UtilizationPc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_INSPECTION_DATE", lnUtilizationDetail.ManagerInspection_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_UTILIZATION_PC", lnUtilizationDetail.ManagerUtilization_Pc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", lnUtilizationDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", lnUtilizationDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LnUtilizationDetail lnUtilizationDetail)
        {
            string sp = "lnUtilizationDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lnUtilizationDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lnUtilizationDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lnUtilizationDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lnUtilizationDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_DESC", lnUtilizationDetail.LoanPurpose_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", lnUtilizationDetail.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lnUtilizationDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSPECTION_DATE", lnUtilizationDetail.InspectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIELD_REMARKS", lnUtilizationDetail.FieldRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UTILIZATION_PC", lnUtilizationDetail.UtilizationPc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_INSPECTION_DATE", lnUtilizationDetail.ManagerInspection_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANAGER_UTILIZATION_PC", lnUtilizationDetail.ManagerUtilization_Pc, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", lnUtilizationDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationDetail> lst = new List<LnUtilizationDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationDetail obj = new LnUtilizationDetail();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.InspectionDate = drow["INSPECTION_DATE"].ToString();
                    obj.FieldRemarks = drow["FIELD_REMARKS"].ToString();
                    obj.UtilizationPc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UTILIZATION_PC"].ToString()));
                    obj.ManagerInspection_Date = drow["MANAGER_INSPECTION_DATE"].ToString();
                    obj.ManagerUtilization_Pc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANAGER_UTILIZATION_PC"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLnUtilizationDetail(string CenterCode)
        {
            string sp = "fn_loan_utility_pkg.p_ln_utilization_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_CENTER_CODE", CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationDetail> lst = new List<LnUtilizationDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationDetail obj = new LnUtilizationDetail();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.InspectionDate = drow["INSPECTION_DATE"].ToString();
                    obj.FieldRemarks = drow["FIELD_REMARKS"].ToString();
                    obj.UtilizationPc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UTILIZATION_PC"].ToString()));
                    obj.ManagerInspection_Date = drow["MANAGER_INSPECTION_DATE"].ToString();
                    obj.ManagerUtilization_Pc = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANAGER_UTILIZATION_PC"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();

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
