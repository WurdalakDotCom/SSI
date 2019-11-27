using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.UserModels;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;

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
        public object Any(CreateUser request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var user = db.Single<UserAuth>(x => x.UserName == request.User.UserName);
                if (user != null)
                    return false;

                var authRepository = ServiceStackHost.Instance.Resolve<IAuthRepository>();
                authRepository.CreateUserAuth(new UserAuth() { UserName = request.User.UserName, CreatedDate = request.User.CreatedDate }, request.User.Password);

                return true;
            }
        }

        public void Any(UpdateUser request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Update<UserAuth>(request.User);
            }
        }

        public void Any(DeleteUser request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.DeleteById<UserAuth>(request.Id);
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
