# KEFO ASP.NET Security Workshop

Kenneth Fossen

## Presentation

[Presentation](presentation)

## Part i

[Project Files for Part i](part-i)

## Part-I - Readme

In this set of exercises, we will be looking at IdentityServer, Authentication, and Authorization with a Commandline client.
We will follow Duende's Quickstart Guides for up to 4 experiences to familiarise ourselves with ASP.NET WebAPI Security is working.

I've prepared the skeleton code for you to start with the project.
All the necessary packages have been added to their respective projects so skip these steps in the guides. 

### IdentityServer

This server is hosting all the Identities, Scopes, access groups, and so forth. 
It should respond to a regular HTTPS request to the following address for it to be working.
`https://localhost:5001/.well-known/openid-configuration`

Note: the first time you query this address, it is slow due to it having to generate all the keys.

Use your browser or just run one of these commands:

```sh
# classic
curl -k https://localhost:5001/.well-known/openid-configuration
```

```sh
# pretty format
curl -k https://localhost:5001/.well-known/openid-configuration | jq
```

### Api

Should be listening to `https://localhost:6001/swagger/index.html`
You should see the `WeatherForecastController` endpoints.

### Client

Empty client for Task 1, goal is to implement this and experiment with it

### WebClient

Empty client for Task 2, the goal is to implement this and experiment with it.

## TIPS

If you get an error connecting it may be that you are running HTTPS and the development certificate for localhost is not trusted. 
You can run `dotnet dev-certs https --trust` `in order to trust the development certificate. 
Only do this once.

## TASK 1

[LogIn with ClientCredentials](https://docs.duendesoftware.com/identityserver/v6/quickstarts/1_client_credentials/)

## TASK 2

[Interactive Applications with ASP.NET Core](https://docs.duendesoftware.com/identityserver/v6/quickstarts/2_interactive/)

Note: There is no need to do task `Add Support for External Authentication`, but feel free to do it if you want. Requires a Google Account.

## TASK 3

[ASP.NET Core and API access](https://docs.duendesoftware.com/identityserver/v6/quickstarts/3_api_access/)

## Part ii

[Project Files for Part ii](part-ii)

## Part ii - Readme

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

## Links / Resources

[JWT.io](https://jwt.io/)

[https://learn.microsoft.com/en-us/azure/active-directory/develop/scenario-protected-web-api-app-configuration](https://learn.microsoft.com/en-us/azure/active-directory/develop/scenario-protected-web-api-app-configuration)

[https://github.com/azure-samples/active-directory-dotnet-webapi-manual-jwt-validation](https://github.com/azure-samples/active-directory-dotnet-webapi-manual-jwt-validation)

[https://learn.microsoft.com/en-us/azure/active-directory/develop/sample-v2-code](https://learn.microsoft.com/en-us/azure/active-directory/develop/sample-v2-code)

[OAuth 2.0 implicit grant flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-implicit-grant-flow)

[Microsoft identity platform and OAuth 2.0 authorization code flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow)

[ASP.NET Core Middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0#middleware-order)

[Azure.Identity Nuget](https://www.nuget.org/packages/Azure.Identity)

[Microsoft Identity Platform Documentation](https://learn.microsoft.com/en-us/azure/active-directory/develop/)

[MsC: Capability Bases Access Control](https://github.com/spydx/capability-poc)

