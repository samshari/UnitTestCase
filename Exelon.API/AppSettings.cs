using Exelon.Domain.Common;
using Microsoft.Extensions.Configuration;
using System;

namespace Exelon.API
{
    public class AppSettings : IAppSettings
    {
        private IConfiguration _config;

        public AppSettings(IConfiguration config)
        {
            this._config = config;
        }

        public string GetConnectionString() => GetString("DefaultConnection");



        public string GetString(string key)
        {
            string result = this._config.GetValue<string>("ConnectionStrings:DefaultConnection");
            if (string.IsNullOrEmpty(result))
                throw new Exception($"Value [{key}] Not Found in appsettings.json");
            return result;
        }


    }
}
