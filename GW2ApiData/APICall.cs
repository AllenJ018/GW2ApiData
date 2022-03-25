using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Diagnostics;



namespace GW2ApiData
{

    public class UserKeyData
    {
        private string key = "FD6AE079-B9E3-F24D-B612-E136FDD5B1E2BE134C44-5140-430D-BEEA-A1FC7E91FE9E";
        private string baseAddress = "https://api.guildwars2.com";
        private string accountAccessor = "/v2/account?access_token=";

        public UserKeyData() { }
        public UserKeyData(string key)
        {
            this.key = key;
        }

        public void setKey(string key)
        {
            if (key != null)
                this.key = key;
            else
                Debug.WriteLine("Key is null");
        }

        public void setBaseAddress(string baseAddress)
        {
            if (baseAddress != null)
                this.baseAddress = baseAddress;
            else
                Debug.WriteLine("baseAddress is null");
        }
        public string getKey => key;
        public string getBaseAddress => baseAddress;
        public string getAccountAccessor => accountAccessor;

    }

    public class UserData
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int world { get; set; }
        public string[] guilds { get; set; }
        public string[] guild_leader { get; set; }
        public string created { get; set; }
        public string[] access { get; set; }
        public bool commander { get; set; }
        public int fractal_level { get; set; }
        public int daily_ap { get; set; }
        public int monthly_ap { get; set; }
        public int wvw_rank { get; set; }
    }
}
