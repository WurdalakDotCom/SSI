using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.Server.ServiceModel.UserModels
{
    public class GetAllUser : IReturn<UserList>
    {
    }

    public class UserList
    {
        public List<User>
    }
}
