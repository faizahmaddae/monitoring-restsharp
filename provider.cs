using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

class Provider
{

    public async Task<string> LoginAsync(string email, string password)
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
        string token;

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Request succeeded, do something with the response data
            // Console.WriteLine(response.Content);
            JObject json = JObject.Parse(response.Content!);
            // Console.WriteLine(json["data"]!["token"]);
            token = json["data"]!["token"]!.ToString();
        }
        else
        {
            // Request failed, handle the error
            Console.WriteLine("Error: " + response.ErrorMessage);
            Console.WriteLine("StatusCode: " + response.StatusCode);
            return "Error: " + response.ErrorMessage;
        }

        return token;
    }

    public async Task<Client?> AddClientAsync(string name, string bearerToken)
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

        Client? myClient = new Client();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Request succeeded, print the response content to the console
            JObject json = JObject.Parse(response.Content!);
            myClient = JsonConvert.DeserializeObject<Client>(json["data"]!["client"]!.ToString());

            // myClient.Name = json["data"]!["client"]!["name"]!.ToString();
            // myClient.Id = int.Parse(json["data"]!["client"]!["id"]!.ToString());
            // myClient.Created_at = json["data"]!["client"]!["created_at"]!.ToString();
            // myClient.updated_at = json["data"]!["client"]!["updated_at"]!.ToString();
        }
        else
        {
            // Request failed, handle the error
            Console.WriteLine("Error: " + response.ErrorMessage);
            Console.WriteLine("StatusCode: " + response.StatusCode);
            Console.WriteLine("StatusDescription: " + response.StatusDescription);
            Console.WriteLine("Content: " + response.Content);

            myClient = new Client();

        }

        return myClient;
    }

    public async Task<Boolean> DeleteClientAsync(int? id, string token)
    {
        string baseUrl = "https://api.daykundi.com/";
        string endpoint = "api/client/" + id;
        string accept = "application/vnd.api+json";

        var client = new RestClient(baseUrl);
        var request = new RestRequest(endpoint, Method.Delete);
        request.AddHeader("Accept", accept);
        request.AddHeader("Authorization", "Bearer " + token);

        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Request succeeded, print the response content to the console
            // Console.WriteLine(response.Content);
            return true;
        }
        else
        {
            // Request failed, handle the error
            Console.WriteLine("Error: " + response.ErrorMessage);
            Console.WriteLine("StatusCode: " + response.StatusCode);
            Console.WriteLine("StatusDescription: " + response.StatusDescription);
            Console.WriteLine("Content: " + response.Content);
            return false;
        }
    }


    public async Task<Client?> UpdateClientAsync(Client? myClient, string token){
        string baseUrl = "https://api.daykundi.com/";
        string endpoint = "api/client/" + myClient!.Id;
        string accept = "application/vnd.api+json";

        string jsonBody = JsonConvert.SerializeObject(new
        {
            name = myClient.Name
        });

        var client = new RestClient(baseUrl);
        var request = new RestRequest(endpoint, Method.Put);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", accept);
        request.AddHeader("Authorization", "Bearer " + token);
        request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Request succeeded, print the response content to the console
            JObject json = JObject.Parse(response.Content!);
            myClient = JsonConvert.DeserializeObject<Client>(json["data"]!["client"]!.ToString());
        }
        else
        {
            // Request failed, handle the error
            Console.WriteLine("Error: " + response.ErrorMessage);
            Console.WriteLine("StatusCode: " + response.StatusCode);
            Console.WriteLine("StatusDescription: " + response.StatusDescription);
            Console.WriteLine("Content: " + response.Content);

            myClient = new Client();

        }

        return myClient;     
    }


}