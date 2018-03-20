using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Security;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleAccountHeadEntryDao : IAccountHeadEntryDao
    {
        private List<OracleParameter> PrepareParameterList(AccountHeadEntry accountHeadEntry)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_account_desc", accountHeadEntry.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_account_code_master", accountHeadEntry.AccountCodeMaster, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_short_name", accountHeadEntry.ShortName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_group_no", accountHeadEntry.GroupNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cash_bank_others", accountHeadEntry.CashBankOthers, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_contra_account_y_n", accountHeadEntry.ContraAccountYN, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_consolidate_y_n", accountHeadEntry.ConsolidateYN, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active_flag", accountHeadEntry.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_reason_for_inactive", accountHeadEntry.ReasonForInActive, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_opening_bal", accountHeadEntry.OpeningBal, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_opening_type", accountHeadEntry.OpeningType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_category_initial", accountHeadEntry.CategoryInitial, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_transaction_currency_code", accountHeadEntry.TransactionCurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_transfer_date", accountHeadEntry.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_display_seq", accountHeadEntry.DisplaySeq, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", accountHeadEntry.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_user", accountHeadEntry.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_date", accountHeadEntry.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_account_code", accountHeadEntry.AccountCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":v_out_account_no", accountHeadEntry.AccountNo, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", accountHeadEntry.Action, OracleDbType.Int64, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[21].Size = 10;
            paramList[22].Size = 100;

            return paramList;

        }

        public List<AccountHeadEntry> SearchAccountHead(AccountHeadEntry accountHead)
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();

                //                @"SELECT * FROM ( 
                //                        SELECT ACCOUNT_CODE,ACCOUNT_NO,ACCOUNT_DESC,
                //                          ROW_NUMBER() OVER (ORDER BY ACCOUNT_CODE) ROW_COUNT 
                //                            FROM gl_account_head 
                //                         WHERE  1=1 
                //                            AND (UPPER(ACCOUNT_DESC) LIKE NVL(:accountDesc, '%') OR ACCOUNT_NO LIKE NVL(:accountDesc, '%'))
                //                            AND ACTIVE_FLAG = 'Y' 
                //                        ORDER BY ACCOUNT_NO ASC
                //                        )where  ROW_COUNT BETWEEN :startIndex and :upperBound ";
                string strQuery = "SELECT  ACCOUNT_CODE, ACCOUNT_NO, ACCOUNT_DESC FROM gl_account_head WHERE 1=1 ";
                if (!string.IsNullOrEmpty(accountHead.AccountDesc))
                {
                    strQuery = strQuery + "AND UPPER(ACCOUNT_DESC) LIKE '%" + accountHead.AccountDesc.ToUpper() + "%'AND ACTIVE_FLAG = 'Y'";

                }





                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<AccountHeadEntry> accHeads = new List<AccountHeadEntry>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AccountHeadEntry v = new AccountHeadEntry();
                    v.AccountCode = dr["ACCOUNT_CODE"].ToString();
                    v.AccountDesc = dr["ACCOUNT_DESC"].ToString();
                    v.AccountNo = dr["ACCOUNT_NO"].ToString();



                    accHeads.Add(v);


                }
                return accHeads;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<AccountHeadEntry> GetSearchAccountHead(string accountNo,string accountNameDesc, string groupNo)
        {
            try
            {
                
                string SP = "GL_ACCOUNT_PKG.p_account_head_detail";

                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_account_no", accountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_account_desc", accountNameDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_group_no", groupNo, OracleDbType.Varchar2, ParameterDirection.Input));                
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<AccountHeadEntry> lst = new List<AccountHeadEntry>();


                AccountHeadEntry obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new AccountHeadEntry();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ShortName = drow["SHORT_NAME"].ToString();
                    obj.GroupNo = drow["GROUP_NO"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.CategoryInitial = drow["CATEGORY_INITIAL"].ToString();
                    obj.CashBankOthers = drow["CASH_BANK_OTHERS"].ToString();
                    obj.ConsolidateYN = drow["CONSOLIDATE_Y_N"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    obj.Action = "U";
                   

                    obj.Action = "U";
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveAccountHeadEntry(AccountHeadEntry accountHeadEntry)
        {
            string SP = "ms_general_definition_pkg.p_iud_narration_detail"; ;
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new GetConnection().GetDbConn();
            List<OracleParameter> paramList = PrepareParameterList(accountHeadEntry);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[3].Value.ToString();
                oMsg.OutResultMessage = paramList[4].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<AccountHeadEntry> GetAccountHeadShort(AccountHeadEntry accountHead)
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();

                //                @"SELECT * FROM ( 
                //                        SELECT ACCOUNT_CODE,ACCOUNT_NO,ACCOUNT_DESC,
                //                          ROW_NUMBER() OVER (ORDER BY ACCOUNT_CODE) ROW_COUNT 
                //                            FROM gl_account_head 
                //                         WHERE  1=1 
                //                            AND (UPPER(ACCOUNT_DESC) LIKE NVL(:accountDesc, '%') OR ACCOUNT_NO LIKE NVL(:accountDesc, '%'))
                //                            AND ACTIVE_FLAG = 'Y' 
                //                        ORDER BY ACCOUNT_NO ASC
                //                        )where  ROW_COUNT BETWEEN :startIndex and :upperBound ";
                string strQuery = "SELECT  ACCOUNT_CODE, ACCOUNT_NO, ACCOUNT_DESC FROM gl_account_head WHERE 1=1 ";
                if (!string.IsNullOrEmpty(accountHead.AccountDesc))
                {
                    strQuery = strQuery + "AND UPPER(ACCOUNT_DESC) LIKE '%" + accountHead.AccountDesc.ToUpper() + "%'AND ACTIVE_FLAG = 'Y'";

                }





                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<AccountHeadEntry> accHeads = new List<AccountHeadEntry>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AccountHeadEntry v = new AccountHeadEntry();
                    v.AccountCode = dr["ACCOUNT_CODE"].ToString();
                    v.AccountDesc = dr["ACCOUNT_DESC"].ToString();
                    v.AccountNo = dr["ACCOUNT_NO"].ToString();



                    accHeads.Add(v);


                }
                return accHeads;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public object GetContraAccount(string offCode, string accountDesc)
        {
            string sp = "gl_account_pkg.p_contra_account_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_off_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_account_desc", accountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountHeadEntry> lst = new List<AccountHeadEntry>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountHeadEntry obj = new AccountHeadEntry();
                    /*FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     */
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();


                    obj.Action = "U";
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