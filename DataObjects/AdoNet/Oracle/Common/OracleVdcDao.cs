using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;
using BusinessObjects;
using DataObjects.Interfaces.Common;
using BusinessObjects.Common;

namespace DataObjects.AdoNet.Oracle.Common
{
    public class OracleVdcDao : IVdcDao
    {

        public List<Vdc> SearchVdc(Vdc vdc)
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();

                //string strQuery = "SELECT  VDCNP_CODE, VDCNP_DESC,DISTRICT_CODE,F_GET_DISTRICT_NAME(DISTRICT_CODE) AS DISTRICT_NAME " +
                //                "FROM MS_VDCNP " +
                //               "WHERE UPPER(VDCNP_DESC) LIKE NVL (:vdcDesc, '%') " +
                //               "AND DISTRICT_CODE LIKE NVL (:distCode, '%') " +
                //            "ORDER BY VDCNP_DESC ASC";
                string strQuery = "SELECT  VDCNP_CODE, VDCNP_DESC, DISTRICT_CODE,F_GET_DISTRICT_NAME(DISTRICT_CODE) AS DISTRICT_NAME  FROM MS_VDCNP WHERE 1=1 ";
                if (!string.IsNullOrEmpty(vdc.VDCNPDesc))
                {
                    strQuery = strQuery + "AND UPPER(VDCNP_DESC) LIKE '%" + vdc.VDCNPDesc.ToUpper() + "%'";

                }





                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<Vdc> vdcs = new List<Vdc>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Vdc v = new Vdc();
                    v.DistrictCode = dr["DISTRICT_CODE"].ToString();
                    v.VDCNPDesc = dr["VDCNP_DESC"].ToString();
                    v.VDCNPCode = dr["VDCNP_CODE"].ToString();
                    v.DistrictDesc = dr["DISTRICT_NAME"].ToString();
                    //offcTyp.CreatedBy = dr["CREATED_BY"].ToString();
                    //offcTyp.CreatedDate = dr["CREATED_ON"].ToString();



                    vdcs.Add(v);


                }
                return vdcs;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public object Get()
        {
            string sp = "MS_VDC_ENTRY_PKG.p_vdcnp_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Vdc> lst = new List<Vdc>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Vdc obj = new Vdc();
                    obj.VDCNPCode = drow["VdcnpCode"].ToString();
                    obj.VDCNPDesc = drow["VdcnpDesc"].ToString();
                    obj.DistrictCode = drow["DistrictCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Vdc Vdc)
        {
            string sp = "MS_VDC_ENTRY_PKG.p_vdcentry";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DistrictCode", Vdc.DistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":p_VdcnpCode", Vdc.VDCNPCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VdcnpDesc", Vdc.VDCNPDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", Vdc.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
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

        public object Search(Vdc Vdc)
        {
            string sp = "MS_VDC_ENTRY_PKG.p_vdcnp_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DistrictCode", Vdc.DistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VdcnpDesc", Vdc.VDCNPDesc, OracleDbType.Varchar2, ParameterDirection.Input));


                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Vdc> lst = new List<Vdc>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Vdc obj = new Vdc();
                    obj.VDCNPCode = drow["VDCNP_CODE"].ToString();
                    obj.VDCNPDesc = drow["VDCNP_DESC"].ToString();
                    obj.DistrictCode = drow["DISTRICT_CODE"].ToString();
                    obj.DistrictDesc = drow["DISTRICT_DESC"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object GetVDCShort(Vdc Vdc)
        {
            string sp = "MS_VDC_ENTRY_PKG.p_vdcnp_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DistrictCode", Vdc.DistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VdcnpDesc", Vdc.VDCNPDesc, OracleDbType.Varchar2, ParameterDirection.Input));


                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Vdc> lst = new List<Vdc>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Vdc obj = new Vdc();
                    obj.VDCNPCode = drow["VDCNP_CODE"].ToString();
                    obj.VDCNPDesc = drow["VDCNP_DESC"].ToString();
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }
    }
}
