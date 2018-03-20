using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleGenerateSavingCollectionDao:IGenerateSavingCollectionDao
    {

        public object GenerateSavingCollection(string offCode, string sheetNo, string centerCode, string collectionDate)
        {
            string sp = "saving_collection_sheet_pkg.p_generate_saving_collection";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":vsheetno", sheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":vcentercode", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":vcollectiondate", collectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GenerateSavingCollection> lst = new List<GenerateSavingCollection>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GenerateSavingCollection obj = new GenerateSavingCollection();
                    obj.CollectionSheet_No = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.SamagikSewa_Fund_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SAMAGIK_SEWA_FUND_DUE"].ToString()));
                    obj.GroupFund_Bal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GROUP_FUND_BAL"].ToString()));
                    obj.GroupFund_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GROUP_FUND_DUE"].ToString()));
                    obj.GroupfundAdjust_Y_N = drow["GROUPFUND_ADJUST_Y_N"].ToString();
                    obj.AdjustGroup_Fund_Ac = drow["ADJUST_GROUP_FUND_AC"].ToString();
                    obj.SamagikSewa_Fund_Received = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SAMAGIK_SEWA_FUND_RECEIVED"].ToString()));
                    obj.GroupFund_Received = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GROUP_FUND_RECEIVED"].ToString()));
                    obj.PensionReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENSION_RECEIVED"].ToString()));
                    obj.SamagikSewa_Fund_Ac = drow["SAMAGIK_SEWA_FUND_AC"].ToString();
                    obj.GroupFund_Ac = drow["GROUP_FUND_AC"].ToString();
                    obj.PensionAc = drow["PENSION_AC"].ToString();
                    obj.IndividualAc = drow["INDIVIDUAL_AC"].ToString();
                    obj.GroupfundAdjust_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GROUPFUND_ADJUST_AMOUNT"].ToString()));
                    obj.PensionBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENSION_BAL"].ToString()));
                    obj.PensionDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENSION_DUE"].ToString()));
                    obj.PensionAdjust_Y_N = drow["PENSION_ADJUST_Y_N"].ToString();
                    obj.AdjustPension_Ac = drow["ADJUST_PENSION_AC"].ToString();
                    obj.PensionAdjust_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENSION_ADJUST_AMOUNT"].ToString()));
                    obj.BusinessAc = drow["BUSINESS_AC"].ToString();
                    obj.BusinessBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BUSINESS_BAL"].ToString()));
                    obj.BusinessDepo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BUSINESS_DEPO"].ToString()));
                    obj.BusinessReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BUSINESS_RECEIVED"].ToString()));
                    obj.BusinessWithdraw = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BUSINESS_WITHDRAW"].ToString()));
                    obj.SunauloAc = drow["SUNAULO_AC"].ToString();
                    obj.SunauloBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUNAULO_BAL"].ToString()));
                    obj.SunauloDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUNAULO_DUE"].ToString()));
                    obj.SunauloReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUNAULO_RECEIVED"].ToString()));
                    obj.SunauloAdjust_Y_N = drow["SUNAULO_ADJUST_Y_N"].ToString();
                    obj.AdjustSunaulo_Ac = drow["ADJUST_SUNAULO_AC"].ToString();
                    obj.SunauloAdjust_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUNAULO_ADJUST_AMOUNT"].ToString()));
                    obj.IndividualBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INDIVIDUAL_BAL"].ToString()));
                    obj.IndividualReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INDIVIDUAL_RECEIVED"].ToString()));
                    obj.IndividualWithdraw = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INDIVIDUAL_WITHDRAW"].ToString()));
                    obj.ReceivedY_N = drow["RECEIVED_Y_N"].ToString();
                    obj.PresentY_N = drow["PRESENT_Y_N"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
               oMsg.OutResultCode = "SUCCESS";
               oMsg.OutResultMessage = "Saving Collection Generated Successfully";

                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
