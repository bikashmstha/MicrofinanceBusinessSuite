using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.MessageBase;
using DataObjects;
using BusinessObjects.Messages;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;
using BusinessObjects.Message;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters
{
    /// <summary>
    /// Controller class for  Security.
    /// </summary>
    /// <remarks>
    /// MV Pattern: Model View Controller Pattern.
    /// This is a 'loose' implementation of the MVC pattern.
    /// </remarks>
    public class GroupsController : ControllerBase
    {
        private static IGroupDao groupDao = DataAccess.GroupDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>
        //[DataObjectMethod(DataObjectMethodType.Select)]
        //public IList<Group> GetGroups()
        //{
        //    GroupRequest request = new GroupRequest();
        //    request.User = this.User;
           
        //    return GetResponse(request);
        //}


        //private IList<Group> GetResponse(GroupRequest request)s
        //{

        //    List<Group> groups = groupDao.GetGroups(null,request.User);
           
        //    return null;
        //}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string SaveGroup(Group group)
        {
            //GroupRequest req = new GroupRequest();
            //req.Group = group;

            //req.User = this.User;
            string response = groupDao.SaveGroup(group);

            return response;
        }

        public object SearchGroup(Group group)
        {
            return groupDao.SearchGroup(group);
           
        }
        public object GetGroupTransfer(string centerCode, string groupCode)
        {
            return groupDao.GetGroupTransfer(centerCode,groupCode);

        }

        public object GetGroupForCenterTransfer(string centerCode, string groupName)
        {
            return groupDao.GetGroupForCenterTransfer(centerCode, groupName);

        }



    }
}