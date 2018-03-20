using BusinessObjects.GeneralMasterParameters;
using DataObjects.Interfaces.GeneralMasterParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleOfficeTypeDao : IOfficeTypeDao
    {

        


        public List<OfficeType> GetOfficeTypes()
        {
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();

                string strQuery =
                        "SELECT ALL MS_INSTITUTE_TYPE.INSTITUTE_TYPE_CODE,MS_INSTITUTE_TYPE.INSTITUTE_TYPE_DESC " +
                                "FROM MS_INSTITUTE_TYPE  " +
                                "ORDER BY INSTITUTE_TYPE_CODE";


               // string SP = "ms_institute_pkg.p_office_list";
                //List<OracleParameter> paramList = new List<OracleParameter>();

                //paramList.Add(SqlHelper.GetOraParam(":p_office_code", office.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList[paramList.Count - 1].Size = 4000;
                //paramList.Add(SqlHelper.GetOraParam(":p_office_name", office.OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList[paramList.Count - 1].Size = 4000;
                //paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));


                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strQuery);

                List<OfficeType> officeTypes = new List<OfficeType>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    OfficeType offcTyp = new OfficeType();
                    offcTyp.OfficeTypeCode = dr["INSTITUTE_TYPE_CODE"].ToString();
                    offcTyp.OfficeTypeName = dr["INSTITUTE_TYPE_DESC"].ToString();
                    //offcTyp.CreatedBy = dr["CREATED_BY"].ToString();
                    //offcTyp.CreatedDate = dr["CREATED_ON"].ToString();



                    officeTypes.Add(offcTyp);


                }
                return officeTypes;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
