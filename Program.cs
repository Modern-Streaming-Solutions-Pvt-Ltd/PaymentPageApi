using PlanPaymentPage.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PlanPaymentPage.Contracts;
using PlanPaymentPage.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ----------------- Services -----------------

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpContext Accessor
builder.Services.AddHttpContextAccessor();

// Repository
builder.Services.AddScoped<IPlanOfferRepository, PlanOfferRepository>();

// JWT Authentication
var secretKey = builder.Configuration.GetSection("JwtSecretKey").Value;
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ----------------- Middleware Pipeline -----------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Enable CORS before authentication/authorization
app.UseCors("AllowAll");

// ✅ Authentication (JWT)
app.UseAuthentication();

// ✅ Custom API Key Middleware
app.UseMiddleware<ApiKeyMiddleware>();

// ✅ Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
