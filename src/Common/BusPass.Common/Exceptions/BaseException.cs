using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Common.Exceptions
{
    [DataContract]
    public class BaseException : Exception
    {
        [DataMember]
        public int Code { get; }

        [DataMember]
        public override string Message { get; }

        [DataMember]
        public string Description { get; }

        public BaseException(int code, string message, string description)
        {
            this.Code = code;
            this.Message = message;
            this.Description = description;
        }
    }
}