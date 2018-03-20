using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleMsReferenceCodeMasterDao : IMsReferenceCodeMasterDao
    {

        private List<OracleParameter> PrepareParameterList(MSReferenceCodeMaster msControlValues)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_ref_mst_code", msControlValues.RefMstCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_ref_mst_name", msControlValues.RefMstName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", msControlValues.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_user", msControlValues.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_date", msControlValues.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", msControlValues.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;


            return paramList;

        }
        public List<MSReferenceCodeMaster> GetMSReferenceCodeMaster()
        {
            try
            {
                string SP = "MS_REF_CODE_PKG.p_ref_code_table_mst_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<MSReferenceCodeMaster> lst = new List<MSReferenceCodeMaster>();


                MSReferenceCodeMaster obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new MSReferenceCodeMaster();
                    obj.RefMstCode = drow["REF_MST_CODE"].ToString();
                    obj.RefMstName = drow["REF_MST_NAME"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
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

        public OutMessage SaveMSReferenceCodeMaster(MSReferenceCodeMaster msControlValues)
        {

            string SP = "MS_REF_CODE_PKG.p_reference_code_table_mst";
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(msControlValues);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[6].Value.ToString();
                oMsg.OutResultMessage = paramList[7].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        
    }
}
