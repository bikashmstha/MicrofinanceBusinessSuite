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
    public class OraclePublicSavingAccountOpenDao : IPublicSavingAccountOpenDao
    {
        public object SavePublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen)
        {
            string sp = "publicSavingAccountOpen_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicSavingAccountOpen.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", publicSavingAccountOpen.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicSavingAccountOpen.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicSavingAccountOpen.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicSavingAccountOpen.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSED_DATE", publicSavingAccountOpen.AccountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", publicSavingAccountOpen.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", publicSavingAccountOpen.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingAccountOpen.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE", publicSavingAccountOpen.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SIGNEE_NAME1", publicSavingAccountOpen.SigneeName1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SIGNEE_NAME2", publicSavingAccountOpen.SigneeName2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicSavingAccountOpen.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DUE_MANDATORY_AMOUNT", publicSavingAccountOpen.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSING_CHARGE", publicSavingAccountOpen.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingAccountOpen.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicSavingAccountOpen.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_TYPE", publicSavingAccountOpen.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD", publicSavingAccountOpen.DepositPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD_TYPE", publicSavingAccountOpen.DepositPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_NO", publicSavingAccountOpen.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", publicSavingAccountOpen.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_AMT", publicSavingAccountOpen.InsurancePolicyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURITY", publicSavingAccountOpen.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", publicSavingAccountOpen.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicSavingAccountOpen.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", publicSavingAccountOpen.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DEPOSIT_TO_REF_AC", publicSavingAccountOpen.TransferDepositTo_Ref_Ac, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_THIRD_PARTY_DATA", publicSavingAccountOpen.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingAccountOpen.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingAccountOpen.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingAccountOpen.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingAccountOpen.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUB_SAV_AC_NO", publicSavingAccountOpen.OutPubSav_Ac_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUB_SAV_AC_DISP_NO", publicSavingAccountOpen.OutPubSav_Ac_Disp_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicSavingAccountOpen.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen)
        {
            string sp = "publicSavingAccountOpen_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicSavingAccountOpen.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", publicSavingAccountOpen.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicSavingAccountOpen.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicSavingAccountOpen.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicSavingAccountOpen.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSED_DATE", publicSavingAccountOpen.AccountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", publicSavingAccountOpen.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", publicSavingAccountOpen.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingAccountOpen.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE", publicSavingAccountOpen.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SIGNEE_NAME1", publicSavingAccountOpen.SigneeName1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SIGNEE_NAME2", publicSavingAccountOpen.SigneeName2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicSavingAccountOpen.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DUE_MANDATORY_AMOUNT", publicSavingAccountOpen.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSING_CHARGE", publicSavingAccountOpen.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingAccountOpen.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicSavingAccountOpen.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_TYPE", publicSavingAccountOpen.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD", publicSavingAccountOpen.DepositPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_PERIOD_TYPE", publicSavingAccountOpen.DepositPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_NO", publicSavingAccountOpen.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", publicSavingAccountOpen.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_AMT", publicSavingAccountOpen.InsurancePolicyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURITY", publicSavingAccountOpen.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", publicSavingAccountOpen.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicSavingAccountOpen.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", publicSavingAccountOpen.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DEPOSIT_TO_REF_AC", publicSavingAccountOpen.TransferDepositTo_Ref_Ac, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_THIRD_PARTY_DATA", publicSavingAccountOpen.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingAccountOpen.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingAccountOpen.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingAccountOpen.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingAccountOpen.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUB_SAV_AC_NO", publicSavingAccountOpen.OutPubSav_Ac_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUB_SAV_AC_DISP_NO", publicSavingAccountOpen.OutPubSav_Ac_Disp_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingAccountOpen> lst = new List<PublicSavingAccountOpen>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingAccountOpen obj = new PublicSavingAccountOpen();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountStatus = drow["ACCOUNT_STATUS"].ToString();
                    obj.AccountClosedDate = drow["ACCOUNT_CLOSED_DATE"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.InterestTaxable = drow["INTEREST_TAXABLE"].ToString();
                    obj.SigneeName1 = drow["SIGNEE_NAME1"].ToString();
                    obj.SigneeName2 = drow["SIGNEE_NAME2"].ToString();
                    obj.ReasonForClosing = drow["REASON_FOR_CLOSING"].ToString();
                    obj.DueMandatoryAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DUE_MANDATORY_AMOUNT"].ToString()));
                    obj.AccClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACC_CLOSING_CHARGE"].ToString()));
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.FixedCollectAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECT_AMOUNT"].ToString()));
                    obj.CollectionType = drow["COLLECTION_TYPE"].ToString();
                    obj.DepositPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_PERIOD"].ToString()));
                    obj.DepositPeriodType = drow["DEPOSIT_PERIOD_TYPE"].ToString();
                    obj.ReferenceAccountNo = drow["REFERENCE_ACCOUNT_NO"].ToString();
                    obj.InsurancePolicyNo = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.InsurancePolicyAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSURANCE_POLICY_AMT"].ToString()));
                    obj.AmtAtMaturity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMT_AT_MATURITY"].ToString()));
                    obj.MaturityDate = drow["MATURITY_DATE"].ToString();
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.TransferIntPeriodic = drow["TRANSFER_INT_PERIODIC"].ToString();
                    obj.TransferDepositTo_Ref_Ac = drow["TRANSFER_DEPOSIT_TO_REF_AC"].ToString();
                    obj.ThirdPartyData = drow["THIRD_PARTY_DATA"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutPubSav_Ac_No = drow["OUT_PUB_SAV_AC_NO"].ToString();
                    obj.OutPubSav_Ac_Disp_No = drow["OUT_PUB_SAV_AC_DISP_NO"].ToString();

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
