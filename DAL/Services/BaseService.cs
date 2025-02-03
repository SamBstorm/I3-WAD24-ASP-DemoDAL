using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public abstract class BaseService
    {
        protected readonly string _connectionString;

        public BaseService(IConfiguration config, string dbname)
        {
            _connectionString = config.GetConnectionString(dbname) ?? throw new Exception("Pas de ConnectionString correspondante.");
        }
    }
}
