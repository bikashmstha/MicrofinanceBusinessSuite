using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Office:BusinessObject 
    {
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string OfficeTypeCode { get; set; }
        public string OfficeTypeName { get; set; }
        public string ParentOfficeCode { get; set; }
        public string ParentOfficeName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }

        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AreaGrading { get; set; }
        public int? OfficeAccCodePrefix { get; set; }
        public string EstablishedDate { get; set; }
        public string VdcCode { get; set; }
        public string VdcName { get; set; }
       
        public string MigratedDate { get; set; }
        public string ThirdPartyData { get; set; }
        public string OfficeStatus { get; set; }
        public string CenterRange { get; set; }
        public string FirstLoanDisburseDate { get; set; }
        public int? DisplaySeq { get; set; }
        public string CurrentFiscalYear { get; set; }
        public string LastFiscalYear { get; set; }
        public int? MaxPeriodAdditionalLoan { get; set; }
        public double? CompulsoryCollectionAmt { get; set; }
        public int? MaxNofLoan { get; set; }
        public string ControlFromCdms { get; set; }
        public string BudgetControlYN { get; set; }
        public string LocationCode { get; set; }
        public string ApprovalRangeControl { get; set; }
        public int? CurrentYear { get; set; }
        public string BranchOnMW { get; set; }
        public string InterbranchAccountHead { get; set; }
        public string InterbranchAccountHeadName { get; set; }
        public string OfficeInactiveDate { get; set; }
        public string MigrationInProcess { get; set; }
        public string TransactionDate { get; set; }
        public string DefaultLocationCode { get; set; }
        public string ReportingGrp { get; set; }
        public string AbbsAllowYN { get; set; }
        public double? AbbsWithdrawLimit { get; set; }
        public double? AbbsDepositLimit { get; set; }
        public string SrgEnableYN { get; set; }
        public string AutoAdjustmentCollSht { get; set; }
        public string OpenPublicMem { get; set; }
        public string AutoAcOnNonMem { get; set; }
        public string OfficeCategory { get; set; }
        public string PRAccountHead { get; set; }
        public string RowID { get; set; }
        public string BudgetAlloCationYN { get; set; }

        public string CompanyName { get; set; }

        public string RegionalOfficeCount { get; set; }

        public string BranchOfficeCount { get; set; }
    }
}