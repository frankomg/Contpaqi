using RestSharp;

namespace Models
{
    public class API
    {
        public string consumir(APIModel obj)
        {
            var client = new RestClient(obj.URL_base + obj.Route);
            client.Timeout = -1;
            var request = new RestRequest(obj.MethodAPI);
            request.AddHeader("Content-Type", "application/json");
            var body = obj.Body;

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string jsonString = response.Content;

            return jsonString;
        }
    }

    public class APIModel
    {
        public string URL_base { get; set; }
        public string Route { get; set; }
        public string Parameters { get; set; }
        public RestSharp.Method MethodAPI { get; set; }
        public string Body { get; set; }
    }
}
