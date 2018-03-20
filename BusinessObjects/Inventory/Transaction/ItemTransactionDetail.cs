using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class ItemTransactionDetail : BusinessObject
    {
        public ItemTransactionDetail() { }

        public string ReferenceNo { get; set; }
        public string ItemCode { get; set; }
        public string TransactionType { get; set; }
        public double TransactionQuantity { get; set; }
        public double TransactionCost { get; set; }
        public double RemainingQty { get; set; }
        public string UnitCode { get; set; }
        public string ExpiryDate { get; set; }
        public double OrderNo { get; set; }
        public string Remarks { get; set; }
        public string Date1 { get; set; }
        public string TranOfficeCode { get; set; }
        public string Username { get; set; }
    }
}
