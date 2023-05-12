using LotometroPortal.Models;
using LotometroPortal.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static LotometroPortal.Libraries.WebLibrary.WebServicesManager;

namespace LotometroPortal.Entities
{
    public static class ApiHelperClass
    {
        public static AuthViewModel LoginIntoApi(LoginInputViewModel loginInput)
        {
            HttpResponseMessage response = HttpClientResponse(TipoComando.tcPOST,
                UriPathsAndConsts.apiRoute,
                "users/",
                "authenticate",
                loginInput,
                true,
                string.Empty,
                60);

            string content = GetContentAsString(response);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AuthViewModel>(content);
            else
                throw new Exception(content);
        }

        public static LeituraCamera GetCameraInfo(int location, int camera)
        {
            HttpResponseMessage response = HttpClientResponse(TipoComando.tcGET,
                UriPathsAndConsts.apiRoute,
                "camera/",
                $"getLastByIdLocationAndIdCamera/{location}/{camera}",
                string.Empty,
                true,
                EntitiesHelperClass.GetAuthObj().Token,
                60);

            string content = GetContentAsString(response);
            Console.WriteLine(response.StatusCode + " content: " + content);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<LeituraCamera>>(content).First();
            else
                return null;
        }
    }
}
