using BusinessObjects.GeneralMasterParameters;
using DataObjects.Interfaces.GeneralMasterParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;
using BusinessObjects;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleOfficeDao: IOfficeDao
    {

        public object Get()
        {
            string sp = "ms_institute_pkg.p_office_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Office> lst = new List<Office>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Office obj = new Office();
                    //obj.VDCNPCode = drow["VdcnpCode"].ToString();
                    //obj.VDCNPDesc = drow["VdcnpDesc"].ToString();
                    //obj.DistrictCode = drow["DistrictCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        
        public object Search(Office office)
        {
            string sp = "ms_institute_pkg.p_office_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", office.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_office_name", office.OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());

                List<Office> lst = new List<Office>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Office obj = new Office();
                    obj.OfficeName = dr["INSTITUTE_NAME"].ToString();
                    obj.OfficeCode = dr["INSTITUTE_CODE"].ToString();
                    obj.OfficeTypeCode = dr["INSTITUTE_TYPE_CODE"].ToString();
                    obj.OfficeTypeName = dr["INS_TYPE_DESC"].ToString();
                    obj.DistrictCode = dr["DISTRICT_CODE"].ToString();
                    obj.DistrictName = dr["DISTRICT_DESC"].ToString();
                    obj.VdcName = dr["VDC_DESC"].ToString();
                    obj.VdcCode = dr["VDC_CODE"].ToString();
                    obj.MigrationInProcess = dr["MIGRATION_IN_PROCESS"].ToString();
                    obj.BudgetAlloCationYN = dr["BUDGET_CONTROL_Y_N"].ToString();
                    obj.AutoAdjustmentCollSht = dr["AUTO_ADJUSTMENT_COLLSHT"].ToString();
                    obj.AutoAcOnNonMem = dr["AUTO_AC_ON_NON_MEM"].ToString();
                    obj.EstablishedDate = dr["ESTABLISHED_DATE"].ToString();
                    obj.TransactionDate = dr["TRANSACTION_DATE"].ToString();
                    obj.OfficeStatus = dr["INSTITUTE_STATUS"].ToString();
                    obj.AbbsAllowYN = dr["ABBS_ALLOW_Y_N"].ToString();
                    obj.InterbranchAccountHead = dr["INTERBRANCH_ACCOUNT_HEAD"].ToString();
                    obj.InterbranchAccountHeadName = dr["INTERBRANCH_ACCOUNT_DESC"].ToString();
                    obj.Address = dr["ADDRESS"].ToString();
                    obj.Email = dr["EMAIL"].ToString();
                    obj.PhoneNumber = dr["PHONE_NO"].ToString();
                    obj.FaxNumber = dr["FAX_NO"].ToString();
                    obj.ContactPerson = dr["CONTACT_PERSON"].ToString();
                    obj.ParentOfficeCode = dr["PARENT_INSTITUTE_CODE"].ToString();
                    obj.ParentOfficeName = dr["PARENT_OFFICE_NAME"].ToString();
                    obj.RowID = dr["ROW_ID"].ToString();
                    obj.ContactPerson = dr["EMAIL"].ToString();


                    lst.Add(obj);



                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        


        public object Save(Office office)
        {
            string sp = "ms_institute_pkg.p_institute";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_institute_name", office.OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_institute_type_code", office.OfficeTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_parent_institute_code", office.ParentOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_district_code", office.DistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_contact_person", office.ContactPerson, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_phone_no", office.PhoneNumber, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_fax_no", office.FaxNumber, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_email", office.Email, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address", office.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_area_grading", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_office_acc_code_prefix", office.OfficeAccCodePrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_established_date", office.EstablishedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_vdc_code", office.VdcCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_institute_status", office.OfficeStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_institute_inactive_date", office.OfficeInactiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_created_by", "Demo", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_created_on", "20-APR-2015", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_range", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_first_loan_disburse_date", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_display_seq", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_current_fiscal_year", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_last_fiscal_year", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_max_period_additional_loan", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_compulsory_collection_amt", DBNull.Value, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_max_no_of_loan", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_control_from_cdms", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_budget_control_y_n", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_location_code", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_approval_range_control", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_current_year", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_branch_on_m_w", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_interbranch_account_head", office.InterbranchAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_abbs_withdraw_limit", office.AbbsWithdrawLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_abbs_deposit_limit", office.AbbsDepositLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_abbs_allow_y_n", office.AbbsAllowYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_migration_in_process", office.MigrationInProcess, OracleDbType.Varchar2, ParameterDirection.Input));
                // paramList.Add(SqlHelper.GetOraParam(":p_budget_allocation_y_n", office.BudgetAlloCationYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_transaction_date", office.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_auto_adjustment_collsht", office.AutoAdjustmentCollSht, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_auto_ac_on_non_mem", office.AutoAcOnNonMem, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", office.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_row_id", office.RowID, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_institute_code", office.OfficeCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray()); tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        


   
    
        public List<Office> GetOfficeShort()
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                string SP = "ms_institute_pkg.p_office_list";
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_office_code", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_office_name", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                List<Office> offices = new List<Office>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Office offc = new Office();
                    offc.OfficeName = dr["INSTITUTE_NAME"].ToString();
                    offc.OfficeCode = dr["INSTITUTE_CODE"].ToString();
                    
                    offices.Add(offc);


                }
                return offices;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public object GetOfficeList(string userCode,string officeName)
        {
            string sp = "ms_institute_pkg.p_office_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_user_code", userCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_office_name", officeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Office> lst = new List<Office>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Office obj = new Office();
                    obj.OfficeCode = drow["INSTITUTE_CODE"].ToString();
                    obj.OfficeName = drow["INSTITUTE_NAME"].ToString();
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
