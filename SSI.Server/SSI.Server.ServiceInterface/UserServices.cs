using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.UserModels;
using System.Linq;

namespace SSI.Server.ServiceInterface
{
    public class UserServices : Service
    {
        public IDbConnectionFactory DbFactory { get; set; }

        public object Any(GetAllUser request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var reuslt = db.Select<UserAuth>().Select(x => x.ConvertTo<UserLocal>());
                return new UserList() { Result = reuslt.ToList() };
            }
        }

        public object Any(GetUserInfo request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.Single<UserAuth>(x => x.UserName == request.UserName).ConvertTo<UserLocal>();
            }
        }
    }
}
