using App.Utilities.Web.Handlers;
using BusinessObjects;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MicrofinanceBusinessSuite.Controllers.Finance;
using BusinessObjects.Finance;

namespace MicrofinanceBusinessSuite.Handlers.Finance
{
    public class MemberHandler : BaseHandler
    {
        private static MemberController controller = new MemberController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string member)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Member obj = (new JavaScriptSerializer().Deserialize(member, typeof(Member))) as Member;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string member)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Member search = (new JavaScriptSerializer().Deserialize(member, typeof(Member))) as Member;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetMemberList(string offCode, string centerCode, string memberName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberList(offCode,centerCode,memberName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemberLovList(string offCode, string centerCode, string memberName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberLovList(offCode, centerCode, memberName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemberForAccOpen(string offCode, string centerCode, string memberName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberForAccOpen(offCode, centerCode, memberName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}