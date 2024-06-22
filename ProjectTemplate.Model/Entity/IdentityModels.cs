using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Model.Entity
{
    public class IdentityModels
    {
        public class ApplicationUser : IdentityUser<long> { }
        public class ApplicationUserClaim : IdentityUserClaim<long> { }
        public class ApplicationUserToken : IdentityUserToken<long> { }
        public class ApplicationUserLogin : IdentityUserLogin<long> { }

        public class ApplicationRole : IdentityRole<long> { }
        public class ApplicationRoleClaim : IdentityRoleClaim<long> { }

        public class ApplicationUserRole : IdentityUserRole<long> { }
    }
}
