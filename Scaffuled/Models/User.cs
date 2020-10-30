using System;
using System.Collections.Generic;

namespace Scaffuled.Models
{
    public partial class User
    {
        public short Id { get; set; }
        public short? RoleId { get; set; }
        public string Name { get; set; }
        public bool? IsTest { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; }
    }
}
