using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace SSI.Server.ServiceModel.UserModels
{
    [Alias("UserAuth")]
    public class UserLocal
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Roles { get; set; }
        public string Password { get; set; }
    }
}
