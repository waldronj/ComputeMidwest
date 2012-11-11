using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputeMidwest.Entities
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public object refresh_token { get; set; }
        public string account { get; set; }
    }
}