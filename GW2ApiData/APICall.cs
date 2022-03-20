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



namespace GW2ApiData
{

    public class userKeyData
    {
        private string key;
        // = "FD6AE079-B9E3-F24D-B612-E136FDD5B1E2BE134C44-5140-430D-BEEA-A1FC7E91FE9E";
        //string callToAPI = "api.guildwars2.com/v2/account?access_token=";
        private string baseAddress = "https://api.guildwars2.com";
        private string accountAccessor = "/v2/account?access_token=";

        public userKeyData() { }
        public userKeyData(string key)
        {
            this.key = key;
        }

        public void setKey(string key)
        {
            if (key != null)
                this.key = key;
            else
                Log.Error("Key is null");
        }
        public string getKey() => key;

        public void setBaseAddress(string baseAddress)
        {
            if (key != null)
                this.baseAddress = baseAddress;
            else
                Log.Error("baseAddress is null");
        }
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

    public class ApiCall
    {

        public static async Task RunAsync(string key)
        {
            HttpClient client = new HttpClient();
            userKeyData user = new userKeyData();

            user.setKey(key);
            //client.BaseAddress = new Uri(User.getBaseAddress);
            try
            {
                UserData userData = await client.GetFromJsonAsync<UserData>($"{user.getBaseAddress}{user.getAccountAccessor}{key}");
                Log.Info($"{userData}");
            }
            catch(ArgumentException e)
            {
                Log.Error($"Something went wrong - {e}");
            }
        }

        

    }
}
