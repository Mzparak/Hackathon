using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EkunduConfig.WS
{
    public class BLL: IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
               get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request.HttpMethod)
                {
                    case "POST":
                        GenXml(context);
                        break;
                    case "GET":
                        GetRisk(context);
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

        private void GetRisk(HttpContext context)
        {
            string result = null;
            try
            {
                string code = context.Request.QueryString["code"];
                string filter = context.Request.QueryString["filter"];
                EkunduConfig.Lib ekl = new Lib();
                result = ekl.GetRisk(code,filter);
                WriteResponce(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void GenXml(HttpContext context)
        {
            try
            {
                string bodyData = null;
                using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
                {
                    bodyData = inputStream.ReadToEnd();
                }
                EkunduConfig.Lib ekl = new Lib();
                ekl.GenerateXml(bodyData);
                WriteResponce("true");
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
