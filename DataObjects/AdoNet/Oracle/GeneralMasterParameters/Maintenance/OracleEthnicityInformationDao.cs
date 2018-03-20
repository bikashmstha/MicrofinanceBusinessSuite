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
    public class OracleEthnicityInformationDao : IEthnicityInformationDao
    {
        private List<OracleParameter> PrepareParameterList(EthnicityInformation ethnicityInformation)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_ethnicity_code", ethnicityInformation.EthnicityCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_ethnicity_name", ethnicityInformation.EthnicityDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mast_ethnicity", ethnicityInformation.MastEthnicity, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", ethnicityInformation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[4].Size = 10;
            paramList[5].Size = 100;

            return paramList;

        }
        public List<EthnicityInformation> GetEthnicityInformations()
        {
            try
            {
                string SP = "MS_GENERAL_ENTRY_PKG.p_ethnicity_master_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<EthnicityInformation> lst = new List<EthnicityInformation>();


                EthnicityInformation obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new EthnicityInformation();
                    obj.EthnicityCode = drow["ETHNICITY_CODE"].ToString();//APPLICATION_ID
                    obj.EthnicityDesc = drow["ETHNICITY_NAME"].ToString();//APPLICATION_DESCRIPTION
                    obj.MastEthnicity = drow["MAST_ETHNICITY"].ToString();//APPLICATION_ETHNICITY
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
        public OutMessage SaveEthnicityInformation(EthnicityInformation ethnicityInformation)
        {
            string SP = "MS_GENERAL_ENTRY_PKG.P_IUD_ETHNICITY_INFO_DETAIL";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(ethnicityInformation);

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
    }
}
