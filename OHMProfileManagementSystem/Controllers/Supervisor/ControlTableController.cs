using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.Supervisor;
using BusinessObjects;
using DataObjects.Interfaces.Supervisor;


namespace MicrofinanceBusinessSuite.Controllers.Supervisor
{
    public class ControlTableController:ControllerBase
    {
        private static IControlTableDao controlTableDao = DataAccess.ControlTableDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ControlTable> GetControlTable()
        {
            List<ControlTable> response;
            try
            {
                response = controlTableDao.GetControlTable();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveControlTable(ControlTable controlTable)
        {
            OutMessage response;
            try
            {
                response = controlTableDao.SaveControlTable(controlTable);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}