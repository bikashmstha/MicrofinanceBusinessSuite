using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleMsReferenceCodeDetailsDao:IMsReferenceCodeDetailsDao
    {
        public object GetReferenceDetailListShort(string referenceCode)
        {
            string sp = "ms_ref_code_pkg.p_reference_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_referenceCode", referenceCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MsReferenceCodeDetails> lst = new List<MsReferenceCodeDetails>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MsReferenceCodeDetails obj = new MsReferenceCodeDetails();
                    obj.RefDtlCode = drow["REF_DTL_CODE"].ToString();
                    obj.RefDtlName = drow["REF_DTL_NAME"].ToString();
                    //obj.CreatedBy = drow["CREATED_BY"].ToString();
                    //obj.CreatedOn = drow["CREATED_ON"].ToString();
                    //obj.Action = "U";

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
