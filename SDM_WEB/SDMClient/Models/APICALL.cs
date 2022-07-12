using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http.Headers;

namespace SDMClient.Models
{
    public class APICALL
    {

        private readonly IConfiguration Configuration;
        public APICALL(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string PostApi(string Routevalue, dynamic Listvalues)
        {

            HttpClient client = new HttpClient();
            string ApiUrl = Configuration["MySettings:ApiUrl"];
            string dataString = "";
            try { client.BaseAddress = new Uri(ApiUrl); }
            catch
            {
                return "Api URL Return Error. Please contact our team";
            }
            ArrayList paramList = new ArrayList();
            paramList.Add(Listvalues);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            HttpResponseMessage Response = client.PostAsJsonAsync("api/" + Routevalue, paramList[0]).Result;
            if (Response.IsSuccessStatusCode)
            {
                HttpContent stream = Response.Content;
                var data = stream.ReadAsStringAsync();
                dataString = data.Result.ToString();
                //dataString = dataString.Replace("null", "-");

                //dataString = JsonConvert.DeserializeObject<dynamic>(dataString);
                return dataString;
            }
            else
            {
                HttpContent stream = Response.Content;
                var data = stream.ReadAsStringAsync();
                dataString = data.Result.ToString();
                //dataString = "Api Return Error. Please contact our team";
                return dataString; ;
            }
        }
        public string GetApi(string Routevalue, dynamic Listvalues)
        {

            HttpClient client = new HttpClient();
            string ApiUrl = Configuration["MySettings:ApiUrl"];
            string dataString = "";
            try { client.BaseAddress = new Uri(ApiUrl); }
            catch
            {
                return "Api URL Return Error. Please contact our team";
            }
            ArrayList paramList = new ArrayList();
            paramList.Add(Listvalues);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            HttpResponseMessage Response = client.GetAsync("api/" + Routevalue).Result;
            if (Response.IsSuccessStatusCode)
            {
                HttpContent stream = Response.Content;
                var data = stream.ReadAsStringAsync();
                dataString = data.Result.ToString();
                //dataString = dataString.Replace("null", "-");

                //dataString = JsonConvert.DeserializeObject<dynamic>(dataString);
                return dataString;
            }
            else
            {
                HttpContent stream = Response.Content;
                var data = stream.ReadAsStringAsync();
                dataString = data.Result.ToString();
                dataString = "Api Return Error. Please contact our team";
                return dataString; ;
            }
        }
    }
}
