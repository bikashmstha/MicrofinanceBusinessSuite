using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class Center : BusinessObject
    {
        public Center() { }

        public string FiscalYear { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string VdcnpCode { get; set; }
        public string VdcDesc { get; set; }
        public string EmployeeId { get; set; }
        public int? CollectionDay { get; set; }
        public int? InstallmentInterval { get; set; }
        public string ComputerUserId { get; set; }
        public string CenterHouseBuiltDate { get; set; }
        public string FirstCollectionDate { get; set; }
        public double? MandatoryCollectionAmount { get; set; }
        public string CenterChief { get; set; }
        public string ChiefDate { get; set; }
        public string CenterCollectionTime { get; set; }
        public string ActiveFlags { get; set; }
        public string TranOfficeCode { get; set; }
        public string LastChangedDate { get; set; }
        public string TransferDate { get; set; }
        public string AdjustAccountHead { get; set; }
        public string DayDate { get; set; }
        public string CenterMeetingStartDate { get; set; }
        public double? UnitFundCollectionAmt { get; set; }
        public string CenterCategory { get; set; }
        public string ThirdPartyData { get; set; }
        public double? PenaltyOnLateCome { get; set; }
        public string CenterClosedDate { get; set; }
        public string CenterAddress { get; set; }
        public string PhoneNo { get; set; }

        public object BuildDateFrom { get; set; }

        public object BuildDateTo { get; set; }

        public string EmployeeName { get; set; }

        public string CollectionDesc { get; set; }

        public string AdjustAccountDesc { get; set; }

        public string InstituteName { get; set; }
    }
}
