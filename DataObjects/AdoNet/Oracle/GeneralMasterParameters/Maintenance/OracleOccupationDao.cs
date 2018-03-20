using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using BusinessObjects;
namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleOccupationDao : IOccupationDao
    {
        private List<OracleParameter> PrepareParameterList(Occupation occupation)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_occupation_code", occupation.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_occupation_desc", occupation.OccupationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", occupation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[3].Size = 10;
            paramList[4].Size = 100;

            return paramList;

        }
        public List<Occupation> GetOccupations()
        {
            try
            {
                string SP = "MS_GENERAL_ENTRY_PKG.p_occupation_detail_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Occupation> lst = new List<Occupation>();


                Occupation obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new Occupation();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();//APPLICATION_ID
                    obj.OccupationDesc = drow["OCCUPATION_DESC"].ToString();//APPLICATION_DESCRIPTION
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public OutMessage SaveOccupation(Occupation occupation)
        {
            string SP = "MS_GENERAL_ENTRY_PKG.P_IUD_OCCU_DETAIL";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(occupation);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[3].Value.ToString();
                oMsg.OutResultMessage = paramList[4].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object GetOccupationLov(string OccupationDesc)
        {
            string sp = "fn_member_clients_pkg.p_occupation_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OCCUPATION_DESC", OccupationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Occupation> lst = new List<Occupation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Occupation obj = new Occupation();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.OccupationDesc = drow["OCCUPATION_DESC"].ToString();

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
