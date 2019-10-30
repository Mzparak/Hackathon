using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using agnoscolib;
using System.IO;

namespace agnoscoWS
{
    public class Nominations: IHttpHandler
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
                         AddNominationToDB(context);
                        break;
                    case "GET":
                       // GetUsersfromDb(context);
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

        private void AddNominationToDB(HttpContext context)
        {
            try
            {
                string bodyData = null;
                using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
                {
                    bodyData = inputStream.ReadToEnd();
                }
                agnoscolib.Nomination nom = new Nomination();
                nom = JsonConvert.DeserializeObject<Nomination>(bodyData);
                Lib lib = new Lib();
                lib.AddNomination(nom);
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