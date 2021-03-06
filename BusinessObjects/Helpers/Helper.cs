using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.IO;
using System.Web;




public enum Action
        {
            Add,
            Edit,
            Delete,
            None
        }
namespace BusinessObjects
{
    public class OutMessage
    {

        private string _OutResultCode = string.Empty;
        public string OutResultCode
        {
            get
            {
                return this._OutResultCode;
            }
            set
            {
                this._OutResultCode = value;
            }
        }
        private string _OutResultMessage = string.Empty;
        public string OutResultMessage
        {
            get
            {
                return this._OutResultMessage;
            }
            set
            {
                this._OutResultMessage = value;
            }
        }

        public bool ExecuteSuccess { get; set; }

        private object _Result = new object();
        public object Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
            }
        }
    }

        //public enum Default
        //{
        //    Yes,
        //    No
        //}
    public class Helper 
    {
        
        public static string[] NepaliMonthList ={ "बैशाख", "जेठ", "अषाढ", "श्रवण", "भदौ", "अशोज", "कर्त्तिक", "मंसिर", "पौष", "माघ", "फागुन", "चैत" };

        public static string[] EnglishMonthList ={ };

        public static string PreviledgeMsg = "Insufficient previlege to";

       

        /// <summary>
        /// Convert file into array of byte and return byte[], return null if file doesn't exist.
        /// </summary>
        /// <param name="serverPathOfFile">Server path for file</param>
        /// <returns></returns>
        public static byte[] GetBytesFromFile(string serverPathOfFile)
        {
            if (File.Exists(serverPathOfFile) == false)
            {
                return null;
            }

            FileStream fs = new FileStream(serverPathOfFile, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            return bytes;
        }

        public static string FormatDate(DateTime DT)
        {
            char[] token ={ '/' };
            string[] array = DT.ToShortDateString().Split(token);

            return Helper.FormatCode(array[0], 2) + "/" + Helper.FormatCode(array[1], 2) + "/" + Helper.FormatCode(array[2], 4);
        }

        private static string FormatCode(string Code, int Length)
        {
            string Prefix = "00000";
            Code = Prefix + Code;
            return Code.Substring(Code.Length - Length, Length);
        }

        //public static void Show(string msg)
        //{
        //    string cleanMsg = msg.Replace("'", "\\'");
        //    string script = "alert('" + cleanMsg + "');";
        //    Page page = HttpContext.Current.CurrentHandler as Page;

            
        //    if (page != null)
        //        ScriptManager.RegisterStartupScript(page, page.GetType(), "PopupMsg", script, true);

            
            

        //}


        public static string GetNepaliValue(string engValue)
        {
            try
            { 
                string nepaliVal;

                nepaliVal = engValue.ToString();
                nepaliVal = nepaliVal.Replace("0", "०");
                nepaliVal = nepaliVal.Replace("1", "१");
                nepaliVal = nepaliVal.Replace("2", "२");
                nepaliVal = nepaliVal.Replace("3", "३");
                nepaliVal = nepaliVal.Replace("4", "४");
                nepaliVal = nepaliVal.Replace("5", "५");
                nepaliVal = nepaliVal.Replace("6", "६");
                nepaliVal = nepaliVal.Replace("7", "७");
                nepaliVal = nepaliVal.Replace("8", "८");
                nepaliVal = nepaliVal.Replace("9", "९");

                return nepaliVal;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        
    }
}
