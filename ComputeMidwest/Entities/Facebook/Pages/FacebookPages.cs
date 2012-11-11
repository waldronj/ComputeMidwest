using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputeMidwest.Entities.Facebook.Pages
{
    public class FacebookPages
    {
        public class Data
        {
            public string name { get; set; }
            public string access_token { get; set; }
            public string category { get; set; }
            public string id { get; set; }
            public List<string> perms { get; set; }
        }

        public class Map
        {
        }

        public class Types
        {
        }

        public class RootObject
        {
            public string idr { get; set; }
            public string id { get; set; }
            public Data data { get; set; }
            public long at { get; set; }
            public Map map { get; set; }
            public Types types { get; set; }
        }
    }
}