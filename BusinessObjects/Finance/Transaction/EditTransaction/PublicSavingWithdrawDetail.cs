﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdrawDetail : BusinessObject
    {
        public PublicSavingWithdrawDetail() { }

        public string ChequeNo { get; set; }
        public string ValueDate { get; set; }
        public string ContraAccount { get; set; }
        public string AcOfficeCode { get; set; }
        public string AccountNo { get; set; }
        public string PayeeName { get; set; }
        public double PenaltyAmount { get; set; }
        public string SavingProductCode { get; set; }
        public string ClientNo { get; set; }
        public string Remarks { get; set; }
        public string ProductName { get; set; }
        public int ContraAcNo { get; set; }
        public string AccountDesc { get; set; }
        public double CurrentBalance { get; set; }
        public string AccountStatus { get; set; }
        public string SavingAccountNo { get; set; }
        public string TranOfficeCode { get; set; }
        public double WithdrawAmount { get; set; }
        public string WithdrawDate { get; set; }
        public string WithdrawDateBs { get; set; }
        public string WithdrawType { get; set; }
        public double WithdrawalNo { get; set; }
        public string ImagePath { get; set; }
        public string JointImagePath { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double WithdrawLimit { get; set; }
        public string AccountOperationType { get; set; }
        public string VoucherNo { get; set; }
        public string ChargeSource { get; set; }
        public int ReferenceDepositNo { get; set; }
        public int ReferenceWithdrawalNo { get; set; }
        public string ChargeVoucherNo { get; set; }
        public string ChargeVoucherDate { get; set; }
    }
}
