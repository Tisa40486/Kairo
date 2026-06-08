using System.Text;
using KairoApi.Business;
using KairoApi.Business.Task.Query;
using KairoApi.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KairoApi.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>{
            options.AddPolicy("AllowSwagger", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        builder.Services.RegisterKairoApiDbContainer();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTaskByIdQuery).Assembly));
        builder.Services.AddAutoMapper(cfg => { }, typeof(KairoApiProfile).Assembly);
        builder.Services.AddControllers();
        builder.Services.AppKairoApiContext(builder.Configuration);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                    )
                };
            });
        builder.Services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api Test",
                Version = "v1"
            });
    
            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:3000",
                Description = "Docker"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Entre: Bearer {token}"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        builder.Services.AddScoped<TokenService>();


        var app = builder.Build();

        app.UseHttpsRedirection();
            
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Kairo v1");
            c.RoutePrefix = "swagger";
        });
        app.UseCors("AllowSwagger");
        app.UseAuthentication(); 
        app.UseAuthorization();
        app.MapControllers();
        app.MapGet("/health", () => Results.Ok(new { ok = true, dotnet = Environment.Version.ToString() }));
        app.Run();
    }
}