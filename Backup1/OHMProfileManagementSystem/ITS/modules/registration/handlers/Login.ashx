<%@ WebHandler Language="C#" Class="LoadUsers" %>

using System;
using System.Web;
using System.Collections.Generic;
using ASPNETWebApplication;
using ASPNETWebApplication.Controllers;
using ASPNETWebApplication.ActionServiceReference;
using Newtonsoft.Json;

public class LoadUsers : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       // context.Response.ContentType = "application/json";
        
        AjaxResponse response = new AjaxResponse() { success = ValidateUser(), msg = "Login Successful" };

       context.Response.Write(JsonConvert.SerializeObject(response));
       // context.Response.Write("{success:true}");
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private bool ValidateUser()
    {

        try
        {
            string submissionNo = HttpContext.Current.Request.Params["submissionNo"].ToString();
            string UserName = HttpContext.Current.Request.Params["loginUsername"].ToString();
            string Password = HttpContext.Current.Request.Params["loginPassword"].ToString();

            if (UserName != "" && Password != "")
            {
                if (submissionNo == "bikash" && UserName == "bikash" && Password == "bikash")
                    return true;
                else
                    return false;
                // return 
                //return BusinessLogic.ValidateUser(UserName, Password);
            }
            return false;
        }
        catch (Exception)
        {

            return false;
        }

    }
}