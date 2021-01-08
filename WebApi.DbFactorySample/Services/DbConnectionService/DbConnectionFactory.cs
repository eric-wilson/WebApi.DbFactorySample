using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.DbFactorySample.Models;
using WebApi.DbFactorySample.Utilities;

namespace WebApi.DbFactorySample.Services.DbConnectionService
{
    /// <summary>
    /// The DbConnectionFactory
    /// Purpose: Loads the configuraitons into memory from the appsettings
    /// </summary>
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private IList<DbConnection> _connections;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            Initialize();
        }

        /// <summary>
        /// Load all the connection strings into a list object.
        /// </summary>
        private void Initialize()
        {
            // load the connections
            _connections = _configuration.GetSection("DbConnections").Get<List<DbConnection>>();        
            
        }

        /// <summary>
        /// Get the DbConnection by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DbConnection Get(string id)
        {
            var connnecion = _connections.FirstOrDefault(c => c.Id == id);

            return connnecion;
        }

        /// <summary>
        /// Get the DbConnection based on a request.
        /// Currentnly uses a querystring to get which database, you could change this to headers or other means
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public DbConnection Get(HttpRequest httpRequest)
        {
            // get id from request.
            var model = httpRequest.QueryString.Value.ToModelFromQueryString<HttpTenantQueryString>();
            var connnecion = _connections.FirstOrDefault(c => c.Id == model.TenantId);

            return connnecion;
        }

        /// <summary>
        /// Returns a list of DbConnections.
        /// </summary>
        /// <returns></returns>
        public IList<DbConnection> Get()
        {            
            return _connections;
        }
    }

    
}
