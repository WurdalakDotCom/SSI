using ServiceStack.DataAnnotations;
using SSI.Server.ServiceModel.ClientModels;

namespace SSI.Server.ServiceModel.ProductModels
{
    public class Accounting
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [ForeignKey(typeof(Client), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int OwnerId { get; set; }
        [ForeignKey(typeof(Product), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int ProductId { get; set; }
        [Default(0)]
        public int Count { get; set; }

        [Reference]
        public Client Client { get; set; }
        [Reference]
        public Product Product { get; set; }
    }
}
