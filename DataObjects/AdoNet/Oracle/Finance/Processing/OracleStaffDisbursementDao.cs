using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleStaffDisbursementDao : IStaffDisbursementDao
    {
        public object SaveStaffDisbursement(StaffDisbursement staffDisbursement)
        {
            string sp = "staffDisbursement_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", staffDisbursement.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffDisbursement.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PROD_DESC", staffDisbursement.LoanProdDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_DESC", staffDisbursement.LoanPeriodDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", staffDisbursement.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT", staffDisbursement.DeductionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_DESC", staffDisbursement.ContraAcDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_TYPE", staffDisbursement.DisburseType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffDisbursement(StaffDisbursement staffDisbursement)
        {
            string sp = "staffDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", staffDisbursement.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffDisbursement.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PROD_DESC", staffDisbursement.LoanProdDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_DESC", staffDisbursement.LoanPeriodDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", staffDisbursement.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT", staffDisbursement.DeductionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_DESC", staffDisbursement.ContraAcDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_TYPE", staffDisbursement.DisburseType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffDisbursement> lst = new List<StaffDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffDisbursement obj = new StaffDisbursement();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProdDesc = drow["LOAN_PROD_DESC"].ToString();
                    obj.LoanPeriodDesc = drow["LOAN_PERIOD_DESC"].ToString();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.DeductionAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT"].ToString()));
                    obj.ContraAcDesc = drow["CONTRA_AC_DESC"].ToString();
                    obj.DisburseType = drow["DISBURSE_TYPE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetStaffDisbursement(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_staff_disbursement_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER_CODE", UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffDisbursement> lst = new List<StaffDisbursement>();
                for (int i = 0; i < 10; i++)
                {

                    StaffDisbursement obj = new StaffDisbursement();
                    obj.MemberName = i.ToString();
                    obj.LoanNo = i.ToString();
                    obj.LoanDno = i.ToString();
                    obj.LoanProdDesc = i.ToString();
                    obj.LoanPeriodDesc = i.ToString();
                    obj.Sno = i;
                    obj.LoanAmount = i;
                    obj.DeductionAmount = i;
                    obj.ContraAcDesc = i.ToString();
                    obj.DisburseType = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    StaffDisbursement obj = new StaffDisbursement();
                //    obj.MemberName = drow["MEMBER_NAME"].ToString();
                //    obj.LoanNo = drow["LOAN_NO"].ToString();
                //    obj.LoanDno = drow["LOAN_DNO"].ToString();
                //    obj.LoanProdDesc = drow["LOAN_PROD_DESC"].ToString();
                //    obj.LoanPeriodDesc = drow["LOAN_PERIOD_DESC"].ToString();
                //    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                //    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                //    obj.DeductionAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT"].ToString()));
                //    obj.ContraAcDesc = drow["CONTRA_AC_DESC"].ToString();
                //    obj.DisburseType = drow["DISBURSE_TYPE"].ToString();

                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
