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
    public class OracleSavingTypeDao : ISavingTypeDao
    {
        public object SaveSavingType(SavingType savingType)
        {
            string sp = "savingType_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_CODE", savingType.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_DESC", savingType.ProductTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CATEGORY_CODE", savingType.ProductCategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", savingType.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingType.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchSavingType(SavingType savingType)
        {
            string sp = "savingType_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_CODE", savingType.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_DESC", savingType.ProductTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CATEGORY_CODE", savingType.ProductCategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", savingType.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingType> lst = new List<SavingType>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingType obj = new SavingType();
                    obj.ProductTypeCode = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.ProductTypeDesc = drow["PRODUCT_TYPE_DESC"].ToString();
                    obj.ProductCategoryCode = drow["PRODUCT_CATEGORY_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavingType(string SavingProductType)
        {
            string sp = "fn_saving_utility_pkg.p_saving_type_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_PRODUCT_TYPE", SavingProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingType> lst = new List<SavingType>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingType obj = new SavingType();
                    obj.ProductTypeCode = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.ProductTypeDesc = drow["PRODUCT_TYPE_DESC"].ToString();
                    obj.ProductCategoryCode = drow["PRODUCT_CATEGORY_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

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
