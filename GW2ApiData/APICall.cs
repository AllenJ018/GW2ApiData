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
        // = "FD6AE079-B9E3-F24D-B612-E136FDD5B1E2BE134C44-5140-430D-BEEA-A1FC7E91FE9E";
        string callToAPI = "api.guildwars2.com/v2/account?access_token=";
        

        ApiCall(string passTo)
        {
            this.passTo = passTo;
        }
        
    }
}
