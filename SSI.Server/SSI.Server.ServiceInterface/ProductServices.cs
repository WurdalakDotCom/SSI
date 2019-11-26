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
    class ProductServices : Service
    {
        public IDbConnectionFactory DbFactory { get; set; }

        public object Any(GetProductById request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.SingleById<Product>(request.Id);
            }
        }
        public object Any(GetAllProduct request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                var result = db.Select<Product>();
                return new ListProduct() { Result = result };
            }
        }

        public void Any(CreateProduct request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Insert(request.Product);
            }
        }

        public void Any(UpdateProduct request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Update(request.Product);
            }
        }

        public void Any(DeleteProduct request)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                db.Delete(request.Product);
            }
        }
    }
}
