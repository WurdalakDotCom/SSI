using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.ClientModels;

namespace SSI.Server.ServiceInterface
{
    public class ClientServices : Service
    {
        public IDbConnectionFactory DbFactory { get; set; }

        public object Any(GetClientById request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.SingleById<Client>(request.Id);
            }
        }
        public object Any(GetAllClient request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var result = db.Select<Client>();
                return new ListClient() { Result = result };
            }
        }

        public void Any(CreateClient request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Insert(request.Client);
            }
        }

        public void Any(UpdateClient request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Update(request.Client);
            }
        }

        public void Any(DeleteClient request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Delete(request.Client);
            }
        }
    }
}
