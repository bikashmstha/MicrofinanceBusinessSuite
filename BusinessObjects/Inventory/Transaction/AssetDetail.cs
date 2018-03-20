using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class AssetDetail : BusinessObject
    {
        public AssetDetail() { }

        public string FiscalYear { get; set; }
        public string AssetCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string AssetDesc { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public int SupplierCode { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDesc { get; set; }
        public string ActiveFlag { get; set; }
        public string DateAquired { get; set; }
        public string DateSold { get; set; }
        public double PurchasePrice { get; set; }
        public double TotalMaintenance { get; set; }
        public double TotalDepreciation { get; set; }
        public string DepreciationMethod { get; set; }
        public int DepreciableLife { get; set; }
        public double SalvageValue { get; set; }
        public double CurrentValue { get; set; }
        public string NextSchedMaint { get; set; }
        public double DepreciablePercentage { get; set; }
        public double SoldAmount { get; set; }
        public string LastDeprDate { get; set; }
        public double LastDeprAmt { get; set; }
        public string CalcDeprFrom { get; set; }
        public string CalcDeprTo { get; set; }
        public string Status { get; set; }
        public string AssetCategory { get; set; }
        public string Remarks { get; set; }
        public string Donar { get; set; }
        public string AssetSerialNo { get; set; }
        public string SupplierDesc { get; set; }
        public string DateAquiredBs { get; set; }
        public string DateSoldBs { get; set; }
        public string LastDeprDate_Bs { get; set; }
        public string CalcDeprFrom_Bs { get; set; }
        public string CalcDeprTo_Bs { get; set; }
        public string TranOfficeCode { get; set; }

        public object FromDate { get; set; }

        public object ToDate { get; set; }
    }
}
