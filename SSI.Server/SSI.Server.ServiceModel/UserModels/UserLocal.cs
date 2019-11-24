using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.Server.ServiceModel.UserModels
{
    public class UserLocal
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime UserCreateDate { get; set; }
        public List<string> Roles { get; set; }
        public string Password { get; set; }
    }
}
