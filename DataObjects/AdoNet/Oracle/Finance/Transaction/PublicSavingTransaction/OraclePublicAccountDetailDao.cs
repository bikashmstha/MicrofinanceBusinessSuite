using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OraclePublicAccountDetailDao : IPublicAccountDetailDao
    {
        public object SavePublicAccountDetail(PublicAccountDetail publicAccountDetail)
        {
            string sp = "publicAccountDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", publicAccountDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicAccountDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", publicAccountDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicAccountDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicAccountDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DEPOSIT_TO_REF_AC", publicAccountDetail.TransferDepositTo_Ref_Ac, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSING_CHARGE", publicAccountDetail.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicAccountDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicAccountDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSED_DATE", publicAccountDetail.AccountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_DESC", publicAccountDetail.SavProdDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", publicAccountDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURITY", publicAccountDetail.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", publicAccountDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", publicAccountDetail.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCH_DESC", publicAccountDetail.IntSchDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicAccountDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OPEN_DATE_BS", publicAccountDetail.OpenDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DUE_MANDATORY_AMOUNT", publicAccountDetail.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicAccountDetail.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD", publicAccountDetail.DepositPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_TYPE", publicAccountDetail.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_NO", publicAccountDetail.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", publicAccountDetail.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicAccountDetail.ContraAcNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicAccountDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicAccountDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicAccountDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicAccountDetail(PublicAccountDetail publicAccountDetail)
        {
            string sp = "publicAccountDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", publicAccountDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicAccountDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", publicAccountDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicAccountDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicAccountDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DEPOSIT_TO_REF_AC", publicAccountDetail.TransferDepositTo_Ref_Ac, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSING_CHARGE", publicAccountDetail.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicAccountDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicAccountDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSED_DATE", publicAccountDetail.AccountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_DESC", publicAccountDetail.SavProdDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", publicAccountDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURITY", publicAccountDetail.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", publicAccountDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", publicAccountDetail.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCH_DESC", publicAccountDetail.IntSchDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicAccountDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OPEN_DATE_BS", publicAccountDetail.OpenDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DUE_MANDATORY_AMOUNT", publicAccountDetail.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicAccountDetail.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD", publicAccountDetail.DepositPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_TYPE", publicAccountDetail.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_NO", publicAccountDetail.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", publicAccountDetail.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicAccountDetail.ContraAcNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicAccountDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicAccountDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountDetail> lst = new List<PublicAccountDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountDetail obj = new PublicAccountDetail();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.TransferDepositTo_Ref_Ac = drow["TRANSFER_DEPOSIT_TO_REF_AC"].ToString();
                    obj.AccClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACC_CLOSING_CHARGE"].ToString()));
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountStatus = drow["ACCOUNT_STATUS"].ToString();
                    obj.AccountClosedDate = drow["ACCOUNT_CLOSED_DATE"].ToString();
                    obj.SavProdDesc = drow["SAV_PROD_DESC"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.AmtAtMaturity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMT_AT_MATURITY"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.TransferIntPeriodic = drow["TRANSFER_INT_PERIODIC"].ToString();
                    obj.IntSchDesc = drow["INT_SCH_DESC"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.OpenDateBs = drow["OPEN_DATE_BS"].ToString();
                    obj.DueMandatoryAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DUE_MANDATORY_AMOUNT"].ToString()));
                    obj.FixedCollectAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECT_AMOUNT"].ToString()));
                    obj.DepositPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_PERIOD"].ToString()));
                    obj.CollectionType = drow["COLLECTION_TYPE"].ToString();
                    obj.ReferenceAccountNo = drow["REFERENCE_ACCOUNT_NO"].ToString();
                    obj.MaturityDate = drow["MATURITY_DATE"].ToString();
                    obj.ContraAcNo = drow["CONTRA_AC_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPubAccDetail(string OfficeCode, string ClientNo, string SavingAccountNo, string ClientName, string ProductClass, string FromDate, string ToDate)
        {
            string sp = "fn_saving_utility_pkg.p_pub_acc_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NO", ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRODUCT_CLASS", ProductClass, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountDetail> lst = new List<PublicAccountDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountDetail obj = new PublicAccountDetail();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.TransferDepositTo_Ref_Ac = drow["TRANSFER_DEPOSIT_TO_REF_AC"].ToString();
                    obj.AccClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACC_CLOSING_CHARGE"].ToString()));
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountStatus = drow["ACCOUNT_STATUS"].ToString();
                    obj.AccountClosedDate = drow["ACCOUNT_CLOSED_DATE"].ToString();
                    obj.SavProdDesc = drow["SAV_PROD_DESC"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.AmtAtMaturity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMT_AT_MATURITY"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.TransferIntPeriodic = drow["TRANSFER_INT_PERIODIC"].ToString();
                    obj.IntSchDesc = drow["INT_SCH_DESC"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.OpenDateBs = drow["OPEN_DATE_BS"].ToString();
                    obj.DueMandatoryAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DUE_MANDATORY_AMOUNT"].ToString()));
                    obj.FixedCollectAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECT_AMOUNT"].ToString()));
                    obj.DepositPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_PERIOD"].ToString()));
                    obj.CollectionType = drow["COLLECTION_TYPE"].ToString();
                    obj.ReferenceAccountNo = drow["REFERENCE_ACCOUNT_NO"].ToString();
                    obj.MaturityDate = drow["MATURITY_DATE"].ToString();
                    obj.ContraAcNo = drow["CONTRA_AC_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();

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
