using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agnoscolib;
using System.Net;
using System.Net.Http;

namespace TestAgnoscoLib
{
    class Program
    {
        private const string URLGetUser = "http://localhost/AWS/getUsers?AWS/getUsers?";
        private const string URLAddNom = "http://localhost/AWS/Nominations";
        private const string addNomData = @"{""Nominator"":2,""Nominee"":3,""NominationInfo"":"",""Points"":100}";
        static void Main(string[] args)
        {
            // testRestCallGetUser();
            // testGenNomination();
            // testRestCallAddNom();
            testValidateUser();

        }
        private static void testRestCallGetUser()
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URLGetUser);
            byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //System.Net.Http.HttpContent content = new StringContent("",UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(URLGetUser).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }
        }
        private static void testRestCallAddNom()
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URLAddNom);
            byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(addNomData, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(URLAddNom, content).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }

        }

        
        private static void testValidateUser()
        {
            Lib lib = new Lib();
            string result = lib.ValidateUser("mparak");

        }

        private static void testGenNomination()
        {
            Lib lib = new Lib();
            string result = lib.genNominationJson();

        }



    }
}
