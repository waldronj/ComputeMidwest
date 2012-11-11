using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputeMidwest.Entities
{
    public class TwitterDetails
    {
        public Data data { get; set; }  
    }

    public class Data
    {
        public string name { get; set; }
        public string profile_image_url_https { get; set; }
    }
}