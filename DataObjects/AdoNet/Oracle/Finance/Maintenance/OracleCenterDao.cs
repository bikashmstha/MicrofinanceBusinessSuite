using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCenterDao:ICenterDao
    {
        public object Get()
        {
            string sp = "fn_center_pkg.p_center_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.VdcnpCode = drow["VdcnpCode"].ToString();
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.CollectionDay = int.Parse(drow["CollectionDay"].ToString());
                    obj.InstallmentInterval = int.Parse(drow["InstallmentInterval"].ToString());
                    obj.ComputerUserId = drow["ComputerUserId"].ToString();
                    obj.CenterHouseBuiltDate = drow["CenterHouseBuiltDate"].ToString();
                    obj.FirstCollectionDate = drow["FirstCollectionDate"].ToString();
                    obj.MandatoryCollectionAmount = int.Parse(drow["MandatoryCollectionAmount"].ToString());
                    obj.CenterChief = drow["CenterChief"].ToString();
                    obj.ChiefDate = drow["ChiefDate"].ToString();
                    obj.CenterCollectionTime = drow["CenterCollectionTime"].ToString();
                    obj.ActiveFlags = drow["ActiveFlags"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.LastChangedDate = drow["LastChangedDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.AdjustAccountHead = drow["AdjustAccountHead"].ToString();
                    obj.DayDate = drow["DayDate"].ToString();
                    obj.CenterMeetingStartDate = drow["CenterMeetingStartDate"].ToString();
                    obj.UnitFundCollectionAmt = int.Parse(drow["UnitFundCollectionAmt"].ToString());
                    obj.CenterCategory = drow["CenterCategory"].ToString();
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.PenaltyOnLateCome = int.Parse(drow["PenaltyOnLateCome"].ToString());
                    obj.CenterClosedDate = drow["CenterClosedDate"].ToString();
                    obj.CenterAddress = drow["CenterAddress"].ToString();
                    obj.PhoneNo = drow["PhoneNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Center center)
        {
            string sp = "fn_center_pkg.p_center";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_center_name", center.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_vdcnp_code", center.VdcnpCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_employee_id", center.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_collection_day", center.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_installment_interval", center.InstallmentInterval, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_house_built_date", center.CenterHouseBuiltDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_first_collection_date", center.FirstCollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_mandatory_collection_amount", center.MandatoryCollectionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_chief", center.CenterChief, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_chief_date", center.ChiefDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_collection_time", center.CenterCollectionTime, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_active_flags", center.ActiveFlags, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", center.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_last_changed_date", center.LastChangedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_transfer_date", center.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_closed_date", center.CenterClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_address", center.CenterAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_day_date", center.DayDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_category", center.CenterCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_third_party_data", center.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_unit_fund_collection_amt", center.UnitFundCollectionAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_phone_no", center.PhoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", "", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", center.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_fiscal_year", center.FiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_center_code", center.CenterCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 200;

                //paramList.Add(SqlHelper.GetOraParam(":p_ComputerUserId", center.ComputerUserId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", center.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", center.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", center.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", center.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_AdjustAccountHead", center.AdjustAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterMeetingStartDate", center.CenterMeetingStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PenaltyOnLateCome", center.PenaltyOnLateCome, OracleDbType.Double, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(Center center)
        {
            string sp = "fn_center_pkg.p_center_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", center.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", center.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_name", center.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_built_date_from", center.BuildDateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_built_date_to", center.BuildDateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;



                //paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", center.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", center.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_VdcnpCode", center.VdcnpCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", center.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CollectionDay", center.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_InstallmentInterval", center.InstallmentInterval, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ComputerUserId", center.ComputerUserId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterHouseBuiltDate", center.CenterHouseBuiltDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FirstCollectionDate", center.FirstCollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MandatoryCollectionAmount", center.MandatoryCollectionAmount, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterChief", center.CenterChief, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ChiefDate", center.ChiefDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCollectionTime", center.CenterCollectionTime, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlags", center.ActiveFlags, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", center.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", center.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", center.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", center.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LastChangedDate", center.LastChangedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", center.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_AdjustAccountHead", center.AdjustAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_DayDate", center.DayDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterMeetingStartDate", center.CenterMeetingStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_UnitFundCollectionAmt", center.UnitFundCollectionAmt, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCategory", center.CenterCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", center.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PenaltyOnLateCome", center.PenaltyOnLateCome, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterClosedDate", center.CenterClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterAddress", center.CenterAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PhoneNo", center.PhoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    //obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.VdcnpCode = drow["VDCNP_CODE"].ToString();
                    obj.VdcDesc = drow["VDC_DESC"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmployeeName = drow["EMP_NAME"].ToString();
                    if (!string.IsNullOrEmpty(drow["COLLECTION_DAY"].ToString()))
                        obj.CollectionDay = int.Parse(drow["COLLECTION_DAY"].ToString());
                    obj.CollectionDesc = drow["COLLECTION_DAY_DESC"].ToString();
                    if (!string.IsNullOrEmpty(drow["INSTALLMENT_INTERVAL"].ToString()))
                        obj.InstallmentInterval = int.Parse(drow["INSTALLMENT_INTERVAL"].ToString());
                    //obj.ComputerUserId = drow["ComputerUserId"].ToString();
                    obj.CenterHouseBuiltDate = drow["CENTER_HOUSE_BUILT_DATE"].ToString();
                    obj.FirstCollectionDate = drow["FIRST_COLLECTION_DATE"].ToString();
                    if (!string.IsNullOrEmpty(drow["MANDATORY_COLLECTION_AMOUNT"].ToString()))
                        obj.MandatoryCollectionAmount = int.Parse(drow["MANDATORY_COLLECTION_AMOUNT"].ToString());
                    obj.CenterChief = drow["CENTER_CHIEF"].ToString();
                    obj.ChiefDate = drow["CHIEF_DATE"].ToString();
                    obj.CenterCollectionTime = drow["CENTER_COLLECTION_TIME"].ToString();
                    obj.ActiveFlags = drow["ACTIVE_FLAGS"].ToString();
                    //obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    //obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    //obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    //obj.LastChangedDate = drow["LastChangedDate"].ToString();
                    //obj.TransferDate = drow["TransferDate"].ToString();
                    obj.AdjustAccountHead = drow["ADJUST_AC_CODE"].ToString();
                    obj.AdjustAccountDesc = drow["ADJUST_AC_DESC"].ToString();

                    obj.DayDate = drow["DAY_DATE"].ToString();
                    obj.CenterMeetingStartDate = drow["CENTER_MEETING_START_DATE"].ToString();
                    if (!string.IsNullOrEmpty(drow["UNIT_FUND_COLLECTION_AMT"].ToString()))
                        obj.UnitFundCollectionAmt = int.Parse(drow["UNIT_FUND_COLLECTION_AMT"].ToString());
                    obj.CenterCategory = drow["CENTER_CATEGORY"].ToString();
                    //obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    //obj.PenaltyOnLateCome = int.Parse(drow["PenaltyOnLateCome"].ToString());
                    obj.CenterClosedDate = drow["CENTER_CLOSED_DATE"].ToString();
                    obj.CenterAddress = drow["CENTER_ADDRESS"].ToString();
                    obj.PhoneNo = drow["PHONE_NO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    
        public object GetCenterChief(string centerCode,string memberName)
        {
            string sp = "fn_center_pkg.p_center_chief_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanSectorCode", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanSectorDesc", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Sector> lst = new List<Sector>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Sector obj = new Sector();
                    obj.LoanSectorCode = drow["LoanSectorCode"].ToString();
                    obj.LoanSectorDesc = drow["LoanSectorDesc"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetCenterShort()
        {
            string sp = "fn_center_pkg.p_center_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object GetCenterListLov(string offCode, string centerName)
        {
            string sp = "fn_center_pkg.p_center_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_off_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_center_name", centerName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    /*FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     */
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    //obj.offCode = drow["INSTITUTE_CODE"].ToString();
                    obj.InstituteName = drow["INSTITUTE_NAME"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmployeeName = drow["EMP_NAME"].ToString();


                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object GetCenterList(string offCode, string centerName)
        {
            string sp = "fn_center_pkg.p_center_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_off_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_center_name", centerName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    /*FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     */
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    //obj.offCode = drow["INSTITUTE_CODE"].ToString();
                    //obj.InstituteName = drow["INSTITUTE_NAME"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmployeeName = drow["EMP_NAME"].ToString();


                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetTransferCenterList(string offCode, string centerName,string oldCenterCode)
        {
            string sp = "fn_center_pkg.p_transfer_center_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_off_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_center_name", centerName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_old_center_code", oldCenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Center> lst = new List<Center>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Center obj = new Center();
                    /*FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     */
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    
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
