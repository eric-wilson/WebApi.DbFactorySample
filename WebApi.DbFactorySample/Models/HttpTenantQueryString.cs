using System;
namespace WebApi.DbFactorySample.Models
{
    public class HttpTenantQueryString
    {
        /// <summary>
        /// Tenant Id (or whatever you want it to use to find connection strings)
        /// </summary>
        public string TenantId { get; set; }
    }
}
