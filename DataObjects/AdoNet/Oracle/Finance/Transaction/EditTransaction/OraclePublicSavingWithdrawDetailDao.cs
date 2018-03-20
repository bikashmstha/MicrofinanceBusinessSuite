using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OraclePublicSavingWithdrawDetailDao : IPublicSavingWithdrawDetailDao
    {
        public object SavePublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail)
        {
            string sp = "publicSavingWithdrawDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingWithdrawDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", publicSavingWithdrawDetail.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingWithdrawDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", publicSavingWithdrawDetail.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingWithdrawDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingWithdrawDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingWithdrawDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicSavingWithdrawDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicSavingWithdrawDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingWithdrawDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicSavingWithdrawDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicSavingWithdrawDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicSavingWithdrawDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingWithdrawDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicSavingWithdrawDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicSavingWithdrawDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingWithdrawDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingWithdrawDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE", publicSavingWithdrawDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_BS", publicSavingWithdrawDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_TYPE", publicSavingWithdrawDetail.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicSavingWithdrawDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicSavingWithdrawDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", publicSavingWithdrawDetail.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", publicSavingWithdrawDetail.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicSavingWithdrawDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicSavingWithdrawDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_LIMIT", publicSavingWithdrawDetail.WithdrawLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicSavingWithdrawDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicSavingWithdrawDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", publicSavingWithdrawDetail.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_DEPOSIT_NO", publicSavingWithdrawDetail.ReferenceDepositNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_WITHDRAWAL_NO", publicSavingWithdrawDetail.ReferenceWithdrawalNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_NO", publicSavingWithdrawDetail.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_DATE", publicSavingWithdrawDetail.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicSavingWithdrawDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail)
        {
            string sp = "publicSavingWithdrawDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingWithdrawDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", publicSavingWithdrawDetail.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingWithdrawDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", publicSavingWithdrawDetail.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingWithdrawDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingWithdrawDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingWithdrawDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_CODE", publicSavingWithdrawDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicSavingWithdrawDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingWithdrawDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicSavingWithdrawDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicSavingWithdrawDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicSavingWithdrawDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingWithdrawDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_STATUS", publicSavingWithdrawDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicSavingWithdrawDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingWithdrawDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingWithdrawDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE", publicSavingWithdrawDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_BS", publicSavingWithdrawDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_TYPE", publicSavingWithdrawDetail.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicSavingWithdrawDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicSavingWithdrawDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", publicSavingWithdrawDetail.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", publicSavingWithdrawDetail.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicSavingWithdrawDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicSavingWithdrawDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_LIMIT", publicSavingWithdrawDetail.WithdrawLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicSavingWithdrawDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicSavingWithdrawDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", publicSavingWithdrawDetail.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_DEPOSIT_NO", publicSavingWithdrawDetail.ReferenceDepositNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_WITHDRAWAL_NO", publicSavingWithdrawDetail.ReferenceWithdrawalNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_NO", publicSavingWithdrawDetail.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_DATE", publicSavingWithdrawDetail.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingWithdrawDetail> lst = new List<PublicSavingWithdrawDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingWithdrawDetail obj = new PublicSavingWithdrawDetail();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.ValueDate = drow["VALUE_DATE"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AcOfficeCode = drow["AC_OFFICE_CODE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.AccountStatus = drow["ACCOUNT_STATUS"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.WithdrawDate = drow["WITHDRAW_DATE"].ToString();
                    obj.WithdrawDateBs = drow["WITHDRAW_DATE_BS"].ToString();
                    obj.WithdrawType = drow["WITHDRAW_TYPE"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.JointImagePath = drow["JOINT_IMAGE_PATH"].ToString();
                    obj.ChargeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHARGE_AMOUNT"].ToString()));
                    obj.ChargeType = drow["CHARGE_TYPE"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.WithdrawLimit = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_LIMIT"].ToString()));
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ChargeSource = drow["CHARGE_SOURCE"].ToString();
                    obj.ReferenceDepositNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REFERENCE_DEPOSIT_NO"].ToString()));
                    obj.ReferenceWithdrawalNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REFERENCE_WITHDRAWAL_NO"].ToString()));
                    obj.ChargeVoucherNo = drow["CHARGE_VOUCHER_NO"].ToString();
                    obj.ChargeVoucherDate = drow["CHARGE_VOUCHER_DATE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPubSavWithDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_saving_utility_pkg.p_pub_sav_with_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_WITHDRAWAL_NO", WithdrawalNo, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingWithdrawDetail> lst = new List<PublicSavingWithdrawDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingWithdrawDetail obj = new PublicSavingWithdrawDetail();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.ValueDate = drow["VALUE_DATE"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AcOfficeCode = drow["AC_OFFICE_CODE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.AccountStatus = drow["ACCOUNT_STATUS"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.WithdrawDate = drow["WITHDRAW_DATE"].ToString();
                    obj.WithdrawDateBs = drow["WITHDRAW_DATE_BS"].ToString();
                    obj.WithdrawType = drow["WITHDRAW_TYPE"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.JointImagePath = drow["JOINT_IMAGE_PATH"].ToString();
                    obj.ChargeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHARGE_AMOUNT"].ToString()));
                    obj.ChargeType = drow["CHARGE_TYPE"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.WithdrawLimit = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_LIMIT"].ToString()));
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ChargeSource = drow["CHARGE_SOURCE"].ToString();
                    obj.ReferenceDepositNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REFERENCE_DEPOSIT_NO"].ToString()));
                    obj.ReferenceWithdrawalNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REFERENCE_WITHDRAWAL_NO"].ToString()));
                    obj.ChargeVoucherNo = drow["CHARGE_VOUCHER_NO"].ToString();
                    obj.ChargeVoucherDate = drow["CHARGE_VOUCHER_DATE"].ToString();

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
