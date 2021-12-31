using CleanArchitecture.Mvc.Data;
using CleanArchitecture.Mvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc
{
    public static class ServiceExtension
    {
        public static void ConfigureDefaultIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(
                e =>
                {
                    e.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            Log.Error($"Something went wrong in the {contextFeature.Error}");
                            await context.Response.WriteAsync(new Error
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal server error. Please try again later."
                            }.ToString());

                        }
                    });
                });
        }
    }
}
