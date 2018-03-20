using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class InfFaAsset : BusinessObject
    {
        public InfFaAsset() { }

        public string FiscalYear { get; set; }
        public string AssetSerialNo { get; set; }
        public string ItemCode { get; set; }
        public string AssetDesc { get; set; }
        public string EmpId { get; set; }
        public string DeptCode { get; set; }
        public string SupplierCode { get; set; }
        public string CategoryCode { get; set; }
        public string ActiveFlag { get; set; }
        public string DateAquired { get; set; }
        public string DateSold { get; set; }
        public double PurchasePrice { get; set; }
        public double TotalMatenance { get; set; }
        public double TotalDepreciation { get; set; }
        public string DepreciationMethod { get; set; }
        public double DepreciableLife { get; set; }
        public double SalvageValue { get; set; }
        public double CurrentValue { get; set; }
        public string NextSchedMat { get; set; }
        public double DepreciablePercentage { get; set; }
        public double SoldAmount { get; set; }
        public string LastDeprDate { get; set; }
        public double LastDeprAmt { get; set; }
        public string CalcDeprFrom { get; set; }
        public string CalcDeprTo { get; set; }
        public string Status { get; set; }
        public string AssetCategory { get; set; }
        public string Remarks { get; set; }
        public string CurrDeptCode { get; set; }
        public string TransferYN { get; set; }
        public string TransferAssetCode { get; set; }
        public string Donar { get; set; }
        public string TranOfficeCode { get; set; }
        public string Username { get; set; }
        public string Date1 { get; set; }
        public string OutAssetCode { get; set; }
    }
}
