using System;
using System.Collections.Generic;
using System.Data;

using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using DataObjects.Security;

using Oracle.DataAccess.Types;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects;


namespace DataObjects.AdoNet.Oracle.Security
{
    /// <summary>
    /// Oracle specific data access object that handles data access
    /// of customers. The details are stubbed out (in a crude way) but should be 
    /// relatively easy to implement as they are similar to MS Access and 
    /// Sql Server Data access objects.
    ///
    /// Enterprise Design Pattern: Service Stub.
    /// </summary>
    public class OracleUserDao : GenericUserDao
    {



        public GenericUser LogIn(GenericUser user)
        {
            User u = user as User;
            GetConnection gc = new GetConnection();
            OracleConnection objConn;
            try
            {
                //objConn = gc.GetDbConn(u);  //old
                objConn = gc.GetDbConn();    //new

                bool valid = false;
                string query = "Select CURRENT_TIMESTAMP(0) as Result from dual";

                OracleTimeStampTZ ots = new OracleTimeStampTZ();

                DataSet ds = SqlHelper.ExecuteDataset(objConn, CommandType.Text, query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strTime = ds.Tables[0].Rows[0]["Result"].ToString(); //"11/13/2017 4:20:13 PM";
                    ots = (OracleTimeStampTZ)General.ParseOracleDate(strTime);
                }

                string office_code = string.Empty;
                string office_name = string.Empty;
                string company_name = string.Empty;
                string fiscal_year = string.Empty;
                string mis_date_eng = string.Empty;
                string mis_date_nep = string.Empty;
                string office_state = string.Empty;
                string count_ro_office = string.Empty;
                string count_bo_office = string.Empty;
                string user_name = string.Empty;
                string user_post = string.Empty;
                string emp_img_path = string.Empty;
                string report_url = string.Empty;
                string result_code = string.Empty;
                string result_msg = string.Empty;

                string SP = "SECURITY_PKG.p_login1";

                try
                {
                    List<OracleParameter> paramList = new List<OracleParameter>();

                    //v_out_office_code        OUT VARCHAR2,
                    //v_out_office_name       OUT VARCHAR2,
                    //v_out_company_name   OUT VARCHAR2,
                    //v_out_fiscal_year          OUT VARCHAR2,
                    //v_out_mis_date_eng       OUT DATE,
                    //v_out_mis_date_nep       OUT VARCHAR2,
                    //v_out_office_state          OUT VARCHAR2,
                    //v_out_count_ro_office      OUT VARCHAR2,
                    //v_out_count_bo_office   OUT  VARCHAR2,
                    //v_out_user_name         OUT VARCHAR2,
                    //v_out_user_post           OUT VARCHAR2,
                    //v_out_emp_img_path   OUT VARCHAR2,
                    //v_out_report_url         OUT VARCHAR2,      
                    //v_out_result_code        OUT VARCHAR2,
                    //v_out_result_msg         OUT VARCHAR2)
                    paramList.Add(SqlHelper.GetOraParam("p_user_code", u.UserID, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam("p_user_pwd", u.Password, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam("p_user_ip", u.IpAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam("p_session_id", u.SessionId, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam("p_current_timestamp", ots, OracleDbType.Varchar2, ParameterDirection.Input));

                    paramList.Add(SqlHelper.GetOraParam("v_out_office_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_office_name", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_company_name", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_fiscal_year", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_mis_date_eng", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_mis_date_nep", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_office_state", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_count_ro_office", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_count_bo_office", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_user_name", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_user_post", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_emp_img_path", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_report_url", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;
                    paramList.Add(SqlHelper.GetOraParam("v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 4000;

                    var v = SqlHelper.ExecuteNonQuery(objConn, CommandType.StoredProcedure, SP, paramList.ToArray());



                    office_code = paramList[5].Value.ToString();
                    office_name = paramList[6].Value.ToString();
                    company_name = paramList[7].Value.ToString();
                    fiscal_year = paramList[8].Value.ToString();
                    mis_date_eng = paramList[9].Value.ToString();
                    mis_date_nep = paramList[10].Value.ToString();
                    office_state = paramList[11].Value.ToString();
                    count_ro_office = paramList[12].Value.ToString();
                    count_bo_office = paramList[13].Value.ToString();
                    user_name = paramList[14].Value.ToString();
                    user_post = paramList[15].Value.ToString();
                    emp_img_path = paramList[16].Value.ToString();
                    report_url = paramList[17].Value.ToString();
                    result_code = paramList[18].Value.ToString();
                    result_msg = paramList[19].Value.ToString();


                    valid = result_code == "SUCCESS" ? true : false;

                    u.LoggedIn = valid;



                    # region old
                    //DateTime date = boCommon.ParseNormalDate(Session["MisDateEnglish"].ToString());

                    //lit_branch.Text = boCommon.GetOfficeName(Session["OfficeCode"].ToString()).ToString() + " : " + Session["OfficeCode"].ToString();
                    //lit_company.Text = boCommon.GetCompanyName();
                    //lit_fiscal_year.Text = boCommon.GetFiscalYearFromInput(Session["MisDateEnglish"].ToString());
                    //lbl_date_bs.Text = Session["MisDateNepali"].ToString() + " (B.S.)";
                    //lbl_date_ad.Text = Session["MisDateEnglish"].ToString() + " (A.D.) " + date.DayOfWeek;
                    //lbl_office_state.Text = boCommon.GetOfficeState(Session["OfficeCode"].ToString()) == "S" ? "Day Begin" : "Day End";
                    //lbl_tot_RO.Text = "<b>Regional Office : </b>" + boCommon.GetOfficeCount("RO");
                    //lbl_tot_BO.Text = "<b>Branch Office: </b>" + boCommon.GetOfficeCount("BO");
                    //lit_user.Text = boCommon.GetEmpNameFromUserCode(Session["OfficeCode"].ToString(), Session["LoggedInUser"].ToString().ToUpper());
                    //lblFullName.Text = boCommon.GetEmpNameFromUserCode(Session["OfficeCode"].ToString(), Session["LoggedInUser"].ToString().ToUpper());
                    //lblUsername.Text = "(" + Session["LoggedInUser"].ToString().ToUpper().ToLower() + ")"; ;
                    //lblPost.Text = boCommon.GetPostNameFromUserCode(Session["LoggedInUser"].ToString().ToUpper());
                    ////Setting image path of user
                    //imgUser.ImageUrl = "~/App_Themes/UserThemes/images/user1.png";//?a="+DateTime.Now.ToString("yyyyMMddhhmmss");
                    ////If there is image of employee then showing that image
                    //string imgEmp = boCommon.GetEmpImagePath(boCommon.GetEmpIdFromUserCode(Session["LoggedInUser"].ToString().ToUpper()));
                    //if (!string.IsNullOrEmpty(imgEmp))
                    //{
                    //    imgMember.ImageUrl = "~/" + imgEmp;
                    //}
                    //else
                    //{
                    //    imgMember.ImageUrl = "~/App_Themes/UserThemes/images/user_large.png";//?a="+DateTime.Now.ToString("yyyyMMddhhmmss");
                    //}
                    //imgUpArrow.ImageUrl = "~/App_Themes/UserThemes/images/arrow_top.png";//?a="+DateTime.Now.ToString("yyyyMMddhhmmss");
                    #endregion

                    if (result_code == "SUCCESS")
                    {
                        u.FiscalYear = fiscal_year;
                        u.MisDateEnglish = mis_date_eng;
                        u.MisDateNepali = mis_date_nep;
                        u.UserName = user_name;
                        u.Post = user_post;
                        u.ImagePath = emp_img_path;
                        u.ReportUrl = paramList[8].Value.ToString();

                        Office office = new Office();
                        office.OfficeCode = office_code;
                        office.OfficeName = office_name;
                        office.CompanyName = company_name;
                        office.OfficeStatus = office_state;
                        office.RegionalOfficeCount = count_ro_office;
                        office.BranchOfficeCount = count_bo_office;


                        u.Office = office;
                        //httpcontext.current.session["officecode"] = _officecode;
                        //httpcontext.current.session["loggedinuser"] = userid;
                        //u.MisDateNepali = paramList[7].Value.ToString(); 
                        //httpcontext.current.session["misdateenglish"] = bocommon.parseoracledate(_misdateenglish);   //??
                        //httpcontext.current.session["validlogin"] = true; //implemented above
                        // httpcontext.current.session["ip"] = httpcontext.current.request.userhostaddress;    //implemented on LoginHandler
                        //httpcontext.current.session["showpopup"] = "y";    // not needed
                        //u.ReportUrl = paramList[8].Value.ToString();
                        //_issuccess = true;
                    }
                    else if (result_code == "7")
                    {
                        //--for case 7: login not successful, forceful password change days exceeded
                        //v_out_result_code := '7';
                        //v_out_result_msg := 'please change password first and try to log in again.';

                        //httpcontext.current.session["officecode"] = _officecode;
                        //httpcontext.current.session["loggedinuser"] = userid;
                        //u.MisDateNepali = paramList[7].Value.ToString(); 
                        // httpcontext.current.session["misdateenglish"] = bocommon.parseoracledate(_misdateenglish);
                        //u.ReportUrl = paramList[8].Value.ToString();                      
                        //showing error message
                        //modal_popup_msg_error.show();
                        //lbl_popup_msg_error.text = strmsgout;
                        //httpcontext.current.session["ip"] = httpcontext.current.request.userhostaddress;
                        //strresultcode = strcdout;
                        //strresultmsg = strmsgout;

                    }
                    else if (result_code == "9")
                    {
                        //--for case 9: login not successful, user logging in for the first time.
                        //v_out_result_code := '9';
                        //v_out_result_msg := 'user logging in for the first time. please change password and try to log in again.';

                        //httpcontext.current.session["officecode"] = _officecode;
                        //httpcontext.current.session["loggedinuser"] = userid;
                        //httpcontext.current.session["ip"] = httpcontext.current.request.userhostaddress;
                        //u.MisDateNepali = paramList[7].Value.ToString(); 
                        // httpcontext.current.session["misdateenglish"] = bocommon.parseoracledate(_misdateenglish);
                        //u.ReportUrl = paramList[8].Value.ToString();

                        //showing error message
                        // modal_popup_msg_error.show();
                        //lbl_popup_msg_error.text = strmsgout;
                        //strresultcode = strcdout;
                        //strresultmsg = strmsgout;

                    }
                    else if (result_code == "6")
                    {

                        //--for case 6: login successful, password reminder date.
                        //v_out_result_code := '6';
                        //v_out_result_msg := 'login successful.'||' your password will expire on '|| to_char(v_force_pwd_change_on, 'dd-mon-yyyy') ||'. please change your password.';

                        //httpcontext.current.session["officecode"] = _officecode;
                        //httpcontext.current.session["loggedinuser"] = userid;
                        //u.MisDateNepali = paramList[7].Value.ToString(); 
                        //httpcontext.current.session["misdateenglish"] = bocommon.parseoracledate(_misdateenglish);
                        //u.ReportUrl = paramList[8].Value.ToString();
                        //httpcontext.current.session["validlogin"] = true;
                        //httpcontext.current.session["ip"] = httpcontext.current.request.userhostaddress;
                        //strresultcode = strcdout;
                        //strresultmsg = strmsgout;
                        //_issuccess = true;
                    }
                    else
                    {
                        //strresultmsg = strmsgout;
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    objConn.Close();
                }


                //u.LoggedIn = Validate();

                OracleMenuDao menudao = new OracleMenuDao();
                u.Menus = menudao.GetMenuListByUser(user);

                //OracleOfficeUserDao offUserDao = new OracleOfficeUserDao();
                //u.OfficeUser = offUserDao.GetUserOffice(user.DatabaseAccessUserName, user);


            }
            catch (OracleException oex)//catch (OracleException oex)
            {
                u.LoggedIn = false;
                //gc.CloseDbConn();
                //OracleError oe = new OracleError();
                //throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            finally
            {
                // gc.CloseDbConn();
            }
            return u;

        }



        public object GetUserShort()
        {
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new OracleConnection();

            try
            {
                string SP = "security_pkg.p_change_pwd_user_lov";
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_emp_name", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<User> lst = new List<User>();


                User obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new User();
                    obj.UserID = drow["USER_CODE"].ToString();//APPLICATION_ID
                    obj.UserName = drow["USER_NAME"].ToString();//APPLICATION_DESCRIPTION
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object ResetUserPassword(string officeCode, string userCode, string newPwd, string cNewPwd, string changeByOfficeCode, string changeByUserCode)
        {
            string SP = "SECURITY_PKG.P_RESET_USER_PASSWORD";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();
            OracleTransaction tran = null;

            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_off_code", officeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_user_code", userCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_new_passowrd", newPwd, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_confirm_new_password", cNewPwd, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_change_by_office", changeByOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_change_by_user", changeByUserCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[6].Size = 10;
            paramList[7].Size = 100;


            try
            {
                tran = conn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object Get()
        {
            string sp = "user_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<User> lst = new List<User>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    User obj = new User();
                    obj.UserCode = drow["UserCode"].ToString();
                    obj.UserName = drow["UserName"].ToString();
                    obj.Password = drow["Password"].ToString();
                    obj.RoleCode = drow["RoleCode"].ToString();
                    obj.MaxConnect = int.Parse(drow["MaxConnect"].ToString());
                    obj.ConnectFlag = int.Parse(drow["ConnectFlag"].ToString());
                    obj.MaxApprovalAmount = int.Parse(drow["MaxApprovalAmount"].ToString());
                    obj.OfficeCreation = int.Parse(drow["OfficeCreation"].ToString());
                    obj.OfficeCode = drow["OfficeCode"].ToString();
                    obj.GmtOffset = drow["GmtOffset"].ToString();
                   // obj.LoggedIn = drow["LoggedIn"].ToString();
                    obj.ForcePwdChangeInDays = int.Parse(drow["ForcePwdChangeInDays"].ToString());
                    obj.PwdReminderDate = drow["PwdReminderDate"].ToString();
                    obj.LastLoginDate = drow["LastLoginDate"].ToString();
                    obj.MaxInactiveDays = int.Parse(drow["MaxInactiveDays"].ToString());
                    obj.LastPwdChangeDate = drow["LastPwdChangeDate"].ToString();
                    obj.IsRemoteUser = drow["IsRemoteUser"].ToString();
                    obj.FailedLoginDate = drow["FailedLoginDate"].ToString();
                    obj.NoOfFailedLoginAttempts = int.Parse(drow["NoOfFailedLoginAttempts"].ToString());
                    obj.ManageOtherOfficeUsers = drow["ManageOtherOfficeUsers"].ToString();
                    obj.ActivateOtherOfficeUsers = drow["ActivateOtherOfficeUsers"].ToString();
                    obj.ManageOwnBranchUsers = drow["ManageOwnBranchUsers"].ToString();
                    obj.ActivateUsers = drow["ActivateUsers"].ToString();
                    obj.IsValidated = drow["IsValidated"].ToString();
                    obj.LoginStartTime = drow["LoginStartTime"].ToString();
                    obj.LoginEndTime = drow["LoginEndTime"].ToString();
                    obj.FirstTimeLogin = drow["FirstTimeLogin"].ToString();
                    obj.UserStatus = drow["UserStatus"].ToString();
                    obj.EmpId = drow["EmpId"].ToString();
                    obj.IsOnLeave = drow["IsOnLeave"].ToString();
                    obj.CreTranOfficeCode = drow["CreTranOfficeCode"].ToString();

                    obj.ModTranOfficeCode = drow["ModTranOfficeCode"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();

                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.TranOfficeGrpCode = drow["TranOfficeGrpCode"].ToString();
                    obj.AllowMultipleLogin = drow["AllowMultipleLogin"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(User user)
        {
            string sp = "security_pkg.p_user";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_UserCode", user.UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserName", user.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Password", user.Password, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RoleCode", user.RoleCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxConnect", user.MaxConnect, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ConnectFlag", user.ConnectFlag, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxApprovalAmount", user.MaxApprovalAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OfficeCreation", user.OfficeCreation, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OfficeCode", user.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GmtOffset", user.GmtOffset, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ForcePwdChangeInDays", user.ForcePwdChangeInDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PwdReminderDate", user.PwdReminderDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxInactiveDays", user.MaxInactiveDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsRemoteUser", user.IsRemoteUser, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ManageOtherOfficeUsers", user.ManageOtherOfficeUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActivateOtherOfficeUsers", user.ActivateOtherOfficeUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ManageOwnBranchUsers", user.ManageOwnBranchUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActivateUsers", user.ActivateUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsValidated", user.IsValidated, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoginStartTime", user.LoginStartTime, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoginEndTime", user.LoginEndTime, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserStatus", user.UserStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpId", user.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsOnLeave", user.IsOnLeave, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreTranOfficeCode", user.CreTranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AllowMultipleLogin", user.AllowMultipleLogin, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfFailedLoginAttempts", user.NoOfFailedLoginAttempts, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", user.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeGrpCode", user.TranOfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":p_action", user.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 10;
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

        public object Search(User user)
        {
            string sp = "security_pkg.p_user";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_UserCode", user.UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserName", user.UserName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Password", user.Password, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RoleCode", user.RoleCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxConnect", user.MaxConnect, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ConnectFlag", user.ConnectFlag, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxApprovalAmount", user.MaxApprovalAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OfficeCreation", user.OfficeCreation, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OfficeCode", user.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GmtOffset", user.GmtOffset, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoggedIn", user.LoggedIn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ForcePwdChangeInDays", user.ForcePwdChangeInDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PwdReminderDate", user.PwdReminderDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastLoginDate", user.LastLoginDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxInactiveDays", user.MaxInactiveDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastPwdChangeDate", user.LastPwdChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsRemoteUser", user.IsRemoteUser, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FailedLoginDate", user.FailedLoginDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfFailedLoginAttempts", user.NoOfFailedLoginAttempts, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ManageOtherOfficeUsers", user.ManageOtherOfficeUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActivateOtherOfficeUsers", user.ActivateOtherOfficeUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ManageOwnBranchUsers", user.ManageOwnBranchUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActivateUsers", user.ActivateUsers, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsValidated", user.IsValidated, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoginStartTime", user.LoginStartTime, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoginEndTime", user.LoginEndTime, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstTimeLogin", user.FirstTimeLogin, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UserStatus", user.UserStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpId", user.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IsOnLeave", user.IsOnLeave, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreTranOfficeCode", user.CreTranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", user.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModTranOfficeCode", user.ModTranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", user.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", user.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", user.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeGrpCode", user.TranOfficeGrpCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AllowMultipleLogin", user.AllowMultipleLogin, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<User> lst = new List<User>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    User obj = new User();
                    obj.UserCode = drow["UserCode"].ToString();
                    obj.UserName = drow["UserName"].ToString();
                    obj.Password = drow["Password"].ToString();
                    obj.RoleCode = drow["RoleCode"].ToString();
                    obj.MaxConnect = int.Parse(drow["MaxConnect"].ToString());
                    obj.ConnectFlag = int.Parse(drow["ConnectFlag"].ToString());
                    obj.MaxApprovalAmount = int.Parse(drow["MaxApprovalAmount"].ToString());
                    obj.OfficeCreation = int.Parse(drow["OfficeCreation"].ToString());
                    obj.OfficeCode = drow["OfficeCode"].ToString();
                    obj.GmtOffset = drow["GmtOffset"].ToString();
                    //obj.LoggedIn = drow["LoggedIn"].ToString();
                    obj.ForcePwdChangeInDays = int.Parse(drow["ForcePwdChangeInDays"].ToString());
                    obj.PwdReminderDate = drow["PwdReminderDate"].ToString();
                    obj.LastLoginDate = drow["LastLoginDate"].ToString();
                    obj.MaxInactiveDays = int.Parse(drow["MaxInactiveDays"].ToString());
                    obj.LastPwdChangeDate = drow["LastPwdChangeDate"].ToString();
                    obj.IsRemoteUser = drow["IsRemoteUser"].ToString();
                    obj.FailedLoginDate = drow["FailedLoginDate"].ToString();
                    obj.NoOfFailedLoginAttempts = int.Parse(drow["NoOfFailedLoginAttempts"].ToString());
                    obj.ManageOtherOfficeUsers = drow["ManageOtherOfficeUsers"].ToString();
                    obj.ActivateOtherOfficeUsers = drow["ActivateOtherOfficeUsers"].ToString();
                    obj.ManageOwnBranchUsers = drow["ManageOwnBranchUsers"].ToString();
                    obj.ActivateUsers = drow["ActivateUsers"].ToString();
                    obj.IsValidated = drow["IsValidated"].ToString();
                    obj.LoginStartTime = drow["LoginStartTime"].ToString();
                    obj.LoginEndTime = drow["LoginEndTime"].ToString();
                    obj.FirstTimeLogin = drow["FirstTimeLogin"].ToString();
                    obj.UserStatus = drow["UserStatus"].ToString();
                    obj.EmpId = drow["EmpId"].ToString();
                    obj.IsOnLeave = drow["IsOnLeave"].ToString();
                    obj.CreTranOfficeCode = drow["CreTranOfficeCode"].ToString();

                    obj.ModTranOfficeCode = drow["ModTranOfficeCode"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();

                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.TranOfficeGrpCode = drow["TranOfficeGrpCode"].ToString();
                    obj.AllowMultipleLogin = drow["AllowMultipleLogin"].ToString();

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