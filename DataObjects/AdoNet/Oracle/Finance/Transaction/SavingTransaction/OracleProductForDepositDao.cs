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
    public class OracleProductForDepositDao : IProductForDepositDao
    {
        public object Get()
        {
            string sp = "productForDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ProductForDeposit> lst = new List<ProductForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ProductForDeposit obj = new ProductForDeposit();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(ProductForDeposit productForDeposit)
        {
            string sp = "productForDeposit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", productForDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", productForDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", productForDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", productForDeposit.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", productForDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", productForDeposit.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", productForDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(ProductForDeposit productForDeposit)
        {
            string sp = "productForDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", productForDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", productForDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", productForDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", productForDeposit.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", productForDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", productForDeposit.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ProductForDeposit> lst = new List<ProductForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ProductForDeposit obj = new ProductForDeposit();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetProductForDeposit(string productName)
        {
            string sp = "fn_saving_utility_pkg.p_product_for_deposit_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", productName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ProductForDeposit> lst = new List<ProductForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ProductForDeposit obj = new ProductForDeposit();
                    //obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    //obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    //obj.ClientName = drow["CLIENT_NAME"].ToString();
                    //obj.CenterName = drow["CENTER_NAME"].ToString();
                    //obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    //obj.RowCount = double.Parse(drow["ROW_COUNT"].ToString());

                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                  //  obj.ProductTypeCode = drow["PRODUCT_CODE"].ToString();

                   // obj.PenaltyLateInstallment = double.Parse(drow["PENALTY_LATE_INSTALLMENT"].ToString());
                    

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
