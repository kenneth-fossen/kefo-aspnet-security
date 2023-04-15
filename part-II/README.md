# Part ii - Readme

In this Solution, you will find two clients and a "Secured" Api.

The secured API is running also in Azure on the following address:
`https://kefo-securedapi.azurewebsites.net`

But I have provided you with the source code so you can write
a client that speaks to the Secured API Endpoints.

## Challenges

### Client Project

You will be using `Azure.Identity` to configure and implement the client.
Your goals are to successfully request data from these endpoints.

Tips: start by investigating `appsettings.json`.

1. Write a client that can access the WeatherForecast
2. Write a client that can access the TaggedController

### WebClient - Vue

Your task is to fetch the Flag/Secret value and get it to show in the WebClient.
The secret flag is only on `https://kefo-securedapi.azurewebsites.net`,
but it is a good idea to test and work with the solution to make it work locally.

```sh
cd WebClient
npm install
npm run dev
open "http://localhost:5173"
```

I've put up a skeleton for 'authService.js' and this is the 
one that you need to configure and implement.

1. You need to find the correct Azure Tenant Ids
2. Need to request the correct Scopes

The library you are using is MSAL.js
Good starting place could be: https://github.com/AzureAD/microsoft-authentication-library-for-js/wiki/Samples

user: <username>
password: <password>

## Open Tasks

[Microsoft Identity Platform Code samples](https://learn.microsoft.com/en-us/azure/active-directory/develop/sample-v2-code)

## Sources

This Challenge is set up according to:
[https://github.com/Azure-Samples/active-directory-dotnetcore-daemon-v2/tree/master/2-Call-OwnApi](https://github.com/Azure-Samples/active-directory-dotnetcore-daemon-v2/tree/master/2-Call-OwnApi)
You can use this guide to create your own Azure Tenant and configure things in Azure to test it.
