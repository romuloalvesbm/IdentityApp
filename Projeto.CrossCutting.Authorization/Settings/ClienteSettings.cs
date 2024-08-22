using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.CrossCutting.Authorization.Settings
{
    public class ClienteSettings
    {      
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }

    public class ApiSettings
    {
        public string? XApiVersion { get; set; }
        public List<ClienteSettings>? Clients { get; set; }
    }
}
