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
    public class OracleOfficeMapDao: IOfficeMapDao
    {
        public object Get()
        {
            string sp = "MS_VDC_ENTRY_PKG.p_vdcnp_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                List<OfficeMap> lst = new List<OfficeMap>();
                for (int i = 1; i < 10; i++)
                {
                    OfficeMap obj = new OfficeMap();
                    obj.OfficeCode = i.ToString();
                    obj.OfficeName = i.ToString();
                    lst.Add(obj);
                }
                //conn = new GetConnection().GetDbConn();
                //List<OracleParameter> paramList = new List<OracleParameter>();

                //paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                //DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                //List<Vdc> lst = new List<Vdc>();
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    Vdc obj = new Vdc();
                //    obj.VDCNPCode = drow["VdcnpCode"].ToString();
                //    obj.VDCNPDesc = drow["VdcnpDesc"].ToString();
                //    obj.DistrictCode = drow["DistrictCode"].ToString();

                //    obj.Action = "U";
                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        //public Object Get()
        //{
        //    List<OfficeMap> lst = new List<OfficeMap>();
        //    for (int i = 1; i < 10; i++)
        //    {
        //        OfficeMap obj = new OfficeMap();
        //        obj.OfficeCode = i.ToString();
        //        obj.OfficeName = i.ToString();
        //        lst.Add(obj);
        //    }
        //    return lst;
        //    //string sp = "MS_INSTITUTE_PKG.P_INSTITUTE_MAP";
        //    //OracleConnection conn = new GetConnection().GetDbConn(); ;
        //    //try
        //    //{

        //    //    List<OracleParameter> paramList = new List<OracleParameter>();
        //    //    paramList.Add(SqlHelper.GetOraParam(":p_office_code", officeMap.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //    //    paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //    //    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
        //    //    List<OfficeMap> lst = new List<OfficeMap>();
        //    //    foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
        //    //    {
        //    //        OfficeMap obj = new OfficeMap();
        //    //        obj.CreatedBy = drow["CREATED_BY"].ToString();
        //    //        obj.CreatedOn = drow["CREATED_ON"].ToString();
        //    //        obj.OfficeCode = drow["INSTITUTE_CODE"].ToString();
        //    //        obj.OfficeGrpCode = drow["DEPT_CODE"].ToString();
        //    //        lst.Add(obj);
        //    //    }
        //    //    return lst;
        //    //}
        //    //catch (Exception ex) { throw ex; }
        //    //finally { conn.Close(); }
        //}
        public object Save(OfficeMap officeMap)
        {
            string sp = "MS_INSTITUTE_PKG.P_INSTITUTE_MAP";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_institute_code", officeMap.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_institute_grp_code", officeMap.OfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", "Demo", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", "01-APR-2015", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", officeMap.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        //public Object SaveOfficeMap(OfficeMap officeMap)
        //{
        //    string sp = "MS_INSTITUTE_PKG.P_INSTITUTE_MAP";
        //    OracleConnection conn;
        //    OracleTransaction tran;
        //    conn = new GetConnection().GetDbConn();
        //    tran = conn.BeginTransaction();
        //    try
        //    {

        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        paramList.Add(SqlHelper.GetOraParam(":p_institute_code", officeMap.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_institute_grp_code", officeMap.OfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", "Demo", OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", "01-APR-2015", OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_insert_update", officeMap.Action, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //        paramList[paramList.Count - 1].Size = 4000;
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection. Output));
        //        paramList[paramList.Count - 1].Size = 4000;



        //        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
        //        tran.Commit();
        //        return new object();
        //    }
        //    catch (Exception ex) { tran.Rollback(); throw ex; }
        //    finally { conn.Close(); }
        //}
        public object Search(OfficeMap officeMap)
        {
            string sp = "MS_INSTITUTE_PKG.p_office_map_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_institute_grp_code", officeMap.OfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());

                List<OfficeMap> lst = new List<OfficeMap>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    OfficeMap obj = new OfficeMap();
                    obj.OfficeCode = dr["institute_code"].ToString();
                    obj.OfficeGrpCode = dr["institute_grp_code"].ToString();
                    obj.OfficeName = dr["institute_name"].ToString();
                    //  officeMapObj.OfficeTypeName = dr["INS_TYPE_DESC"].ToString();
                    //offc.DistrictCode = dr["DISTRICT_CODE"].ToString();
                    //offc.DistrictName = dr["DISTRICT_DESC"].ToString();
                    //offc.VdcName = dr["VDC_DESC"].ToString();
                    //offc.VdcCode = dr["VDC_CODE"].ToString();
                    //offc.MigrationInProcess = dr["MIGRATION_IN_PROCESS"].ToString();
                    //offc.BudgetAlloCationYN = dr["BUDGET_CONTROL_Y_N"].ToString();
                    //offc.AutoAdjustmentCollSht = dr["AUTO_ADJUSTMENT_COLLSHT"].ToString();
                    //offc.AutoAcOnNonMem = dr["AUTO_AC_ON_NON_MEM"].ToString();
                    //offc.EstablishedDate = dr["ESTABLISHED_DATE"].ToString();
                    //offc.TransactionDate = dr["TRANSACTION_DATE"].ToString();
                    //offc.OfficeStatus = dr["INSTITUTE_STATUS"].ToString();
                    //offc.AbbsAllowYN = dr["ABBS_ALLOW_Y_N"].ToString();
                    //offc.InterbranchAccountHead = dr["INTERBRANCH_ACCOUNT_HEAD"].ToString();
                    //offc.InterbranchAccountHeadName = dr["INTERBRANCH_ACCOUNT_DESC"].ToString();
                    //offc.Address = dr["ADDRESS"].ToString();
                    //offc.Email = dr["EMAIL"].ToString();
                    //offc.PhoneNumber = dr["PHONE_NO"].ToString();
                    //offc.FaxNumber = dr["FAX_NO"].ToString();
                    //offc.ContactPerson = dr["CONTACT_PERSON"].ToString();
                    //offc.ParentOfficeCode = dr["PARENT_INSTITUTE_CODE"].ToString();
                    //offc.ParentOfficeName = dr["PARENT_OFFICE_NAME"].ToString();
                    //offc.RowID = dr["ROW_ID"].ToString();
                    //offc.ContactPerson = dr["EMAIL"].ToString();


                    lst.Add(obj);


                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        //public Object Search(OfficeMap officeMap)
        //{
        //    try
        //    {
        //        OracleConnection conn = new GetConnection().GetDbConn();
        //        string SP = "MS_INSTITUTE_PKG.p_office_map_list";
        //        List<OracleParameter> paramList = new List<OracleParameter>();

        //        paramList.Add(SqlHelper.GetOraParam(":p_office_name", officeMap.OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList[paramList.Count - 1].Size = 4000;

        //        paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


        //        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

        //        List<OfficeMap> officeMaps = new List<OfficeMap>();

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            OfficeMap officeMapObj = new OfficeMap();
        //            //officeMapObj.OfficeCode = dr["INSTITUTE_CODE"].ToString();
        //            //officeMapObj.OfficeGrpCode = dr["DEPT_CODE"].ToString();
        //          //  officeMapObj.OfficeTypeName = dr["INS_TYPE_DESC"].ToString();
        //            //offc.DistrictCode = dr["DISTRICT_CODE"].ToString();
        //            //offc.DistrictName = dr["DISTRICT_DESC"].ToString();
        //            //offc.VdcName = dr["VDC_DESC"].ToString();
        //            //offc.VdcCode = dr["VDC_CODE"].ToString();
        //            //offc.MigrationInProcess = dr["MIGRATION_IN_PROCESS"].ToString();
        //            //offc.BudgetAlloCationYN = dr["BUDGET_CONTROL_Y_N"].ToString();
        //            //offc.AutoAdjustmentCollSht = dr["AUTO_ADJUSTMENT_COLLSHT"].ToString();
        //            //offc.AutoAcOnNonMem = dr["AUTO_AC_ON_NON_MEM"].ToString();
        //            //offc.EstablishedDate = dr["ESTABLISHED_DATE"].ToString();
        //            //offc.TransactionDate = dr["TRANSACTION_DATE"].ToString();
        //            //offc.OfficeStatus = dr["INSTITUTE_STATUS"].ToString();
        //            //offc.AbbsAllowYN = dr["ABBS_ALLOW_Y_N"].ToString();
        //            //offc.InterbranchAccountHead = dr["INTERBRANCH_ACCOUNT_HEAD"].ToString();
        //            //offc.InterbranchAccountHeadName = dr["INTERBRANCH_ACCOUNT_DESC"].ToString();
        //            //offc.Address = dr["ADDRESS"].ToString();
        //            //offc.Email = dr["EMAIL"].ToString();
        //            //offc.PhoneNumber = dr["PHONE_NO"].ToString();
        //            //offc.FaxNumber = dr["FAX_NO"].ToString();
        //            //offc.ContactPerson = dr["CONTACT_PERSON"].ToString();
        //            //offc.ParentOfficeCode = dr["PARENT_INSTITUTE_CODE"].ToString();
        //            //offc.ParentOfficeName = dr["PARENT_OFFICE_NAME"].ToString();
        //            //offc.RowID = dr["ROW_ID"].ToString();
        //            //offc.ContactPerson = dr["EMAIL"].ToString();


        //            officeMaps.Add(officeMapObj);


        //        }
        //        return officeMaps;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //public object DeleteOfficeMap(OfficeMap officeMap)
        //{

        //    try
        //    {
        //        OracleConnection conn = new GetConnection().GetDbConn();
        //        string SP = "officeMap_pkg.p_get";
        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        //osp.ParamHT["P_INSTITUTE_CODE"] = INSTITUTE_CODE;
        //        //osp.ParamHT["P_INSTITUTE_GRP_CODE"] = INSTITUTE_GRP_CODE;
        //        //osp.ParamHT["P_CREATED_BY"] = DBNull.Value;
        //        //osp.ParamHT["P_CREATED_ON"] = DBNull.Value;
        //        //osp.ParamHT["P_INSERT_UPDATE"] = "D";

        //        //osp.ParamHT["#V_OUT_RESULT_CODE"] = strOutResultCode;
        //        //osp.ParamHT["#V_OUT_RESULT_MSG"] = strOutResultMsg;
        //        paramList.Add(SqlHelper.GetOraParam(":p_institute_code", officeMap.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_institute_grp_code", officeMap.OfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", "Demo", OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", "01-APR-2015", OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_insert_update", "D", OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //        paramList[paramList.Count - 1].Size = 4000;
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //        paramList[paramList.Count - 1].Size = 4000;



        //        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());


        //        return null;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}


    }
}
