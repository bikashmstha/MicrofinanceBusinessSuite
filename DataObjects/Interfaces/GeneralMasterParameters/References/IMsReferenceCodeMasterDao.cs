using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
   public interface IMsReferenceCodeMasterDao
    {
       List<MSReferenceCodeMaster> GetMSReferenceCodeMaster();
       OutMessage SaveMSReferenceCodeMaster(MSReferenceCodeMaster msControlValues);
       
       
       
    }
}
