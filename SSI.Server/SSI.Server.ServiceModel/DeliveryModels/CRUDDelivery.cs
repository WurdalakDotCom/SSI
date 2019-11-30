using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.DeliveryModels
{
    public class AddDelivery : IReturnVoid
    {
        public Delivery Delivery { get; set; }
    }
    public class RegisterDelivery : IReturnVoid
    {
        public Delivery Delivery { get; set; }
    }

    public class DeleteDelivery : IReturnVoid
    {
        public Delivery Delivery { get; set; }
    }

    public class UpdateDelivery : IReturnVoid
    {
        public Delivery Delivery { get; set; }
    }

    public class GetDeliveryById : IReturn<Delivery>
    {
        public int Id { get; set; }
    }

    public class GetAllDelivery : IReturn<ListDelivery>
    {
    }

    public class ListDelivery
    {
        public List<Delivery> Result { get; set; }
    }
}
