
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataObjects.Interfaces.Finance;
using BusinessObjects;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
   public class OracleGroupDao:IGroupDao
    {

        public List<Group> GetGroups(int? groupID)
        {
            return null;
        }

        public string SaveGroup(Group group)
        {
           
            bool flag = true;
            GetConnection gc = new GetConnection();
            OracleConnection objConn;
            try
            {
                string SP = "FN_GROUP_PKG.P_GROUP";
                objConn = gc.GetDbConn();    

                List<OracleParameter> paramList = new List<OracleParameter>();
               


                paramList.Add(SqlHelper.GetOraParam(":p_group_name", group.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                //  paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", group.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_group_formed_date", group.GroupFormedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_group_formed_by", group.GroupFormedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //    paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", group.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_grt_perform_date", group.GrtPerformDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //  paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_grt_perform_val", group.GrtPerformVal, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_grt_perform_by", group.GrtPerformBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //    paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_third_party_data", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_group_closed_date", group.GroupClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_active_flags", group.ActiveFlags, OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_user","", OracleDbType.Varchar2, ParameterDirection.Input));
                //   paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_grp_leader_indicator", group.GrpLeaderIndicator, OracleDbType.Varchar2, ParameterDirection.Input));
                //    paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", group.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                //     paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_fiscal_year", group.FiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_group_code", group.GroupCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code",null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg",null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 4000;

                SqlHelper.ExecuteNonQuery(objConn, CommandType.StoredProcedure, SP, paramList.ToArray());




               // tran.Commit();

                return "Success";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Object SearchGroup(Group group)
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                

                string strQuery = "SELECT  * FROM fn_group WHERE 1=1 ";
                //if (!string.IsNullOrEmpty(group.GroupCode))
                //{
                //    strQuery = strQuery + "AND GROUP_CODE=" + group.GroupCode;

                //}
               



                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<Group> grplist = new List<Group>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    Group grp = new Group();
                    grp.GroupCode = dr["GROUP_CODE"].ToString();
                    grp.GroupName = dr["GROUP_NAME"].ToString();

                    grplist.Add(grp);
                    


                }
                return grplist;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public object GetGroupTransfer(string centerCode, string groupCode)
        {
            string sp = "fn_group_pkg.p_group_transfer_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_group_code", groupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Group> lst = new List<Group>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Group obj = new Group();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetGroupForCenterTransfer(string centerCode, string groupName)
        {
            string sp = "fn_group_pkg.p_center_grp_transfer_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_group_name", groupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Group> lst = new List<Group>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Group obj = new Group();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();


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
