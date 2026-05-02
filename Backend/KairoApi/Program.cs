using KairoApi.Business;
using KairoApi.Business.Task.Query;
using KairoApi.Db;
using Microsoft.OpenApi.Models;

namespace KairoApi.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSwagger", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            builder.Services.RegisterKairoApiDbContainer();
            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetTaskByIdQuery).Assembly));
            builder.Services.AddAutoMapper(cfg => { }, typeof(KairoApiProfile).Assembly); 
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AppKairoApiContext(builder.Configuration);

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Test",
                    Version = "v1"
                });

                c.AddServer(new OpenApiServer
                {
                    Url = "https://localhost:7171",
                    Description = "Local dev server"
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Kairo v1");
                    c.RoutePrefix = "swagger";
                });
            }
            app.UseCors("AllowSwagger");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/health", () => Results.Ok(new { ok = true, dotnet = Environment.Version.ToString() }));
            app.Run();
        }
    }
}