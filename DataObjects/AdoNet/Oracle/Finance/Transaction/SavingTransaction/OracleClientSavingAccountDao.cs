using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleClientSavingAccountDao : IClientSavingAccountDao
    {
        public object Get()
        {
            string sp = "clientSavingAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ClientSavingAccount> lst = new List<ClientSavingAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ClientSavingAccount obj = new ClientSavingAccount();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.SavingProductCode = drow["SavingProductCode"].ToString();
                    obj.AccountOpenDate = drow["AccountOpenDate"].ToString();
                    obj.AccountStatus = drow["AccountStatus"].ToString();
                    obj.AccountClosedDate = drow["AccountClosedDate"].ToString();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.InterestTaxable = drow["InterestTaxable"].ToString();
                    obj.SigneeName1 = drow["SigneeName1"].ToString();
                    obj.SigneeName2 = drow["SigneeName2"].ToString();
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.DueMandatoryAmount = double.Parse(drow["DueMandatoryAmount"].ToString());
                    obj.AccClosingCharge = double.Parse(drow["AccClosingCharge"].ToString());
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.DepositPeriod = int.Parse(drow["DepositPeriod"].ToString());
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.FixedCollectionType = drow["FixedCollectionType"].ToString();
                    obj.ReferenceAccountNo = drow["ReferenceAccountNo"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.InsurancePolicyAmt = double.Parse(drow["InsurancePolicyAmt"].ToString());
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.DepositPeriodType = drow["DepositPeriodType"].ToString();
                    obj.AmtAtMaturity = double.Parse(drow["AmtAtMaturity"].ToString());
                    obj.AccountOperationType = drow["AccountOperationType"].ToString();
                    obj.CollectionType = drow["CollectionType"].ToString();
                    obj.TransferIntPeriodic = drow["TransferIntPeriodic"].ToString();
                    obj.TransferDepositToRefAc = drow["TransferDepositToRefAc"].ToString();
                    obj.MaturityDate = drow["MaturityDate"].ToString();
                    obj.NextCollectionDate = drow["NextCollectionDate"].ToString();
                    obj.MannualClosingYN = drow["MannualClosingYN"].ToString();
                    obj.AccountStatusChangeDate = drow["AccountStatusChangeDate"].ToString();
                    obj.CollectionTypePeriod = int.Parse(drow["CollectionTypePeriod"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.PrematuredIntRatio = drow["PrematuredIntRatio"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(ClientSavingAccount clientSavingAccount)
        {
            string sp = "FN_SAVING_PKG.P_MF_SAVING_AC";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();



                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", clientSavingAccount.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", clientSavingAccount.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", clientSavingAccount.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", clientSavingAccount.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", clientSavingAccount.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountStatus", clientSavingAccount.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeCode", clientSavingAccount.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", clientSavingAccount.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SigneeName1", clientSavingAccount.SigneeName1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SigneeName2", clientSavingAccount.SigneeName2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", clientSavingAccount.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DueMandatoryAmount", clientSavingAccount.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccClosingCharge", clientSavingAccount.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", clientSavingAccount.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                
                

                paramList.Add(SqlHelper.GetOraParam(":p_fixed_collect_amount", clientSavingAccount.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deposit_period", clientSavingAccount.DepositPeriod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_employee_id", clientSavingAccount.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceAccountNo", clientSavingAccount.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", clientSavingAccount.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyAmt", clientSavingAccount.InsurancePolicyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionType", clientSavingAccount.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositPeriodType", clientSavingAccount.DepositPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AmtAtMaturity", clientSavingAccount.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaturityDate", clientSavingAccount.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", clientSavingAccount.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferIntPeriodic", clientSavingAccount.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", clientSavingAccount.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", clientSavingAccount.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":p_contraAccount", clientSavingAccount.ContraAccount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", clientSavingAccount.Action, OracleDbType.Double, ParameterDirection.Input));
                
                
                paramList.Add(SqlHelper.GetOraParam(":p_out_fiscal_year", null, OracleDbType.Double, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":v_out_mf_sav_ac_no", null, OracleDbType.Double, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":v_out_mf_sav_ac_disp_no", null, OracleDbType.Double, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":v_out_deposit_no", null, OracleDbType.Double, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 20;
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

        public object Search(ClientSavingAccount clientSavingAccount)
        {
            string sp = "clientSavingAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", clientSavingAccount.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", clientSavingAccount.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", clientSavingAccount.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", clientSavingAccount.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", clientSavingAccount.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", clientSavingAccount.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", clientSavingAccount.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", clientSavingAccount.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountStatus", clientSavingAccount.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountClosedDate", clientSavingAccount.AccountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeCode", clientSavingAccount.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", clientSavingAccount.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterestAmount", clientSavingAccount.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestTaxable", clientSavingAccount.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SigneeName1", clientSavingAccount.SigneeName1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SigneeName2", clientSavingAccount.SigneeName2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", clientSavingAccount.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DueMandatoryAmount", clientSavingAccount.DueMandatoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccClosingCharge", clientSavingAccount.AccClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", clientSavingAccount.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", clientSavingAccount.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", clientSavingAccount.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", clientSavingAccount.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", clientSavingAccount.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", clientSavingAccount.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", clientSavingAccount.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectAmount", clientSavingAccount.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositPeriod", clientSavingAccount.DepositPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", clientSavingAccount.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectionType", clientSavingAccount.FixedCollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceAccountNo", clientSavingAccount.ReferenceAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", clientSavingAccount.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyAmt", clientSavingAccount.InsurancePolicyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", clientSavingAccount.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositPeriodType", clientSavingAccount.DepositPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AmtAtMaturity", clientSavingAccount.AmtAtMaturity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOperationType", clientSavingAccount.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionType", clientSavingAccount.CollectionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferIntPeriodic", clientSavingAccount.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDepositToRefAc", clientSavingAccount.TransferDepositToRefAc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaturityDate", clientSavingAccount.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NextCollectionDate", clientSavingAccount.NextCollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MannualClosingYN", clientSavingAccount.MannualClosingYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountStatusChangeDate", clientSavingAccount.AccountStatusChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionTypePeriod", clientSavingAccount.CollectionTypePeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosingType", clientSavingAccount.MidTermClosingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrematuredIntRatio", clientSavingAccount.PrematuredIntRatio, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ClientSavingAccount> lst = new List<ClientSavingAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ClientSavingAccount obj = new ClientSavingAccount();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.SavingProductCode = drow["SavingProductCode"].ToString();
                    obj.AccountOpenDate = drow["AccountOpenDate"].ToString();
                    obj.AccountStatus = drow["AccountStatus"].ToString();
                    obj.AccountClosedDate = drow["AccountClosedDate"].ToString();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.InterestTaxable = drow["InterestTaxable"].ToString();
                    obj.SigneeName1 = drow["SigneeName1"].ToString();
                    obj.SigneeName2 = drow["SigneeName2"].ToString();
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.DueMandatoryAmount = double.Parse(drow["DueMandatoryAmount"].ToString());
                    obj.AccClosingCharge = double.Parse(drow["AccClosingCharge"].ToString());
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.DepositPeriod = int.Parse(drow["DepositPeriod"].ToString());
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.FixedCollectionType = drow["FixedCollectionType"].ToString();
                    obj.ReferenceAccountNo = drow["ReferenceAccountNo"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.InsurancePolicyAmt = double.Parse(drow["InsurancePolicyAmt"].ToString());
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.DepositPeriodType = drow["DepositPeriodType"].ToString();
                    obj.AmtAtMaturity = double.Parse(drow["AmtAtMaturity"].ToString());
                    obj.AccountOperationType = drow["AccountOperationType"].ToString();
                    obj.CollectionType = drow["CollectionType"].ToString();
                    obj.TransferIntPeriodic = drow["TransferIntPeriodic"].ToString();
                    obj.TransferDepositToRefAc = drow["TransferDepositToRefAc"].ToString();
                    obj.MaturityDate = drow["MaturityDate"].ToString();
                    obj.NextCollectionDate = drow["NextCollectionDate"].ToString();
                    obj.MannualClosingYN = drow["MannualClosingYN"].ToString();
                    obj.AccountStatusChangeDate = drow["AccountStatusChangeDate"].ToString();
                    obj.CollectionTypePeriod = int.Parse(drow["CollectionTypePeriod"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.PrematuredIntRatio = drow["PrematuredIntRatio"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemberAccountOpen(string offCode, string memberName)
        {
            string sp = "fn_member_clients_pkg.p_mem_ac_open_search_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();



                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ClientSavingAccount> lst = new List<ClientSavingAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ClientSavingAccount obj = new ClientSavingAccount();


                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemberAccountForCheque(string offCode, string clientNo)
        {
            string sp = "fn_saving_utility_pkg.p_mf_acc_for_cheque_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();



                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", clientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ClientSavingAccount> lst = new List<ClientSavingAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ClientSavingAccount obj = new ClientSavingAccount();


                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    


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
