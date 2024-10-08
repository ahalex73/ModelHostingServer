using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ModelHostingServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services if necessary
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // Enable serving static files from wwwroot folder

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("3D Model Hosting Server");
                });

                // Endpoint to serve a model by name
                endpoints.MapGet("/models/{modelName}/", async context =>
                {
                    // Safely access the model name
                    if (context.Request.RouteValues.TryGetValue("modelName", out var modelNameObj) && modelNameObj != null)
                    {
                        //var filePath = Path.Combine("wwwroot", "models", modelName, $"{modelName}.obj");

                        var modelName = modelNameObj.ToString();
                        //var modelPath =   Path.Combine(env.ContentRootPath, "models/../", modelName);
                        var modelPath = Path.Combine("wwwroot", "models", modelName, $"{modelName}.obj");


                        // Check if the model file exists
                        if (System.IO.File.Exists(modelPath))
                        {
                            context.Response.ContentType = "application/octet-stream"; // Set content type
                            await context.Response.SendFileAsync(modelPath); // Send the model file
                        }
                        else
                        {
                            context.Response.StatusCode = 404;  // Not Found
                            await context.Response.WriteAsync($"Model '{modelName}' not found.");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 400;      // Bad Request
                        await context.Response.WriteAsync("Model name is required.");
                    }
                });
            });
        }
    }
}
