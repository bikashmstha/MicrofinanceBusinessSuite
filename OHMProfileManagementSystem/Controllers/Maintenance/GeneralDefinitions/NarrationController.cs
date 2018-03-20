using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.Maintenance;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.Maintenance;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance.GeneralDefinitions
{
    public class NarrationController:ControllerBase
    {
        private static INarrationDao narrationDao = DataAccess.NarrationDao ;
      
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Narration> GetNarrations()
        {
            List<Narration> response;
            try
            {
                 response = narrationDao.GetNarrations();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveNarration(Narration narration)
        {
            OutMessage response;
            try
            {
                response = narrationDao.SaveNarration(narration);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return response;

        }
    }
}