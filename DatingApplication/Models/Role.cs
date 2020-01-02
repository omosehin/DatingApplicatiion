using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Models
{
    public class Role :IdentityRole<int> //a user can have many role and a role can have many user
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
