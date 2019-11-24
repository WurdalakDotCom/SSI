using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.UserModels
{
    public class GetUserInfo : IReturn<UserLocal>
    {
        public string UserName { get; set; }
    }
}
