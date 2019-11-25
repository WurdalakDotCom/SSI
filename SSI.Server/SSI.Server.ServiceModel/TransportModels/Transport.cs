using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.Server.ServiceModel.TransportModels
{
    public class Transport
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        [Required]
        public string RegNumber { get; set; }
        [Required]
        public string VinNumber { get; set; }
    }
}
