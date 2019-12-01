using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.DeliveryModels;
using SSI.Server.ServiceModel.ProductModels;

namespace SSI.Server.ServiceInterface
{
    class DeliveryServices : Service
    {
        public IDbConnectionFactory DbFactory { get; set; }

        public object Any(GetDeliveryById request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.SingleById<Delivery>(request.Id);
            }
        }
        public object Any(GetAllDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var result = db.LoadSelect<Delivery>();

                foreach (var item in result)
                {
                    foreach (var party in item.Parties)
                    {
                        db.LoadReferences(party);
                    }
                }

                return new ListDelivery() { Result = result };
            }
        }

        public void Any(AddDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Insert(request.Delivery);
            }
        }

        public void Any(UpdateDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.ExecuteSql("PRAGMA foreign_keys = ON;");
                db.Update(request.Delivery);
            }
        }

        public void Any(DeleteDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.ExecuteSql("PRAGMA foreign_keys = ON;");
                db.Delete(request.Delivery);
            }
        }

        public void Any(RegisterDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                request.Delivery.Id = (int)db.Insert(request.Delivery, true);
                db.SaveAllReferences(request.Delivery);

                var delivery = db.LoadSingleById<Delivery>(request.Delivery.Id);

                foreach (var party in delivery.Parties)
                {
                    var buffer = db.Single<Accounting>(x => x.ProductId == party.ProductId && x.OwnerId == delivery.OwnerId);

                    if(buffer == null)
                    {
                        db.Insert(new Accounting() { ProductId = party.ProductId, OwnerId = delivery.OwnerId, Count = party.Count });
                    }
                    else
                    {
                        buffer.Count += party.Count;
                        db.Update(buffer);
                    }
                }
            }
        }
    }
}
