using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.HumanResource;
using DataObjects.Interfaces.HumanResource;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.HumanResource
{
    public class OracleDesignationDao : IDesignationDao
    {
        public object Get()
        {
            string sp = "hr_post_pkg.p_designation_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Designation> lst = new List<Designation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Designation obj = new Designation();
                    obj.DesignationCode = drow["DesignationCode"].ToString();
                    obj.DesignationDesc = drow["DesignationDesc"].ToString();
                    obj.MgrDesignationCode = drow["MgrDesignationCode"].ToString();
                    obj.PostCode = drow["PostCode"].ToString();
                    obj.SortOrder = int.Parse(drow["SortOrder"].ToString());
                    obj.PerTrainee = drow["PerTrainee"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Designation designation)
        {
            string sp = "hr_post_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DesignationCode", designation.DesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DesignationDesc", designation.DesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MgrDesignationCode", designation.MgrDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostCode", designation.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SortOrder", designation.SortOrder, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PerTrainee", designation.PerTrainee, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", designation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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
        public object Search(Designation designation)
        {
            string sp = "hr_post_pkg.p_designation_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                //paramList.Add(SqlHelper.GetOraParam(":p_DesignationCode", designation.DesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_DesignationDesc", designation.DesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MgrDesignationCode", designation.MgrDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostCode", designation.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_SortOrder", designation.SortOrder, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PerTrainee", designation.PerTrainee, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Designation> lst = new List<Designation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Designation obj = new Designation();
                    obj.DesignationCode = drow["Designation_Code"].ToString();
                    obj.DesignationDesc = drow["Designation_Desc"].ToString();
                    //obj.MgrDesignationCode = drow["MgrDesignationCode"].ToString();
                    //obj.PostCode = drow["PostCode"].ToString();
                    //obj.SortOrder = int.Parse(drow["SortOrder"].ToString());
                    //obj.PerTrainee = drow["PerTrainee"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        //public object Search(Designation designation)
        //{
        //    string sp = "hr_post_pkg.p_designation_lov_list";
        //    OracleConnection conn = new OracleConnection();
        //    OutMessage oMsg = new OutMessage();
        //    try
        //    {
        //        conn = new GetConnection().GetDbConn();
        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        paramList.Add(SqlHelper.GetOraParam(":p_DesignationCode", designation.DesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_DesignationDesc", designation.DesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_MgrDesignationCode", designation.MgrDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PostCode", designation.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_SortOrder", designation.SortOrder, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PerTrainee", designation.PerTrainee, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
        //        List<Designation> lst = new List<Designation>();
        //        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
        //        {
        //            Designation obj = new Designation();
        //            obj.DesignationCode = drow["DesignationCode"].ToString();
        //            obj.DesignationDesc = drow["DesignationDesc"].ToString();
        //            obj.MgrDesignationCode = drow["MgrDesignationCode"].ToString();
        //            obj.PostCode = drow["PostCode"].ToString();
        //            obj.SortOrder = int.Parse(drow["SortOrder"].ToString());
        //            obj.PerTrainee = drow["PerTrainee"].ToString();

        //            lst.Add(obj);
        //        }
        //        oMsg.Result = lst;
        //        return oMsg;
        //    }
        //    catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
        //    finally { conn.Close(); }
        //}
        public object GetDesignationShort()
        {
            string sp = "hr_post_pkg.p_designation_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Designation> lst = new List<Designation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Designation obj = new Designation();
                    obj.DesignationCode = drow["DesignationCode"].ToString();
                    obj.DesignationDesc = drow["DesignationDesc"].ToString();
                    
                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpDesignation(string DesignationDesc)
        {
            string sp = "hr_employee_utility_pkg.p_emp_designation_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_DESIGNATION_DESC", DesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Designation> lst = new List<Designation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Designation obj = new Designation();
                    obj.DesignationCode = drow["DESIGNATION_CODE"].ToString();
                    obj.DesignationDesc = drow["DESIGNATION_DESC"].ToString();

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
