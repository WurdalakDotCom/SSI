using ServiceStack;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.ProductModels
{
    public class CreateProduct : IReturnVoid
    {
        public Product Product { get; set; }
    }

    public class DeleteProduct : IReturnVoid
    {
        public Product Product { get; set; }
    }

    public class UpdateProduct : IReturnVoid
    {
        public Product Product { get; set; }
    }

    public class GetProductById : IReturn<Product>
    {
        public int Id { get; set; }
    }

    public class GetAllProduct : IReturn<ListProduct>
    {
    }

    public class ListProduct
    {
        public List<Product> Result { get; set; }
    }
}
