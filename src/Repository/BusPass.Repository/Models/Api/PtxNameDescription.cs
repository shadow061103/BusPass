using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class PtxNameDescription
    {
        /// <summary>
        /// 中文名
        /// </summary>
        [JsonPropertyName("Zh_tw")]
        public string Zh_tw { get; set; }
    }
}