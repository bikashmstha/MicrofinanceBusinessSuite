using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface IGroupDao
    {
        List<Group> GetGroups(int? groupID);
        string SaveGroup(Group group);
        Object SearchGroup(Group group);

        Object GetGroupTransfer(string  centerCode, string groupCode);

        object GetGroupForCenterTransfer(string centerCode, string groupName);

    }
}
