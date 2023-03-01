using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await LoginAsync("admin@admin.com", "admin@321");
        await AddClientAsync("UNC-04", "60|EmJLrPFOMzRh57yXR79h1OKOgucZuEJ2QDL1HLmp");

        async Task LoginAsync(string email, string password)
        {
            string baseUrl = "https://api.daykundi.com/";
            string endpoint = "api/login";
            string accept = "application/vnd.api+json";

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Accept", accept);
            request.AddParameter("email", email);
            request.AddParameter("password", password);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Request succeeded, do something with the response data
                // Console.WriteLine(response.Content);
                JObject json = JObject.Parse(response.Content!);
                Console.WriteLine(json["data"]!["token"]);
            }
            else
            {
                // Request failed, handle the error
                Console.WriteLine("Error: " + response.ErrorMessage);
            }
        }

        async Task AddClientAsync(string name, string bearerToken)
        {
            string baseUrl = "https://api.daykundi.com/";
            string endpoint = "api/client";
            string accept = "application/vnd.api+json";

            string jsonBody = JsonConvert.SerializeObject(new
            {
                name
            });

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", accept);
            request.AddHeader("Authorization", "Bearer " + bearerToken);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Request succeeded, print the response content to the console
                Console.WriteLine(response.Content);
            }
            else
            {
                // Request failed, handle the error
                Console.WriteLine("Error: " + response.ErrorMessage);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                Console.WriteLine("StatusDescription: " + response.StatusDescription);
                Console.WriteLine("Content: " + response.Content);

            }
        }

    }




}