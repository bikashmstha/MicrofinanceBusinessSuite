using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjects.BusinessRules;
using BusinessObjects.GeneralMasterParameters;


namespace BusinessObjects.Security
{
    /// <summary>
    /// Encapsulates Integrated Tax System User Information
    /// </summary>
    /// <remarks>ramarksssssssssssss</remarks>
    public class User : GenericUser
    {
        public User()
        {
            
        }


        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UsernamEng { get; set; }
        public string UserNameNepali { get; set; }

        public string Password { get; set; }
        public string App_Owner { get; set; }
        public string Profile { get; set; }
        public string IsAdmin { get; set; }
        public string AccountStatus { get; set; }
        public string OsUser { get; set; }
        public string TranDate { get; set; }
        public string OracleUser { get; set; }
        //public string OracleUserPassword { get; set; }
        public string Machine { get; set; }
        public string Remarks { get; set; }
        //public string CreatedBy { get; set; }        
        public string ContactNo { get; set; }

        public string IpAddress { get; set; }
        public string MisDateNepali { get; set; }
        public string MisDateEnglish { get; set; }
        public string ReportUrl { get; set; }
        public string SessionId { get; set; }



        public override string DatabaseAccessUserName
        {
            get { return this.UserID; }
            // set { }
        }

        public override string DatabaseAccessUserPassword
        {
            get { return this.Password; }
            // set { }
        }

        public List<Menu> Menus { get; set; }




        private bool _LoggedIn = false;
        public override bool LoggedIn
        {
            get { return _LoggedIn; }
            set { _LoggedIn = value; }
        }

        private Office _Office = new Office();
        public Office Office
        {
            get { return _Office; }
            set { _Office = value; }
        }

        /////////////
        public string UserCode { get; set; }
        public string RoleCode { get; set; }
        public int MaxConnect { get; set; }
        public int ConnectFlag { get; set; }
        public int MaxApprovalAmount { get; set; }
        public int OfficeCreation { get; set; }
        public string OfficeCode { get; set; }
        public string GmtOffset { get; set; }
        public int ForcePwdChangeInDays { get; set; }
        public string PwdReminderDate { get; set; }
        public string LastLoginDate { get; set; }
        public int MaxInactiveDays { get; set; }
        public string LastPwdChangeDate { get; set; }
        public string IsRemoteUser { get; set; }
        public string FailedLoginDate { get; set; }
        public int NoOfFailedLoginAttempts { get; set; }
        public string ManageOtherOfficeUsers { get; set; }
        public string ActivateOtherOfficeUsers { get; set; }
        public string ManageOwnBranchUsers { get; set; }
        public string ActivateUsers { get; set; }
        public string IsValidated { get; set; }
        public string LoginStartTime { get; set; }
        public string LoginEndTime { get; set; }
        public string FirstTimeLogin { get; set; }
        public string UserStatus { get; set; }
        public string EmpId { get; set; }
        public string IsOnLeave { get; set; }
        public string CreTranOfficeCode { get; set; }
        public string ModTranOfficeCode { get; set; }
        public string TranOfficeGrpCode { get; set; }
        public string AllowMultipleLogin { get; set; }

        public string FiscalYear { get; set; }

        public string Post { get; set; }

        public string ImagePath { get; set; }
    }
}