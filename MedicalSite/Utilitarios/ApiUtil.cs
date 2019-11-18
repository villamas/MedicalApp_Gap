using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MedicalSite.Utilitarios
{
    public class ApiUtil<T>
    {
       public object SeguridadApi(Object model,string Apiurl,string Token )
        {
            string baseUrl = "https://localhost:5001";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer",
       Token);

            HttpResponseMessage response = client.GetAsync
        (Apiurl).Result;
            string stringData = response.Content.
        ReadAsStringAsync().Result;
            T data = JsonConvert.DeserializeObject
        <T>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)       
                return null;          
            else
            return data;
        }

        public object SeguridadApiPost(Object model, string Apiurl, string Token)
        {
            string baseUrl = "https://localhost:5001";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer",
       Token);
         
            string stringData = JsonConvert.SerializeObject(model);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync
     (Apiurl,contentData).Result;

            string stringData2= response.Content.ReadAsStringAsync().Result;
            //    string stringData = response.Content.
            //ReadAsStringAsync().Result;
            T data = JsonConvert.DeserializeObject
        <T>(stringData2);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;
            else
                return data;
        }

       
    }
}
