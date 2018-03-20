using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Common;

namespace DataObjects.Interfaces.Common
{
    public interface IDistrictDao
    {
        List<District> SearchDistrict(District district);

        object GetDistrictList(string districtName);
    }
}
