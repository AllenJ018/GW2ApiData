using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GW2ApiData
{
    class ApiCall
    {
        string passTo;
        string callToAPI = "api.guildwars2.com/v2/account?access_token=";
        

        ApiCall(string passTo)
        {
            this.passTo = passTo;
        }
        
    }
}
