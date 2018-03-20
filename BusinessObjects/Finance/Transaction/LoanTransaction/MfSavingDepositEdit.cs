using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfSavingDepositEdit : BusinessObject
    {
        public MfSavingDepositEdit() { }

        public string AccountNo { get; set; }
        public string DepositDate { get; set; }
        public double DepositAmount { get; set; }
        public string ContraAccount { get; set; }
        public string MandatorySaving_Type { get; set; }
        public string VoucherNo { get; set; }
        public string EmpId { get; set; }
        public string Remarks { get; set; }
        public string TranOffice_Code { get; set; }
        public string User1 { get; set; }
        public string DepositBy { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscal_Year { get; set; }
        public double OutMf_Deposit_No { get; set; }
    }
}
