using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Agnoscolib;
using System.IO;


namespace AgnoscoWS
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
                        actionPostRequest(context);
                        break;
                    case "GET":
                        actionGetRequest(context);
                        break;
                    case "PUT":
                        //UpdateNominationToDB(context);
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

       
        
        private void actionGetRequest(HttpContext context)
        {
            string result = null;
            try
            {
                string userAction = context.Request.QueryString["action"];
                int depId = Convert.ToInt32(context.Request.QueryString["depId"]);
                string status = context.Request.QueryString["status"];
                int loggedUserId = Convert.ToInt32(context.Request.QueryString["userId"]);
                Agnoscolib.Lib lib = new Lib();
                switch (userAction)
                {
                    case "Nominations":
                        result = lib.GetNominations(depId, status, loggedUserId);
                        break;
                    case "GetUser":
                        //result = lib.GetUser();
                        break;
                    case "Stats":
                        result = lib.LeaderboardStats();
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

        private void actionPostRequest(HttpContext context)
        {
            string result = null;
            try
            {
                string userAction = context.Request.QueryString["action"];
                Agnoscolib.Lib lib = new Lib();
                switch (userAction)
                {
                    case "Update":
                            string bodyDataU = null;
                            using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
                            {
                                bodyDataU = inputStream.ReadToEnd();
                            }
                            Agnoscolib.Nomination nomU = new Nomination();
                            nomU = JsonConvert.DeserializeObject<Nomination>(bodyDataU);
                            lib.UpdateNomination(nomU);
                            WriteResponce("true");
                        break;
                    case "Add":
                            string bodyDataA = null;
                            using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
                            {
                                bodyDataA = inputStream.ReadToEnd();
                            }
                            Agnoscolib.Nomination nomA = new Nomination();
                            nomA = JsonConvert.DeserializeObject<Nomination>(bodyDataA);
                            
                            lib.AddNomination(nomA);
                            WriteResponce("true");
                        break;

                    case "Thanks":
                        string bodyDataT = null;
                        using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
                        {
                            bodyDataT = inputStream.ReadToEnd();
                        }
                        Thanks thanks = new Thanks();
                        thanks = JsonConvert.DeserializeObject<Thanks>(bodyDataT);

                        lib.GiveThanks(thanks);
                        WriteResponce("true");
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