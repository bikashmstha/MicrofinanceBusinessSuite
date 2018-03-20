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
    public class GlVoucherTypeController:ControllerBase
    {
        private static IGLVoucherTypeDao glVoucherTypeDao = DataAccess.GLVoucherTypeDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<GLVoucherType> GetGLVoucherType(string officeCode, string fiscalYear)
        {
            List<GLVoucherType> response;
            try
            {
                response = glVoucherTypeDao.GetGLVoucherType(officeCode,fiscalYear);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveGLVoucherType(GLVoucherType accountSubCategory)
        {
            OutMessage response;
            try
            {
                response = glVoucherTypeDao.SaveGLVoucherType(accountSubCategory);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}