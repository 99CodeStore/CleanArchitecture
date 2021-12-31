using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc.Models
{
    public class Error
    {
        public int StatusCode;
        public string Message;
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
