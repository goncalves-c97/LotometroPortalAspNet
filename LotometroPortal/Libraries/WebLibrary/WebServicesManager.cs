using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LotometroPortal.Libraries.WebLibrary
{
    public class WebServicesManager
    {
        public enum TipoComando { tcGET, tcPOST, tcPUT, tcDELETE };
        /// <summary>
        /// Realiza requisições Web, Get, Post, Put
        /// </summary>
        /// <returns></returns>
        public static HttpResponseMessage HttpClientResponse(TipoComando tipo, string uri, string controller, string paramValues, object postObject, bool comSSL, string token, int RequestTimeout)
        {
            string json = JsonConvert.SerializeObject(postObject);

            if (comSSL == true)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            HttpClient client = new HttpClient(clientHandler) { Timeout = TimeSpan.FromSeconds(RequestTimeout) };
            client.BaseAddress = new Uri(uri);
            if (token != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            }
            else
            {
                client.DefaultRequestHeaders.Accept.Clear();

            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> task;

            switch (tipo)
            {
                case TipoComando.tcGET: task = Task.Run(() => client.GetAsync(controller + paramValues)); break;
                case TipoComando.tcPOST: task = Task.Run(() => client.PostAsync(controller + paramValues, new StringContent(json, Encoding.UTF8, "application/json"))); break;
                case TipoComando.tcPUT: task = Task.Run(() => client.PutAsync(controller + paramValues, new StringContent(json, Encoding.UTF8, "application/json"))); break;
                case TipoComando.tcDELETE: task = Task.Run(() => client.DeleteAsync(controller + paramValues)); break;
                default: task = Task.Run(() => client.GetAsync(uri)); break;
            }


            task.Wait();
            return task.Result;
        }

        public static string GetContentAsString(HttpResponseMessage resp)
        {
            var t = Task.Run(() => resp.Content.ReadAsStringAsync());
            t.Wait();
            return t.Result;
        }
    }
}
