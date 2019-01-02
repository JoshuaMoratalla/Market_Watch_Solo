using System;
using System.Collections.Generic;
using System.Text;
using Market_Watch_Solo.Model;
using System.Net;
using Newtonsoft.Json;
using SimpleJson;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace Market_Watch_Solo.Action
{
    class Login_Check
    { 
        public User UserResult { get; set; }
        public string Input_Username { get; set; }
        public string Input_Password { get; set; }
        public bool Validated { get; set; }
        public string URL { get; set; }

        public Login_Check(string inEmail, string inPass)
        {
            Input_Username = inEmail;
            Input_Password = inPass;
            Validated = false;

            string uri = "/username/" + Input_Username;
            string uriclient = "{Your own directory/domain}";
            URL = uriclient + uri;
            var client = new RestClient(uriclient);
            var request = new RestRequest(uri, Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Validated = true;
                string rawResponse = response.Content;
                string buffer = JsonConvert.DeserializeObject<User>(response.Content).ToString();
                UserResult = JsonConvert.DeserializeObject<User>(response.Content);
            }



        }
    }
}
