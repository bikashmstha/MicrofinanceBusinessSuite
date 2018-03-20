using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle
{
    public class OracleGlTransactionMasterDao : IGlTransactionMasterDao
    {
        private static IGlTransactionDetailDao glTransactionDetailDao = DataAccess.GlTransactionDetailDao;
        public object SaveGlTransactionMaster(GlTransactionMaster glTransactionMaster)
        {
            string sp = "gl_transaction_pkg.p_insert_gl_transaction_master";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", glTransactionMaster.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", glTransactionMaster.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", glTransactionMaster.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_FLAG", glTransactionMaster.ModifiedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_FLAG", glTransactionMaster.AuditedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_DATE", glTransactionMaster.AuditedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_BY", glTransactionMaster.AuditedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", glTransactionMaster.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_NO", glTransactionMaster.ApprovedNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", glTransactionMaster.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                
                paramList.Add(SqlHelper.GetOraParam(":p_POSTED_Y_N", glTransactionMaster.PostedYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", glTransactionMaster.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", glTransactionMaster.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", glTransactionMaster.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", glTransactionMaster.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", glTransactionMaster.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_FLAG", glTransactionMaster.CloseFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO_AGAINST", glTransactionMaster.VoucherNoAgainst, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", glTransactionMaster.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO_REFERENCE", glTransactionMaster.VoucherNoReference, OracleDbType.Varchar2, ParameterDirection.Input));
                
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_SEQ_NO", glTransactionMaster.VoucherSeqNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", glTransactionMaster.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", glTransactionMaster.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", glTransactionMaster.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DR_AMOUNT", glTransactionMaster.TotalDrAmount, OracleDbType.Double, ParameterDirection.Input));
                
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", glTransactionMaster.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_VOUCHER_NO", glTransactionMaster.OutVoucherNo, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_HIST_SEQ_NO", glTransactionMaster.OutHistSeq_No, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                if(glTransactionMaster.GlTransactionDetail.Count==0)
                {
                    glTransactionDetailDao.SaveGlTransactionDetail(glTransactionMaster.GlTransactionDetail,tran,paramList[26].Value.ToString());
                }

                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchGlTransactionMaster(GlTransactionMaster glTransactionMaster)
        {
            string sp = "glTransactionMaster_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", glTransactionMaster.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", glTransactionMaster.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", glTransactionMaster.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_FLAG", glTransactionMaster.ModifiedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_FLAG", glTransactionMaster.AuditedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_DATE", glTransactionMaster.AuditedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AUDITED_BY", glTransactionMaster.AuditedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", glTransactionMaster.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_NO", glTransactionMaster.ApprovedNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", glTransactionMaster.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTED_Y_N", glTransactionMaster.PostedYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", glTransactionMaster.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", glTransactionMaster.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", glTransactionMaster.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", glTransactionMaster.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", glTransactionMaster.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_FLAG", glTransactionMaster.CloseFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO_AGAINST", glTransactionMaster.VoucherNoAgainst, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", glTransactionMaster.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO_REFERENCE", glTransactionMaster.VoucherNoReference, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_SEQ_NO", glTransactionMaster.VoucherSeqNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", glTransactionMaster.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", glTransactionMaster.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", glTransactionMaster.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DR_AMOUNT", glTransactionMaster.TotalDrAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", glTransactionMaster.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_VOUCHER_NO", glTransactionMaster.OutVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_HIST_SEQ_NO", glTransactionMaster.OutHistSeq_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GlTransactionMaster> lst = new List<GlTransactionMaster>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GlTransactionMaster obj = new GlTransactionMaster();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.ModifiedFlag = drow["MODIFIED_FLAG"].ToString();
                    obj.AuditedFlag = drow["AUDITED_FLAG"].ToString();
                    obj.AuditedDate = drow["AUDITED_DATE"].ToString();
                    obj.AuditedBy = drow["AUDITED_BY"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ApprovedNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_NO"].ToString()));
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.PostedYN = drow["POSTED_Y_N"].ToString();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();


                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherType = drow["VOUCHER_TYPE"].ToString();
                    obj.CloseFlag = drow["CLOSE_FLAG"].ToString();
                    obj.VoucherNoAgainst = drow["VOUCHER_NO_AGAINST"].ToString();
                    obj.ChequeBillNo = drow["CHEQUE_BILL_NO"].ToString();
                    obj.VoucherNoReference = drow["VOUCHER_NO_REFERENCE"].ToString();
                    obj.VoucherSeqNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["VOUCHER_SEQ_NO"].ToString()));
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.ApprovedDateBs = drow["APPROVED_DATE_BS"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.TotalDrAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DR_AMOUNT"].ToString()));
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutVoucherNo = drow["OUT_VOUCHER_NO"].ToString();
                    obj.OutHistSeq_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_HIST_SEQ_NO"].ToString()));

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
