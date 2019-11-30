using ServiceStack.DataAnnotations;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.ProductModels;
using System;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.DeliveryModels
{
    public class Delivery
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        [ForeignKey(typeof(Client), OnDelete = "SET NULL", OnUpdate = "CASCADE")]
        public int OwnerId{ get; set; }
        [Reference]
        public List<Party> Parties { get; set; }
        [Default("NOW()")]
        public DateTime Date { get; set; }
        [Reference]
        public Client Client { get; set; }
    }

    public class Party
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [ForeignKey(typeof(Delivery), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int DeliveryId { get; set; }
        [ForeignKey(typeof(Product), OnDelete = "SET NULL", OnUpdate = "CASCADE")]
        public int ProductId { get; set; }
        public int Count { get; set; }
        [Reference]
        public Product Product { get; set; }
    }
}
