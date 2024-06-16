using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL
{
    public class Class1
    {
        public class BackgroundChecks
        {
            public Name name { get; set; }
            public string dob { get; set; }
            public string ongoing { get; set; }
            public List<string> filters { get; set; }


        }

        public class Name
        {
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
        }

        public class MyData
        {
            public string reference { get; set; }
            public string email { get; set; }
            public string country { get; set; }
            public string language { get; set; }
            public BackgroundChecks background_checks { get; set; }
        }

        public class KycReq
        {
            public string reference { get; set; }
            public string email { get; set; }
            public string country { get; set; }
            public string language { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public string dob { get; set; }
        }

        public class VerificationResponse
        {
            public string reference { get; set; }
            public string @event { get; set; } // "event" is a reserved keyword, so "@" is used to escape it
            public string email { get; set; }
            public string country { get; set; }
            public string declined_reason { get; set; }
            public VerificationData verification_data { get; set; }
            public VerificationResult verification_result { get; set; }
            public Info info { get; set; }
        }

        public class VerificationData
        {
            public BackgroundChecks background_checks { get; set; }
        }

        //public class BackgroundChecks
        //{
        //    public string dob { get; set; }
        //    public Name name { get; set; }
        //}

        //public class Name
        //{
        //    public string first_name { get; set; }
        //    public string middle_name { get; set; }
        //    public string last_name { get; set; }
        //}

        public class VerificationResult
        {
            public int background_checks { get; set; }
        }

        public class Info
        {
            public Agent agent { get; set; }
            public Geolocation geolocation { get; set; }
        }

        public class Agent
        {
            public bool is_desktop { get; set; }
            public bool is_phone { get; set; }
            public string useragent { get; set; }
            public string device_name { get; set; }
            public string browser_name { get; set; }
            public string platform_name { get; set; }
        }

        public class Geolocation
        {
            public string host { get; set; }
            public string ip { get; set; }
            public string rdns { get; set; }
            public string asn { get; set; }
            public string isp { get; set; }
            public string country_name { get; set; }
            public string country_code { get; set; }
            public string region_name { get; set; }
            public string region_code { get; set; }
            public string city { get; set; }
            public string postal_code { get; set; }
            public string continent_name { get; set; }
            public string continent_code { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string metro_code { get; set; }
            public string timezone { get; set; }
            public string ip_type { get; set; }
            public string capital { get; set; }
            public string currency { get; set; }
        }
    }
}
