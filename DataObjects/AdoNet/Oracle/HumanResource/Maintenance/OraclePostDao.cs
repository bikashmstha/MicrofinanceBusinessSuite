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
    public class OraclePostDao : IPostDao
    {
        public object Get()
        {
            string sp = "hr_post_pkg.p_post_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Post> lst = new List<Post>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Post obj = new Post();
                    obj.PostCode = drow["Post_Code"].ToString();
                    obj.PostDesc = drow["Post_Desc"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        //public object Get()
        //{
        //    string sp = "hr_post_pkg.p_post_lov_list";
        //    OracleConnection conn = new OracleConnection();
        //    OutMessage oMsg = new OutMessage();
        //    try
        //    {
        //        conn = new GetConnection().GetDbConn();
        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
        //        List<Post> lst = new List<Post>();
        //        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
        //        {
        //            Post obj = new Post();
        //            obj.PostCode = drow["PostCode"].ToString();
        //            obj.PostDesc = drow["PostDesc"].ToString();
        //            obj.PostLevel = int.Parse(drow["PostLevel"].ToString());
        //            obj.MgrPostCode = drow["MgrPostCode"].ToString();
        //            obj.MaxGrade = int.Parse(drow["MaxGrade"].ToString());
        //            obj.MinQualification = drow["MinQualification"].ToString();


        //            obj.PostLevelCode = int.Parse(drow["PostLevelCode"].ToString());

        //            obj.Action = "U";
        //            lst.Add(obj);
        //        }
        //        oMsg.Result = lst;
        //        return oMsg;
        //    }
        //    catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
        //    finally { conn.Close(); }
        //}

        public object Save(Post post)
        {
            string sp = "hr_post_pkg.p_post_setup";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PostCode", post.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostDesc", post.PostDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostLevel", post.PostLevel, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MgrPostCode", post.MgrPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxGrade", post.MaxGrade, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinQualification", post.MinQualification, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", post.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", post.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostLevelCode", post.PostLevelCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", post.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(Post post)
        {
            string sp = "hr_post_pkg.p_post_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PostCode", post.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostDesc", post.PostDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostLevel", post.PostLevel, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MgrPostCode", post.MgrPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxGrade", post.MaxGrade, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinQualification", post.MinQualification, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", post.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", post.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostLevelCode", post.PostLevelCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Post> lst = new List<Post>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Post obj = new Post();
                    obj.PostCode = drow["PostCode"].ToString();
                    obj.PostDesc = drow["PostDesc"].ToString();
                    obj.PostLevel = int.Parse(drow["PostLevel"].ToString());
                    obj.MgrPostCode = drow["MgrPostCode"].ToString();
                    obj.MaxGrade = int.Parse(drow["MaxGrade"].ToString());
                    obj.MinQualification = drow["MinQualification"].ToString();


                    obj.PostLevelCode = int.Parse(drow["PostLevelCode"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPostShort()
        {
            string sp = "hr_post_pkg.p_post_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Post> lst = new List<Post>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Post obj = new Post();
                    obj.PostCode = drow["PostCode"].ToString();
                    obj.PostDesc = drow["PostDesc"].ToString();
                    
                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpPost(string PostDesc)
        {
            string sp = "hr_employee_utility_pkg.p_emp_post_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_POST_DESC", PostDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Post> lst = new List<Post>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Post obj = new Post();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.PostDesc = drow["POST_DESC"].ToString();

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
