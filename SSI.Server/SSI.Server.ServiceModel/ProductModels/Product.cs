using ServiceStack.DataAnnotations;

namespace SSI.Server.ServiceModel.ProductModels
{
    public class Product
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Article { get; set; }
        public string Description { get; set; }
    }
}
