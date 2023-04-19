using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Users
{
    public class AddRoleModel
    {
      

        public Guid UserId { get; set; }
        public string RoleName { get; set; }
        public AddRoleModel(Guid userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
