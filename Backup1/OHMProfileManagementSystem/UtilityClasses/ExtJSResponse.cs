using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Text;
using System.Web.Configuration;
using System.Reflection;


namespace MicrofinanceBusinessSuite.Utility
{
    public class ExtJSResponse
    {

        public ExtJSResponse()
        {

        }
        public ExtJSResponse(string rootProp, string successProp, string messageProp, string totalProp, string msg, string successful)
        {
            if (!string.IsNullOrEmpty(rootProp))
            {
                this.RootProperty = rootProp;
            }
            if (!string.IsNullOrEmpty(successProp))
            {
                this.SuccessProperty = successProp;
            }
            if (!string.IsNullOrEmpty(messageProp))
            {
                this.MessageProperty = messageProp;
            }
            if (!string.IsNullOrEmpty(totalProp))
            {
                this.TotalProperty = totalProp;
            }
            if (!string.IsNullOrEmpty(msg))
            {
                this.Message = msg;
            }
            this.Success = successful;


        }

        private string _Success = "true";
        public string Success
        {
            get { return _Success; }
            set { _Success = value; }
        }

        public object Offices { get; set; }


        private string _RootProperty = "root";
        public string RootProperty
        {
            get { return _RootProperty; }
            set { _RootProperty = value; }
        }

        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }


        private string _SuccessProperty = "success";
        public string SuccessProperty
        {
            get { return _SuccessProperty; }
            set { _SuccessProperty = value; }
        }

        private string _MessageProperty = "message";
        public string MessageProperty
        {
            get { return _MessageProperty; }
            set { _MessageProperty = value; }
        }

        private string _TotalProperty = "total";
        public string TotalProperty
        {
            get { return _TotalProperty; }
            set { _TotalProperty = value; }
        }

        private int? _Total;
        public int? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private object _Obj;
        public object Obj
        {
            get { return _Obj; }
            set { _Obj = value; }
        }

        private object _MenuObj;
        public object MenuObj
        {
            get { return _MenuObj; }
            set { _MenuObj = value; }
        }
        public string GetResponse(object obj, int? total)
        {

            if (obj!=null)
            {
                Total = total != null ? total : 1;
            }           


            StringBuilder response = new StringBuilder();

            response.Append("{");
            response.Append(RootProperty + ":");
            response.Append(obj == null ? "''" : Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            response.Append(",");
            response.Append(MessageProperty + ":'" + Message + "',");
            response.Append(SuccessProperty + ":'" + Success + "'");
            response.Append(",");
            response.Append(TotalProperty + ":'" + Total + "'");
            response.Append("}");

            return response.ToString();
        }
        //public  string GetResponse(object obj,int? total)
        //{

        //    Total = total != null ? total : 1;


        //    StringBuilder response = new StringBuilder();                  

        //    response.Append("{");
        //    response.Append("'" + RootProperty + "':");
        //    response.Append(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        //    response.Append(",");
        //    response.Append("'" + MessageProperty + "':'" + Message + "',");
        //    response.Append("'" + SuccessProperty + "':'" + Success + "'");
        //    response.Append(",");
        //    response.Append("'" + TotalProperty + "':'" + Total + "'");
        //    response.Append("}");

        //    return response.ToString();
        //}

        public static T Factory<T>() where T : new()
        {
            return new T();
        }
        
        
        //Method added by info developer
        public string convertMessage(string message)
        {
            message = message.Replace("\"", "");
            message = message.Replace("\"", "").Replace("'", "").Replace("\r", "").Replace("\n", "");
            //message= Newtonsoft.Json.JsonConvert.SerializeObject(message);
            return message;
        }
    }
}
