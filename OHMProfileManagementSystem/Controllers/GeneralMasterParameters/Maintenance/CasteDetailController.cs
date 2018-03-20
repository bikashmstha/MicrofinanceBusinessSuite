using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance
{
    public class CasteDetailController : ControllerBase
    {
        private static ICasteDetailDao casteDetailDao = DataAccess.CasteDetailDao;
        public object GetCasteShort(string caste)
        {
            return casteDetailDao.GetCasteShort(caste);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CasteDetail> GetCasteDetails()
        {
            List<CasteDetail> response;
            try
            {
                response = casteDetailDao.GetCasteDetails();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveCasteDetail(CasteDetail casteDetail)
        {
            OutMessage response;
            try
            {
                response = casteDetailDao.SaveCasteDetail(casteDetail);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }

        public object GetCastes(string CasteDesc)
        {
            return casteDetailDao.GetCastes(CasteDesc);
        }
    }
}