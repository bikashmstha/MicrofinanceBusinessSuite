using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class AssetSendReceiptDetail : BusinessObject
    {
        public AssetSendReceiptDetail() { }

        public string Sno { get; set; }
        public string AssetCode { get; set; }
        public string ReceiveSeandDrop { get; set; }
        public string FromDeptCode { get; set; }
        public string FromDeptNaame { get; set; }
        public string ToDeptCode { get; set; }
        public string ToDeptName { get; set; }
        public string DeprCalcY_N { get; set; }
        public double CurrentValue { get; set; }
        public string TranDate { get; set; }
        public string TranDateBs { get; set; }
        public string TransferYN { get; set; }
        public string Remarks { get; set; }
        public double Uncalcdepr { get; set; }
        public string EmployeeId { get; set; }
        public string ToTranOffice_Code { get; set; }
        public string ToTranOffice_Name { get; set; }
        public string TranOfficeCode { get; set; }

        public string ReceiveSendDrop { get; set; }

        public string FromDeptName { get; set; }
    }
}
