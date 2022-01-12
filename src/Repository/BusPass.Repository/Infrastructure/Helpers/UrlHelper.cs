using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Infrastructure.Helpers
{
    public class UrlHelper : IUrlHelper
    {
        private readonly IConfiguration _configuration;

        public UrlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}