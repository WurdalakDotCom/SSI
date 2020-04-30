using ServiceStack.DataAnnotations;
using SSI.Server.ServiceModel.ProductModels;
using System;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.ClientModels
{
    public class Client
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string PersonType { get; set; }
        public string ReferenceCompany { get; set; }
        [Required]
        public string Identif { get; set; }
        [Default("NOW()")]
        public DateTime RegDate { get; set; }
        public string Phone { get; set; }
        [Reference]
        public List<Accounting> Accountings { get; set; }
    }
}
