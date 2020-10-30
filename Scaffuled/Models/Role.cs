using System;
using System.Collections.Generic;

namespace Scaffuled.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public short Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsTest { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
