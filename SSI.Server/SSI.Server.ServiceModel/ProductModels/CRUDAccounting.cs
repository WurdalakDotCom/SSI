using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.ProductModels
{
    public class CreateAccounting : IReturnVoid
    {
        public Accounting Accounting { get; set; }
    }

    public class DeleteAccounting : IReturnVoid
    {
        public Accounting Accounting { get; set; }
    }

    public class UpdateAccounting : IReturnVoid
    {
        public Accounting Accounting { get; set; }
    }

    public class GetAccountingById : IReturn<Accounting>
    {
        public int Id { get; set; }
    }

    public class GetAccountingByOwnerId : IReturn<ListAccounting>
    {
        public int Id { get; set; }
    }

    public class GetAllAccounting : IReturn<ListAccounting>
    {
    }

    public class ListAccounting
    {
        public List<Accounting> Result { get; set; }
    }
}
