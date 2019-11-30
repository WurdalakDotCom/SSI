using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceModel.DeliveryModels;

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
                db.Update(request.Delivery);
            }
        }

        public void Any(DeleteDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Delete(request.Delivery);
            }
        }

        public void Any(RegisterDelivery request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Save(request.Delivery, true);
            }
        }
    }
}
