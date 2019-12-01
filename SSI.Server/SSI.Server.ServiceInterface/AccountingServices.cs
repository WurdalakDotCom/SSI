using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.Server.ServiceInterface
{
    class AccountingServices : Service
    {
        public IDbConnectionFactory DbFactory { get; set; }

        public object Any(GetAccountingById request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.SingleById<Accounting>(request.Id);
            }
        }

        public object Any(GetAccountingByOwnerId request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var result = db.LoadSelect<Accounting>(x => x.OwnerId == request.Id);
                return new ListAccounting() { Result = result };
            }
        }

        public object Any(GetAllAccounting request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var result = db.LoadSelect<Accounting>();
                return new ListAccounting() { Result = result };
            }
        }

        public void Any(CreateAccounting request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Insert(request.Accounting);
            }
        }

        public void Any(UpdateAccounting request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Update(request.Accounting);
            }
        }

        public void Any(DeleteAccounting request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Delete(request.Accounting);
            }
        }
    }
}
