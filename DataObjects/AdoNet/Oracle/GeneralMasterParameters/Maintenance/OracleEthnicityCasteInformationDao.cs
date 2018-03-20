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
    public class OracleEthnicityCasteInformationDao : IEthnicityCasteInformationDao
    {
        private List<OracleParameter> PrepareParameterList(EthnicityCasteInformation ethnicityCasteInformation)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_ethnicity_code", ethnicityCasteInformation.EthnicityCasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_caste_code", ethnicityCasteInformation.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_caste_desc", ethnicityCasteInformation.EthnicityCasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));            
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", ethnicityCasteInformation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[3].Size = 10;
            paramList[4].Size = 100;

            return paramList;

        }
        public List<EthnicityCasteInformation> GetEthnicityCasteInformations(string ethnicityCasteCode)
        {
            try
            {
                string SP = "MS_GENERAL_ENTRY_PKG.p_ethnicity_caste_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_ethnicity_code", ethnicityCasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<EthnicityCasteInformation> lst = new List<EthnicityCasteInformation>();


                EthnicityCasteInformation obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new EthnicityCasteInformation();
                    obj.EthnicityCasteCode = drow["ETHNICITY_CODE"].ToString();//APPLICATION_ID
                    obj.CasteCode = drow["CASTE_CODE"].ToString();//APPLICATION_ID
                    obj.EthnicityCasteDesc = drow["CASTE_DESC"].ToString();//APPLICATION_DESCRIPTION
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
        public OutMessage SaveEthnicityCasteInformation(EthnicityCasteInformation ethnicityCasteInformation)
        {
            string SP = "MS_GENERAL_ENTRY_PKG.P_IUD_ETHNICITY_CASTE_INFO";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(ethnicityCasteInformation);

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
