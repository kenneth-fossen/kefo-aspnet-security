# Part-I - Readme

In this set of exercises, we will be looking at IdentityServer, Authentication, and Authorization with a Commandline client.
We will follow Duende's Quickstart Guides for up to 4 experiences to familiarise ourselves with ASP.NET WebAPI Security is working.

I've prepared the skeleton code for you to start with the project.
All the necessary packages have been added to their respective projects so skip these steps in the guides.

## IdentityServer

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

## Api

Should be listening to `https://localhost:6001/swagger/index.html`
You should see the `WeatherForecastController` endpoints.

## Client

Empty client for Task 1, goal is to implement this and experiment with it

## WebClient

Empty client for Task 2, the goal is to implement this and experiment with it.

# TIPS

If you get an error connecting it may be that you are running HTTPS and the development certificate for localhost is not trusted. 
You can run `dotnet dev-certs https --trust` `in order to trust the development certificate. 
Only do this once.

# TASK 1

[LogIn with ClientCredentials](https://docs.duendesoftware.com/identityserver/v6/quickstarts/1_client_credentials/)

# TASK 2

[Interactive Applications with ASP.NET Core](https://docs.duendesoftware.com/identityserver/v6/quickstarts/2_interactive/)

Note: There is no need to do the task `Add Support` for External Authentication`, but feel free to do it if you want. Requires a Google Account.

# TASK 3

[ASP.NET Core and API access](https://docs.duendesoftware.com/identityserver/v6/quickstarts/3_api_access/)

