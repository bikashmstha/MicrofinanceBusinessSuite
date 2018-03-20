using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OHMProfileManagementSystem.OHMProfileManagementSystemServiceReference;

using System.ComponentModel;
namespace  OHMProfileManagementSystem.Controllers
{
      [DataObject(true)]
    public class MemberController:ControllerBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public string GetToken()
        {
             
            TokenRequest request = new TokenRequest();
            request.RequestId = NewRequestId;
            request.ClientTag = ClientTag;

            TokenResponse response = OHMProfileManagementSystemServiceClient.GetToken(request);

            if (request.RequestId != response.CorrelationId)
                throw new ApplicationException("GetToken: RequestId and CorrelationId do not match.");

            return response.AccessToken;
        }
        public IList<object> GetMemberList()
        {
            
            //MemberRequest request = new MemberRequest();
            //request.RequestId = NewRequestId;
            //request.ClientTag = ClientTag;
            //request.AccessToken = AccessToken;


            //MemberReponse response = ActionServiceClient.GetMembership(request);
            //request.UserName = Username;
            //request.Password = Password;

            // ServiceReference1.ActionServiceClient Objservice = new ServiceReference1.ActionServiceClient();
            // Memberre response = ActionServiceClient.Login(request);
            // return (response.Acknowledge == AcknowledgeType.Success);

            TokenResponse tr =  OHMProfileManagementSystemServiceClient.GetToken(new TokenRequest());
            return null;
        }
        public bool Login()
        {

            TokenResponse tr = OHMProfileManagementSystemServiceClient.GetToken(new TokenRequest());
            return true;
            //LoginRequest request = new LoginRequest();


            //TaxPayer tp = (TaxPayer)System.Web.HttpContext.Current.Session["user"];
            //request.User = tp;
            //LoginResponse response = IntegratedTaxSystemServiceClient.Login(request);

            //if (response.Acknowledge == AcknowledgeType.Success)
            //{ return true; }
            //else
            //{ return false; }
        }
    }
}