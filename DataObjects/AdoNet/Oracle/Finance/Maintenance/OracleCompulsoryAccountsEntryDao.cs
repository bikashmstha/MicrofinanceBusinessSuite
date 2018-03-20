using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCompulsoryAccountsEntryDao : ICompulsoryAccountsEntryDao
    {
        public object Get()
        {
            string sp = "FN_SAVING_UTILITY_PKG.p_compulsory_account_list ";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_account_code", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));                
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CompulsoryAccountsEntry> lst = new List<CompulsoryAccountsEntry>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CompulsoryAccountsEntry obj = new CompulsoryAccountsEntry();
                    obj.CompulsoryAccountCode = drow["COMPULSORY_ACCOUNT_CODE"].ToString();
                    obj.CompulsoryAccountDesc = drow["COMPULSORY_ACCOUNT_DESC"].ToString();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductType = drow["PRODUCT_TYPE"].ToString();
                    obj.ProductName = drow["SAV_PRODUCT"].ToString();


                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();

                   
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(CompulsoryAccountsEntry compulsoryAccountsEntry)
        {
            string sp = "FN_SAVING_UTILITY_PKG.P_FN_COMPULSORY_ACCOUNTS ";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_compulsory_account_desc", compulsoryAccountsEntry.CompulsoryAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_product_code", compulsoryAccountsEntry.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_product_type", compulsoryAccountsEntry.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", compulsoryAccountsEntry.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_active_flag", compulsoryAccountsEntry.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", compulsoryAccountsEntry.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_compulsory_account_code", compulsoryAccountsEntry.CompulsoryAccountCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", CompulsoryAccountsEntry.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", CompulsoryAccountsEntry.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                
                compulsoryAccountsEntry.CompulsoryAccountCode=paramList[paramList.Count - 3].Value.ToString();

                List<CompulsoryAccountsEntry> lst = new List<CompulsoryAccountsEntry>();
                compulsoryAccountsEntry.Action = "U";
                lst.Add(compulsoryAccountsEntry);
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(CompulsoryAccountsEntry CompulsoryAccountsEntry)
        {
            string sp = "FN_SAVING_UTILITY_PKG.p_compulsory_account_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CompulsoryAccountCode", CompulsoryAccountsEntry.CompulsoryAccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CompulsoryAccountDesc", CompulsoryAccountsEntry.CompulsoryAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", CompulsoryAccountsEntry.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductType", CompulsoryAccountsEntry.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", CompulsoryAccountsEntry.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", CompulsoryAccountsEntry.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", CompulsoryAccountsEntry.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CompulsoryAccountsEntry> lst = new List<CompulsoryAccountsEntry>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CompulsoryAccountsEntry obj = new CompulsoryAccountsEntry();
                    obj.CompulsoryAccountCode = drow["CompulsoryAccountCode"].ToString();
                    obj.CompulsoryAccountDesc = drow["CompulsoryAccountDesc"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductType = drow["ProductType"].ToString();


                    obj.ActiveFlag = drow["ActiveFlag"].ToString();

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
