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
    public class OracleAssetDetailDao : IAssetDetailDao
    {
        public object SaveAssetDetail(AssetDetail assetDetail)
        {
            string sp = "assetDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", assetDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", assetDetail.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", assetDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", assetDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_DESC", assetDetail.AssetDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", assetDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", assetDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", assetDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", assetDetail.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", assetDetail.SupplierCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_CODE", assetDetail.CategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_DESC", assetDetail.CategoryDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", assetDetail.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED", assetDetail.DateAquired, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD", assetDetail.DateSold, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PURCHASE_PRICE", assetDetail.PurchasePrice, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_MAINTENANCE", assetDetail.TotalMaintenance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPRECIATION", assetDetail.TotalDepreciation, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIATION_METHOD", assetDetail.DepreciationMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_LIFE", assetDetail.DepreciableLife, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SALVAGE_VALUE", assetDetail.SalvageValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", assetDetail.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEXT_SCHED_MAINT", assetDetail.NextSchedMaint, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_PERCENTAGE", assetDetail.DepreciablePercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SOLD_AMOUNT", assetDetail.SoldAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE", assetDetail.LastDeprDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_AMT", assetDetail.LastDeprAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM", assetDetail.CalcDeprFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO", assetDetail.CalcDeprTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_STATUS", assetDetail.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CATEGORY", assetDetail.AssetCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", assetDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DONAR", assetDetail.Donar, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_SERIAL_NO", assetDetail.AssetSerialNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_DESC", assetDetail.SupplierDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED_BS", assetDetail.DateAquiredBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD_BS", assetDetail.DateSoldBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE_BS", assetDetail.LastDeprDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM_BS", assetDetail.CalcDeprFrom_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO_BS", assetDetail.CalcDeprTo_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", assetDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", assetDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchAssetDetail(AssetDetail assetDetail)
        {
            string sp = "assetDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", assetDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", assetDetail.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", assetDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", assetDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_DESC", assetDetail.AssetDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", assetDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", assetDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", assetDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", assetDetail.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", assetDetail.SupplierCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_CODE", assetDetail.CategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_DESC", assetDetail.CategoryDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", assetDetail.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED", assetDetail.DateAquired, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD", assetDetail.DateSold, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PURCHASE_PRICE", assetDetail.PurchasePrice, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_MAINTENANCE", assetDetail.TotalMaintenance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPRECIATION", assetDetail.TotalDepreciation, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIATION_METHOD", assetDetail.DepreciationMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_LIFE", assetDetail.DepreciableLife, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SALVAGE_VALUE", assetDetail.SalvageValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", assetDetail.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEXT_SCHED_MAINT", assetDetail.NextSchedMaint, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPRECIABLE_PERCENTAGE", assetDetail.DepreciablePercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SOLD_AMOUNT", assetDetail.SoldAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE", assetDetail.LastDeprDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_AMT", assetDetail.LastDeprAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM", assetDetail.CalcDeprFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO", assetDetail.CalcDeprTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_STATUS", assetDetail.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CATEGORY", assetDetail.AssetCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", assetDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DONAR", assetDetail.Donar, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_SERIAL_NO", assetDetail.AssetSerialNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_DESC", assetDetail.SupplierDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_AQUIRED_BS", assetDetail.DateAquiredBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE_SOLD_BS", assetDetail.DateSoldBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_DEPR_DATE_BS", assetDetail.LastDeprDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_FROM_BS", assetDetail.CalcDeprFrom_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CALC_DEPR_TO_BS", assetDetail.CalcDeprTo_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", assetDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AssetDetail> lst = new List<AssetDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AssetDetail obj = new AssetDetail();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.AssetDesc = drow["ASSET_DESC"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.SupplierCode = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUPPLIER_CODE"].ToString()));
                    obj.CategoryCode = drow["CATEGORY_CODE"].ToString();
                    obj.CategoryDesc = drow["CATEGORY_DESC"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    obj.DateAquired = drow["DATE_AQUIRED"].ToString();
                    obj.DateSold = drow["DATE_SOLD"].ToString();
                    obj.PurchasePrice = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PURCHASE_PRICE"].ToString()));
                    obj.TotalMaintenance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_MAINTENANCE"].ToString()));
                    obj.TotalDepreciation = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DEPRECIATION"].ToString()));
                    obj.DepreciationMethod = drow["DEPRECIATION_METHOD"].ToString();
                    obj.DepreciableLife = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_LIFE"].ToString()));
                    obj.SalvageValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SALVAGE_VALUE"].ToString()));
                    obj.CurrentValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_VALUE"].ToString()));
                    obj.NextSchedMaint = drow["NEXT_SCHED_MAINT"].ToString();
                    obj.DepreciablePercentage = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_PERCENTAGE"].ToString()));
                    obj.SoldAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SOLD_AMOUNT"].ToString()));
                    obj.LastDeprDate = drow["LAST_DEPR_DATE"].ToString();
                    obj.LastDeprAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LAST_DEPR_AMT"].ToString()));
                    obj.CalcDeprFrom = drow["CALC_DEPR_FROM"].ToString();
                    obj.CalcDeprTo = drow["CALC_DEPR_TO"].ToString();
                    obj.Status = drow["STATUS"].ToString();
                    obj.AssetCategory = drow["ASSET_CATEGORY"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Donar = drow["DONAR"].ToString();
                    obj.AssetSerialNo = drow["ASSET_SERIAL_NO"].ToString();
                    obj.SupplierDesc = drow["SUPPLIER_DESC"].ToString();
                    obj.DateAquiredBs = drow["DATE_AQUIRED_BS"].ToString();
                    obj.DateSoldBs = drow["DATE_SOLD_BS"].ToString();
                    obj.LastDeprDate_Bs = drow["LAST_DEPR_DATE_BS"].ToString();
                    obj.CalcDeprFrom_Bs = drow["CALC_DEPR_FROM_BS"].ToString();
                    obj.CalcDeprTo_Bs = drow["CALC_DEPR_TO_BS"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAssetDetail(AssetDetail assetDetail)
        {
            string sp = "in_asset_utility_pkg.p_asset_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", assetDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_ASSET_CODE", assetDetail.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CATEGORY_CODE", assetDetail.CategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
               
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CATEGORY", assetDetail.AssetCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DONAR", assetDetail.Donar, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_from_date", assetDetail.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_to_date", assetDetail.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));             
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AssetDetail> lst = new List<AssetDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AssetDetail obj = new AssetDetail();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.AssetDesc = drow["ASSET_DESC"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.SupplierCode = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUPPLIER_CODE"].ToString()));
                    obj.CategoryCode = drow["CATEGORY_CODE"].ToString();
                    obj.CategoryDesc = drow["CATEGORY_DESC"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    obj.DateAquired = drow["DATE_AQUIRED"].ToString();
                    obj.DateSold = drow["DATE_SOLD"].ToString();
                    obj.PurchasePrice = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PURCHASE_PRICE"].ToString()));
                    obj.TotalMaintenance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_MAINTENANCE"].ToString()));
                    obj.TotalDepreciation = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DEPRECIATION"].ToString()));
                    obj.DepreciationMethod = drow["DEPRECIATION_METHOD"].ToString();
                    obj.DepreciableLife = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_LIFE"].ToString()));
                    obj.SalvageValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SALVAGE_VALUE"].ToString()));
                    obj.CurrentValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_VALUE"].ToString()));
                    obj.NextSchedMaint = drow["NEXT_SCHED_MAINT"].ToString();
                    obj.DepreciablePercentage = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPRECIABLE_PERCENTAGE"].ToString()));
                    obj.SoldAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SOLD_AMOUNT"].ToString()));
                    obj.LastDeprDate = drow["LAST_DEPR_DATE"].ToString();
                    obj.LastDeprAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LAST_DEPR_AMT"].ToString()));
                    obj.CalcDeprFrom = drow["CALC_DEPR_FROM"].ToString();
                    obj.CalcDeprTo = drow["CALC_DEPR_TO"].ToString();
                    obj.Status = drow["STATUS"].ToString();
                    obj.AssetCategory = drow["ASSET_CATEGORY"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Donar = drow["DONAR"].ToString();
                    obj.AssetSerialNo = drow["ASSET_SERIAL_NO"].ToString();
                    obj.SupplierDesc = drow["SUPPLIER_DESC"].ToString();
                    obj.DateAquiredBs = drow["DATE_AQUIRED_BS"].ToString();
                    obj.DateSoldBs = drow["DATE_SOLD_BS"].ToString();
                    obj.LastDeprDate_Bs = drow["LAST_DEPR_DATE_BS"].ToString();
                    obj.CalcDeprFrom_Bs = drow["CALC_DEPR_FROM_BS"].ToString();
                    obj.CalcDeprTo_Bs = drow["CALC_DEPR_TO_BS"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetAssetDetail(string AssetCode, string ReceiveSendDrop)
        {
            throw new NotImplementedException();
        }
    }
}
