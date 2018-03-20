<%@ WebHandler Language="C#" Class="LoadUsers" %>

using System;
using System.Web;
using System.Collections.Generic;

using ASPNETWebApplication.Controllers;
using ASPNETWebApplication.ActionServiceReference;
using Newtonsoft.Json.Serialization;

public class LoadUsers : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "json";

        TameliTypeController controller = new TameliTypeController();
        IList<TameliType> lst = controller.GetTameliType();

      //  List<TameliType> lst1 = lst as List<TameliType>;
        var v = Newtonsoft.Json.JsonConvert.SerializeObject(lst);// JSONExtension.ToJSON(lst);
    
       // string op =  JSONExtension.ToJSON(lst) ;
        context.Response.Write(v);
   //  context. Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}