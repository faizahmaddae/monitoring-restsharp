

# Create a new C# project in VSCode
    dotnet new console -o app
    cd app
    code . # to open project in VSCode


# Run Your C# Code in VSCode
    dotnet run


# Compile Your Code
    dotnet build


# install rest client
    site https://restsharp.dev/usage.html#http-header

    dotnet add package RestSharp
   

string bearerToken = "43|ewShYfo155rIToLO5UtmVAfXdpWscSyVoXoAZr5Y";
string baseUrl = "https://api.daykundi.com/";
string endpoint = "api/client";
string accept = "application/vnd.api+json";

string name = "UN-1";