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
    public class OracleAbbsSavingDepositDao : IAbbsSavingDepositDao
    {
        public object SaveAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit)
        {
            string sp = "abbsSavingDeposit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", abbsSavingDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", abbsSavingDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", abbsSavingDeposit.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", abbsSavingDeposit.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", abbsSavingDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", abbsSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", abbsSavingDeposit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", abbsSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_TYPE_DESC", abbsSavingDeposit.SavTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", abbsSavingDeposit.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", abbsSavingDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit)
        {
            string sp = "abbsSavingDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", abbsSavingDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", abbsSavingDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", abbsSavingDeposit.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", abbsSavingDeposit.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", abbsSavingDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", abbsSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", abbsSavingDeposit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", abbsSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_TYPE_DESC", abbsSavingDeposit.SavTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", abbsSavingDeposit.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AbbsSavingDeposit> lst = new List<AbbsSavingDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AbbsSavingDeposit obj = new AbbsSavingDeposit();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_NO"].ToString()));
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.MandatorySavingType = drow["MANDATORY_SAVING_TYPE"].ToString();
                    obj.SavTypeDesc = drow["SAV_TYPE_DESC"].ToString();
                    obj.FlagForPosting = drow["FLAG_FOR_POSTING"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAbbsSavingDeposit(string OfficeCode)
        {
            string sp = "transaction_approval_pkg.p_abbs_saving_deposit_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AbbsSavingDeposit> lst = new List<AbbsSavingDeposit>();

                for (int i = 0; i < 10; i++)
                {
                    AbbsSavingDeposit obj = new AbbsSavingDeposit();
                    obj.ClientCode = i.ToString();
                    obj.ClientName = i.ToString();
                    obj.PenaltyAmount = i;
                    obj.DepositNo = i;
                    obj.SavingAccountNo = i.ToString();
                    obj.DepositAmount = i;
                    obj.AccountDesc = i.ToString();
                    obj.MandatorySavingType = i.ToString();
                    obj.SavTypeDesc = i.ToString();
                    obj.FlagForPosting = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    AbbsSavingDeposit obj = new AbbsSavingDeposit();
                //    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                //    obj.ClientName = drow["CLIENT_NAME"].ToString();
                //    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                //    obj.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_NO"].ToString()));
                //    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                //    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                //    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                //    obj.MandatorySavingType = drow["MANDATORY_SAVING_TYPE"].ToString();
                //    obj.SavTypeDesc = drow["SAV_TYPE_DESC"].ToString();
                //    obj.FlagForPosting = drow["FLAG_FOR_POSTING"].ToString();

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
