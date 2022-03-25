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

        public override string ToString()
        {
            string guildString = "";
            string guildLeaderString = "";
            string accessability = "";
            string comm = "";
            string monthly = "";
            double hours;
            double days;

            for (int i = 0; i < this.guilds.Length; i++)
                guildString += $"Guild {i + 1}: {this.guilds[i]}\n";
            for (int i = 0; i < this.guild_leader.Length; i++)
                guildLeaderString += $"Guild Leader for guild: {this.guild_leader[i]}\n";
            for (int i = 0; i < this.access.Length; i++)
                accessability += $"     {access[i]}\n";
            if (commander)
                comm = "This account has Commander Permissions";
            else
                comm = "This account does not have Commander Permissions";
            if (monthly_ap > 0)
                monthly = $"This account has {monthly_ap} points of discountinued monthly ap";
            else
                monthly = $"This account has no monthly ap";
            hours = Math.Round((double)age/60/ 60, 2);
            days = Math.Round(hours / 24, 2);

            return $"id: {this.id}\n" +
                   $"name: {this.name}\n" +
                   $"age:   This account has been played for {this.age} seconds\n" +
                   $"       This account has been played for {hours} hours \n"+
                   $"       This account has been played for {days} days\n"+
                   $"world: {this.world}\n" +
                   $"{guildString}" +
                   $"{guildLeaderString}" +
                   $"account created: {created}\n" +
                   $"The account has access to:\n{accessability}" +
                   $"{comm}\n" +
                   $"The fractal level of this account is: {fractal_level}\n" +
                   $"This account has {daily_ap} points of daily ap\n" +
                   $"{monthly}\n" +
                   $"The WvW rank of this account is: {wvw_rank}";
        }
    }
}
