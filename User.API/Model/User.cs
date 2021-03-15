using User.API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Model
{
    public class User :IEntity
    {
        [Key]
        public int UId { get; set; }

        [Required]

        [StringLength(100)]
        public string F_name { get; set; }

        [StringLength(100)]
        public string L_name { get; set; }

        public int Contact { get; set; }

        public int Type { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Degree { get; set; }

        [StringLength(100)]
        public string Batch { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}
