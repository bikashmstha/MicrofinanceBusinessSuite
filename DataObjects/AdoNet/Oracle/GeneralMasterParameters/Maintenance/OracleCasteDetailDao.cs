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
    public class OracleCasteDetailDao : ICasteDetailDao
    {
        public object GetCasteShort(string caste)
        {
            string sp = "fn_member_clients_pkg.p_caste_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_caste_desc", caste, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CasteDetail> lst = new List<CasteDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CasteDetail obj = new CasteDetail();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();//APPLICATION_ID
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();//APPLICATION_DESCRIPTION
                    // obj.CIBCode = drow["CIB_CODE"].ToString();//APPLICATION_CODE
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        
        private List<OracleParameter> PrepareParameterList(CasteDetail castDetail)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_caste_code", castDetail.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_caste_desc", castDetail.CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cib_code", castDetail.CIBCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", castDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[4].Size = 10;
            paramList[5].Size = 100;

            return paramList;

        }
        public List<CasteDetail> GetCasteDetails()
        {
            try
            {
                string SP = "MS_GENERAL_ENTRY_PKG.p_caste_detail_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<CasteDetail> lst = new List<CasteDetail>();


                CasteDetail obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new CasteDetail();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();//APPLICATION_ID
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();//APPLICATION_DESCRIPTION
                    obj.CIBCode =  drow["CIB_CODE"].ToString();//APPLICATION_CODE
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
        public OutMessage SaveCasteDetail(CasteDetail casteDetail)
        {
            string SP = "MS_GENERAL_ENTRY_PKG.P_IUD_CASTE_DETAIL";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(casteDetail);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[4].Value.ToString();
                oMsg.OutResultMessage = paramList[5].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object GetCastes(string CasteDesc)
        {
            string sp = "fn_member_clients_pkg.p_caste_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_CASTE_DESC", CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CasteDetail> lst = new List<CasteDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CasteDetail obj = new CasteDetail();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();

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
