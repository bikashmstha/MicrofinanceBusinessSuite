using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;
using DataObjects.Interfaces.Common;
using BusinessObjects.Common;
using BusinessObjects;

namespace DataObjects.AdoNet.Oracle.Common
{
    public class OracleDistrictDao : IDistrictDao
    {




        public List<District> SearchDistrict(District district)
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                string strQuery = "SELECT DISTRICT_CODE, DISTRICT_DESC, ZONE_CODE  FROM MS_DISTRICT WHERE 1=1 ";
                if (!string.IsNullOrEmpty(district.DistrictDesc))
                {
                    strQuery = strQuery + "AND UPPER(DISTRICT_DESC) LIKE '%" + district.DistrictDesc.ToUpper() + "%'";

                }
                if (!string.IsNullOrEmpty(district.DistrictCode))
                {
                    strQuery = strQuery + " AND UPPER(DISTRICT_DESC) LIKE '%" + district.DistrictDesc.ToUpper() + "%'";

                }

                //string strQuery = "SELECT DISTRICT_CODE, DISTRICT_DESC, ZONE_CODE  " +
                //           "FROM MS_DISTRICT " +
                //           "WHERE 1=1 " +
                //           "AND UPPER(DISTRICT_DESC) LIKE NVL(:districtName,'%') " +
                //           "ORDER BY DISTRICT_DESC ASC";



                // string SP = "ms_institute_pkg.p_office_list";
                //List<OracleParameter> paramList = new List<OracleParameter>();

                //paramList.Add(SqlHelper.GetOraParam(":p_office_code", office.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList[paramList.Count - 1].Size = 4000;
                //paramList.Add(SqlHelper.GetOraParam(":p_office_name", office.OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList[paramList.Count - 1].Size = 4000;
                //paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<District> districts = new List<District>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    District dist = new District();
                    dist.DistrictCode = dr["DISTRICT_CODE"].ToString();
                    dist.DistrictDesc = dr["DISTRICT_DESC"].ToString();
                    //offcTyp.CreatedBy = dr["CREATED_BY"].ToString();
                    //offcTyp.CreatedOn = dr["CREATED_ON"].ToString();



                    districts.Add(dist);


                }
                return districts;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public object GetDistrictList(string districtName)
        {
            string sp = "fn_member_clients_pkg.p_district_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_district_name", districtName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<District> lst = new List<District>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    District obj = new District();
                    obj.DistrictCode = drow["DISTRICT_CODE"].ToString();
                    obj.DistrictDesc = drow["DISTRICT_DESC"].ToString();

                    obj.Action = "U";
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
