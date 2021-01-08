using System;
namespace WebApi.DbFactorySample.Services.DbConnectionService
{
    public interface IDbConnectionFactoryItem
    {
        string ConnectionString { get; set; }
        string Name { get; set; }
        string Id { get; set; }
    }
}
