using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Maintenance;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance.AccountControl
{
    public class VoucherApprovalSecurityController:ControllerBase
    {
        private static IVoucherApprovalSecurityDao glVoucherApprovalSecurityDao = DataAccess.VoucherApprovalSecurityDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<VoucherApprovalSecurity> GetVoucherApprovalSecurity(string officeCode)
        {
            List<VoucherApprovalSecurity> response;
            try
            {
                response = glVoucherApprovalSecurityDao.GetVoucherApprovalSecurity(officeCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveVoucherApprovalSecurity(VoucherApprovalSecurity voucherApprovalSecurity)
        {
            OutMessage response;
            try
            {
                response = glVoucherApprovalSecurityDao.SaveVoucherApprovalSecurity(voucherApprovalSecurity);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}