using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.UserModels
{
    public class GetAllUser : IReturn<UserList>
    {
    }

    public class CreateUser : IReturnVoid
    {
        public UserLocal User { get; set; } 
    }

    public class UserList
    {
        public List<UserLocal> Result { get; set; }
    }
}
