using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using BusinessObjects;
namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface ICasteDetailDao 
    {
        object GetCasteShort(string caste);
        List<CasteDetail> GetCasteDetails();
        OutMessage SaveCasteDetail(CasteDetail casteDetail);

        object GetCastes(string CasteDesc);
    }
}
