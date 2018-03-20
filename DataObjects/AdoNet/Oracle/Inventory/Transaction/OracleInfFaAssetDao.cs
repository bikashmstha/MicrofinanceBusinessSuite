using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using DataObjects.Interfaces.Inventory;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Inventory
{
    public class OracleInfFaAssetDao : IInfFaAssetDao
    {
        public object SaveInfFaAsset(InfFaAsset infFaAsset)
        {
            string sp = "in_fa_asset_info_pkg.p_in_fa_asset";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", infFaAsset.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_SERIAL_NO", infFaAsset.AssetSerialNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", infFaAsset.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_DESC", infFaAsset.AssetDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", infFaAsset.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", infFaAsset.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", infFaAsset.SupplierCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_CODE", infFaAsset.CategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", infFaAsset.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED", infFaAsset.DateAquired, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD", infFaAsset.DateSold, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PURCHASE_PRICE", infFaAsset.PurchasePrice, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_MATENANCE", infFaAsset.TotalMatenance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPRECIATION", infFaAsset.TotalDepreciation, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIATION_METHOD", infFaAsset.DepreciationMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_LIFE", infFaAsset.DepreciableLife, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SALVAGE_VALUE", infFaAsset.SalvageValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", infFaAsset.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEXT_SCHED_MAT", infFaAsset.NextSchedMat, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_PERCENTAGE", infFaAsset.DepreciablePercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SOLD_AMOUNT", infFaAsset.SoldAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE", infFaAsset.LastDeprDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_AMT", infFaAsset.LastDeprAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM", infFaAsset.CalcDeprFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO", infFaAsset.CalcDeprTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_STATUS", infFaAsset.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CATEGORY", infFaAsset.AssetCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", infFaAsset.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURR_DEPT_CODE", infFaAsset.CurrDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_Y_N", infFaAsset.TransferYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_ASSET_CODE", infFaAsset.TransferAssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DONAR", infFaAsset.Donar, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", infFaAsset.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", infFaAsset.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", infFaAsset.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERT_UPDATE", infFaAsset.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_ASSET_CODE", infFaAsset.OutAssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchInfFaAsset(InfFaAsset infFaAsset)
        {
            string sp = "infFaAsset_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", infFaAsset.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_SERIAL_NO", infFaAsset.AssetSerialNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", infFaAsset.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_DESC", infFaAsset.AssetDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", infFaAsset.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", infFaAsset.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", infFaAsset.SupplierCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_CODE", infFaAsset.CategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", infFaAsset.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED", infFaAsset.DateAquired, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD", infFaAsset.DateSold, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PURCHASE_PRICE", infFaAsset.PurchasePrice, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_MATENANCE", infFaAsset.TotalMatenance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPRECIATION", infFaAsset.TotalDepreciation, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIATION_METHOD", infFaAsset.DepreciationMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_LIFE", infFaAsset.DepreciableLife, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SALVAGE_VALUE", infFaAsset.SalvageValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", infFaAsset.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEXT_SCHED_MAT", infFaAsset.NextSchedMat, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_PERCENTAGE", infFaAsset.DepreciablePercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SOLD_AMOUNT", infFaAsset.SoldAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE", infFaAsset.LastDeprDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_AMT", infFaAsset.LastDeprAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM", infFaAsset.CalcDeprFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO", infFaAsset.CalcDeprTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_STATUS", infFaAsset.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CATEGORY", infFaAsset.AssetCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", infFaAsset.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURR_DEPT_CODE", infFaAsset.CurrDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_Y_N", infFaAsset.TransferYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_ASSET_CODE", infFaAsset.TransferAssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DONAR", infFaAsset.Donar, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", infFaAsset.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", infFaAsset.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", infFaAsset.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERT_UPDATE", infFaAsset.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_ASSET_CODE", infFaAsset.OutAssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InfFaAsset> lst = new List<InfFaAsset>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InfFaAsset obj = new InfFaAsset();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.AssetSerialNo = drow["ASSET_SERIAL_NO"].ToString();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.AssetDesc = drow["ASSET_DESC"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.SupplierCode = drow["SUPPLIER_CODE"].ToString();
                    obj.CategoryCode = drow["CATEGORY_CODE"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    obj.DateAquired = drow["DATE_AQUIRED"].ToString();
                    obj.DateSold = drow["DATE_SOLD"].ToString();
                    obj.PurchasePrice = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PURCHASE_PRICE"].ToString()));
                    obj.TotalMatenance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_MATENANCE"].ToString()));
                    obj.TotalDepreciation = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DEPRECIATION"].ToString()));
                    obj.DepreciationMethod = drow["DEPRECIATION_METHOD"].ToString();
                    obj.DepreciableLife = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_LIFE"].ToString()));
                    obj.SalvageValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SALVAGE_VALUE"].ToString()));
                    obj.CurrentValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_VALUE"].ToString()));
                    obj.NextSchedMat = drow["NEXT_SCHED_MAT"].ToString();
                    obj.DepreciablePercentage = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_PERCENTAGE"].ToString()));
                    obj.SoldAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SOLD_AMOUNT"].ToString()));
                    obj.LastDeprDate = drow["LAST_DEPR_DATE"].ToString();
                    obj.LastDeprAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LAST_DEPR_AMT"].ToString()));
                    obj.CalcDeprFrom = drow["CALC_DEPR_FROM"].ToString();
                    obj.CalcDeprTo = drow["CALC_DEPR_TO"].ToString();
                    obj.Status = drow["STATUS"].ToString();
                    obj.AssetCategory = drow["ASSET_CATEGORY"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.CurrDeptCode = drow["CURR_DEPT_CODE"].ToString();
                    obj.TransferYN = drow["TRANSFER_Y_N"].ToString();
                    obj.TransferAssetCode = drow["TRANSFER_ASSET_CODE"].ToString();
                    obj.Donar = drow["DONAR"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.Username = drow["USERNAME"].ToString();
                    obj.Date1 = drow["DATE1"].ToString();
                    obj.Action = drow["SERT_UPDATE"].ToString();
                    obj.OutAssetCode = drow["OUT_ASSET_CODE"].ToString();

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
