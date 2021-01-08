using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.DbFactorySample.Services.DbConnectionService;

namespace WebApi.DbFactorySample.Controllers
{
    /// <summary>
    /// Sample Controller to demonstrate loading an appDbContext tied to a dynamic db connection
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DbConnectionFactoryController : ControllerBase
    {
                

        

        private readonly ILogger<DbConnectionFactoryController> _logger;        
        private readonly AppDbContext _appDbContext;
       

        public DbConnectionFactoryController(ILogger<DbConnectionFactoryController> logger, AppDbContext appDbContext)
        {
            _logger = logger;            
            _appDbContext = appDbContext;            
        }
       

        [HttpGet]
        public string Get()
        {
            try
            {
                var currentDB = _appDbContext.Database.GetDbConnection().ConnectionString;
                var results = $"This call would use: {currentDB}";


                return results;


            }
            catch
            {
                return "Database Connection is not set.  Use the ?tennatid=nnn in the query string to select the correct db connection.";
            }
        }
    }
}
