using System;
namespace WebApi.DbFactorySample.Services.DbConnectionService
{
    /// <summary>
    /// The DbConnection (model)
    /// </summary>
    public class DbConnection : IDbConnectionFactoryItem
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
