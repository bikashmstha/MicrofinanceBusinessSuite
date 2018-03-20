using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    
    public class GenerateSavingCollection : BusinessObject
    {
        public GenerateSavingCollection() { }

        public string CollectionSheet_No { get; set; }
        public double SamagikSewa_Fund_Due { get; set; }
        public double GroupFund_Bal { get; set; }
        public double GroupFund_Due { get; set; }
        public string GroupfundAdjust_Y_N { get; set; }
        public string AdjustGroup_Fund_Ac { get; set; }
        public double SamagikSewa_Fund_Received { get; set; }
        public double GroupFund_Received { get; set; }
        public double PensionReceived { get; set; }
        public string SamagikSewa_Fund_Ac { get; set; }
        public string GroupFund_Ac { get; set; }
        public string PensionAc { get; set; }
        public string IndividualAc { get; set; }
        public double GroupfundAdjust_Amount { get; set; }
        public double PensionBal { get; set; }
        public double PensionDue { get; set; }
        public string PensionAdjust_Y_N { get; set; }
        public string AdjustPension_Ac { get; set; }
        public double PensionAdjust_Amount { get; set; }
        public string BusinessAc { get; set; }
        public double BusinessBal { get; set; }
        public double BusinessDepo { get; set; }
        public double BusinessReceived { get; set; }
        public double BusinessWithdraw { get; set; }
        public string SunauloAc { get; set; }
        public double SunauloBal { get; set; }
        public double SunauloDue { get; set; }
        public double SunauloReceived { get; set; }
        public string SunauloAdjust_Y_N { get; set; }
        public string AdjustSunaulo_Ac { get; set; }
        public double SunauloAdjust_Amount { get; set; }
        public double IndividualBal { get; set; }
        public double IndividualReceived { get; set; }
        public double IndividualWithdraw { get; set; }
        public string ReceivedY_N { get; set; }
        public string PresentY_N { get; set; }
        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
    }
}
