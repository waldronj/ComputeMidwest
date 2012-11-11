using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputeMidwest.Entities.Facebook
{
    public class Language
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class School
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Year
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class With
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Education
    {
        public School school { get; set; }
        public Year year { get; set; }
        public string type { get; set; }
        public List<With> with { get; set; }
    }

    public class Hometown
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FavoriteAthlete
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FavoriteTeam
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class VideoUploadLimits
    {
        public int length { get; set; }
        public int size { get; set; }
    }

    public class Employer
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Location2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Position
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Work
    {
        public Employer employer { get; set; }
        public Location2 location { get; set; }
        public Position position { get; set; }
        public string start_date { get; set; }
        public string description { get; set; }
        public string end_date { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public List<Language> languages { get; set; }
        public string link { get; set; }
        public string username { get; set; }
        public string third_party_id { get; set; }
        public int timezone { get; set; }
        public string updated_time { get; set; }
        public bool verified { get; set; }
        public string bio { get; set; }
        public string birthday { get; set; }
        public List<Education> education { get; set; }
        public string email { get; set; }
        public Hometown hometown { get; set; }
        public List<string> interested_in { get; set; }
        public Location location { get; set; }
        public string political { get; set; }
        public List<FavoriteAthlete> favorite_athletes { get; set; }
        public List<FavoriteTeam> favorite_teams { get; set; }
        public string quotes { get; set; }
        public string religion { get; set; }
        public VideoUploadLimits video_upload_limits { get; set; }
        public string website { get; set; }
        public List<Work> work { get; set; }
    }

    public class Types
    {
        public string contact { get; set; }
    }

    public class Oembed
    {
        public string type { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnail_url { get; set; }
        public string provider_name { get; set; }
    }

    public class Map
    {
        public string photo { get; set; }
        public string gender { get; set; }
        public string nickname { get; set; }
        public Oembed oembed { get; set; }
        public string text { get; set; }
    }

    public class RootObject
    {
        public string idr { get; set; }
        public string id { get; set; }
        public Data data { get; set; }
        public long at { get; set; }
        public Types types { get; set; }
        public Map map { get; set; }
    }

    public class HunterInfo
    {
        public string name { get; set; }
        public string thumbnail_url { get; set; }
        public string idr { get; set; }

    }
}