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
    public class OracleMsControlValuesDao : IMsControlValuesDao
    {

        private List<OracleParameter> PrepareParameterList(MsControlValues msControlValues)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_row_id", msControlValues.RowId, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_name_en", msControlValues.NameEn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_control_value", msControlValues.ControlValue, OracleDbType.Varchar2, ParameterDirection.Input));           
            paramList.Add(SqlHelper.GetOraParam(":p_active", msControlValues.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", msControlValues.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_app_title", msControlValues.AppTitle, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_remarks", msControlValues.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_user", msControlValues.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_date", msControlValues.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", msControlValues.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count-1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;


            return paramList;

        }
        
        public List<MsControlValues> GetMsControlValues()
        {
            try
            {
                
                string SP = "MS_CONTROL_VALUES_PKG.p_get_control_values";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_name_en", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
           
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<MsControlValues> lst = new List<MsControlValues>();


                MsControlValues obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new MsControlValues();
                    obj.NameEn = drow["NAME_EN"].ToString();
                    obj.ControlValue= drow["CONTROL_VALUE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
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

        public OutMessage SaveMsControlValues(MsControlValues msControlValues)
        {

            string SP = "MS_CONTROL_VALUES_PKG.P_CONTROL_VALUES"; 
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(msControlValues);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[10].Value.ToString();
                oMsg.OutResultMessage = paramList[11].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
