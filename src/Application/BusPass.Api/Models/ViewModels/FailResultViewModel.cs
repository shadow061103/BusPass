using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Api.Models.ViewModels
{
    public class FailResultViewModel
    {
        public string Version { get; set; }

        public string Status { get; set; }

        public string Method { get; set; }

        public int ErrorCode { get; set; }

        public string Description { get; set; }

        public string Message { get; set; }
    }
}