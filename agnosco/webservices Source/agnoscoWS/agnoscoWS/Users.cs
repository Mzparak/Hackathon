using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using agnoscolib;

namespace agnoscoWS
{
    public class Users: IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

         public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request.HttpMethod)
                {
                    case "POST":
                        // GenXml(context);
                        break;
                    case "GET":
                        actionRequest(context);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception e)
            {
                WriteResponce("Error in service: IHttpHandler.ProcessRequest(HttpContext context)" + e.Message.ToString());
            }
        }

        private void actionRequest(HttpContext context)
        {
            string result = null;
            try
            {
                string userAction = context.Request.QueryString["action"];
                string userName = context.Request.QueryString["name"];
                agnoscolib.Lib lib = new Lib();
                switch (userAction)
                {
                    case "GetUsers":
                            result = lib.GetUsers();
                        break;
                    case "GetUser":
                            //result = lib.GetUser();
                        break;
                    case "ValidateUser":
                        result = lib.ValidateUser(userName);
                        break;
                    default:
                        
                        break;
                }
                WriteResponce(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private static void WriteResponce(string message)
        {
            HttpContext.Current.Response.Write(message);
        }

    }

}