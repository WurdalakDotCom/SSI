using ServiceStack;

namespace SSI.UI.Core
{
    static class Gateway
    {
        private static JsonServiceClient client;
        private static JsonServiceClient Client 
        {
            get
            {
                if(client == null)
                {
                    client = new JsonServiceClient("http://127.0.0.1:4558");
                }
                return client;
            }
        }

        public static TResponse Call<TResponse>(IReturn<TResponse> requestDto)
        {
            return Client.Send(requestDto);
        }

        public static void Call(IReturnVoid requestDto)
        {
            Client.Send(requestDto);
        }
    }
}
