﻿
internal class Program
{
    private static async Task Main(string[] args)
    {
        Provider provider = new Provider();

        // login
        string token = await provider.LoginAsync("admin@admin.com", "admin@321");
        // Console.WriteLine("Token: " + token);

        // string token = "79|ai4Aelo4JBZs9WTLi5mp6TJoxdWgdEG6oAkemTO4";

        // add client
        Client? c = await provider.AddClientAsync("UNC-041", token);
        Console.WriteLine("Client added: " + c);

        // update client
        c!.Name = "Faiz UN";
        c = await provider.UpdateClientAsync(c, token);
        Console.WriteLine("Client updated: " + c);

        // // delete client
        Boolean result = await provider.DeleteClientAsync(c!.Id, token);
        Console.WriteLine("Client deleted: " + result);



    }




}