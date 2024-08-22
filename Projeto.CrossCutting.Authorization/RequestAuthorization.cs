using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Projeto.CrossCutting.Authorization.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.CrossCutting.Authorization
{
    public class RequestAuthorization
    {
        private readonly ApiSettings _apiSettings;

        public RequestAuthorization(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public string? ValidationProcess(HttpContext context) 
        {
            string? message = null;

            var apiVersion = context.Request.Headers["X-ApiVersion"].ToString();
            var clientId = context.Request.Headers["client_id"].ToString();
            var clientSecret = context.Request.Headers["client_secret"].ToString();

            if (apiVersion != _apiSettings.XApiVersion)
            {
                message = "BadRequest";
            }
            else
            {
                if (_apiSettings.Clients != null && !_apiSettings.Clients
                    .Exists(c => c.ClientId == clientId && c.ClientSecret == clientSecret))
                {
                    message = "Unauthorized";
                }
            }

            return message;
        }
    }
}
