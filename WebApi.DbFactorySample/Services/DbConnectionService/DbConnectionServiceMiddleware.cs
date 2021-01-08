using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DbFactorySample.Utilities;

namespace WebApi.DbFactorySample.Services.DbConnectionService
{
    public static class DbConnectionServiceMiddleware
    {
        public static void AddDbConnectionFactory(this IServiceCollection services)
        {
            // wire up the db factory service
            // this can be a singleton since it's essentially a static list pulled from the appsettings
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

            // get access to the HttpContextAcessor 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // consume the db factory and load the correct connection on each request
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var httpRequest = httpContext.Request;
                var dbFactory = serviceProvider.GetService<IDbConnectionFactory>();
                // use the factory service to get the db connection on each request
                var connection = dbFactory.Get(httpRequest);

                if (connection != null)
                {
                    // assing the connection
                    options.UseSqlServer(connection.ConnectionString);
                    Console.WriteLine($"Connection Info: {connection.ToJson()}");
                }
                else
                {
                    //todo log / error etc
                }

            });
        }
    }
}
