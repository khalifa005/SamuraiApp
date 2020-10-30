//namespace WebApplication2
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("User")]
//    public partial class User
//    {
//        [DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public short Id { get; set; }

//        public short? RoleId { get; set; }

//        [Required]
//        [StringLength(5)]
//        public string Name { get; set; }

//        public bool IsTest { get; set; }

//        public bool is_active { get; set; }

//        public virtual role role { get; set; }
//    }
//}
