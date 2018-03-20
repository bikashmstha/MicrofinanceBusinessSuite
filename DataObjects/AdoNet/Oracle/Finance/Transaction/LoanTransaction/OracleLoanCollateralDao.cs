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
    public class OracleLoanCollateralDao : ILoanCollateralDao
    {

        public object SaveLoanCollateral(LoanCollateral loanCollateral)
        {
            string sp = "fn_loan_pkg.p_loan_collateral";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", loanCollateral.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanCollateral.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL", loanCollateral.Collateral, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VENUE", loanCollateral.Venue, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL_VALUE", loanCollateral.CollateralValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALULATOR_NAME", loanCollateral.ValulatorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL_IMG_PATH", loanCollateral.CollateralImgPath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", loanCollateral.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE", loanCollateral.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", loanCollateral.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", loanCollateral.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", loanCollateral.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_SNO", loanCollateral.OutSno, OracleDbType.Double, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_action", loanCollateral.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LoanCollateral loanCollateral)
        {
            string sp = "loanCollateral_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanCollateral.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", loanCollateral.Sno, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL", loanCollateral.Collateral, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VENUE", loanCollateral.Venue, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL_VALUE", loanCollateral.CollateralValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALULATOR_NAME", loanCollateral.ValulatorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL_TYPE", loanCollateral.CollateralType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLATERAL_TYPE_DET", loanCollateral.CollateralType_Det, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUATION_DATE", loanCollateral.ValuationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanCollateral> lst = new List<LoanCollateral>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanCollateral obj = new LoanCollateral();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.Sno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.Collateral = drow["COLLATERAL"].ToString();
                    obj.Venue = drow["VENUE"].ToString();
                    obj.CollateralValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLATERAL_VALUE"].ToString()));
                    obj.ValulatorName = drow["VALULATOR_NAME"].ToString();
                    obj.CollateralType = drow["COLLATERAL_TYPE"].ToString();
                    obj.CollateralType_Det = drow["COLLATERAL_TYPE_DET"].ToString();
                    obj.ValuationDate = drow["VALUATION_DATE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanCollateral(string loanNo)
        {
            string sp = "fn_loan_pkg.p_me_loan_collateral_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanCollateral> lst = new List<LoanCollateral>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanCollateral obj = new LoanCollateral();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.Sno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.Collateral = drow["COLLATERAL"].ToString();
                    obj.Venue = drow["VENUE"].ToString();
                    obj.CollateralValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLATERAL_VALUE"].ToString()));
                    obj.ValulatorName = drow["VALULATOR_NAME"].ToString();
                    obj.CollateralType = drow["COLLATERAL_TYPE"].ToString();
                    obj.CollateralType_Det = drow["COLLATERAL_TYPE_DET"].ToString();
                    obj.ValuationDate = drow["VALUATION_DATE"].ToString();

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
