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
    public class OracleEducationDao : IEducationDao
    {
        private List<OracleParameter> PrepareParameterList(Education education)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_education_code", education.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_education_desc", education.EducationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", education.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[3].Size = 10;
            paramList[4].Size = 100;

            return paramList;

        }
        public List<Education> GetEducations()
        {
            try
            {
                string SP = "MS_GENERAL_ENTRY_PKG.p_education_detail_list";
                OracleConnection conn = new GetConnection().GetDbConn();

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Education> lst = new List<Education>();


                Education obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new Education();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();//APPLICATION_ID
                    obj.EducationDesc = drow["EDUCATION_DESC"].ToString();//APPLICATION_DESCRIPTION
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

        public List<Education> GetEducationLov(string educationDesc)
        {
            try
            {
                string SP = "fn_member_clients_pkg.p_education_lov";
                OracleConnection conn = new GetConnection().GetDbConn();

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_education_desc", educationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Education> lst = new List<Education>();


                Education obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new Education();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();//APPLICATION_ID
                    obj.EducationDesc = drow["EDUCATION_DESC"].ToString();//APPLICATION_DESCRIPTION
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
        public OutMessage SaveEducation(Education education)
        {
            string SP = "MS_GENERAL_ENTRY_PKG.P_IUD_EDU_DETAIL";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(education);

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
    }
}
