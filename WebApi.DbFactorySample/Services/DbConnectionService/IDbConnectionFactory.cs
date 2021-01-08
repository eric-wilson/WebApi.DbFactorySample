using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApi.DbFactorySample.Services.DbConnectionService
{
    public interface IDbConnectionFactory
    {
        IList<DbConnection> Get();
        DbConnection Get(string id);
        DbConnection Get(HttpRequest httpRequest);
    }
}
