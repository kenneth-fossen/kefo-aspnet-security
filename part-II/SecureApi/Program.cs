using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using SecureApi;
using SecureApi.ClaimsTransform;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IClaimsTransformation, SecuredApiTransformClaims>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string jwtBearerScheme = "Bearer";

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
   .AddMicrosoftIdentityWebApi(
        configuration:builder.Configuration,
        configSectionName: "AzureAd",
        jwtBearerScheme: jwtBearerScheme,
        subscribeToJwtBearerMiddlewareDiagnosticsEvents: true);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy.RequireClaim("tagged");
    });
    options.AddPolicy("ConsoleClientRole", policy =>
    {
        policy.RequireRole("ConsoleClientRole");
    });
    options.AddPolicy("HasFlagScope", policy =>
    {
        policy.Requirements.Add(new ScopeAuthorizationRequirement
        {
            RequiredScopesConfigurationKey = SecureApiConstants.FlagName
        });
    });
});

builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
    // Changes between mapping to XML or not,
    // recommended not to map, due to complex manner of XML,
    // and breaking the OpenID/OAuth conventional way.
    options.MapInboundClaims = true;
});

Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowCredentials();
    opt.WithOrigins("http://localhost:5173");
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization("Default");

app.Run();