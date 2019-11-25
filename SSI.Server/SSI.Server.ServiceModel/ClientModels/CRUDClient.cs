using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.ClientModels
{
    public class CreateClient : IReturnVoid
    {
        public Client Client { get; set; }
    }
    
    public class DeleteClient : IReturnVoid
    {
        public Client Client { get; set; }
    }
   
    public class UpdateClient : IReturnVoid
    {
        public Client Client { get; set; }
    }

    public class GetClientById : IReturn<Client>
    {
        public int Id { get; set; }
    }

    public class GetAllClient : IReturn<ListClient>
    {
    }

    public class ListClient
    {
        public List<Client> Result { get; set; }
    }
}
