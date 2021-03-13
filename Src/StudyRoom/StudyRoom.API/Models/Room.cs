using StudyRoom.API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Models
{
    public class Room : IEntity
    {
        // In here we have declared PRIMARY KEY in API model
        //@Nidula just check this out
        [Key]
        public int SId { get; set; }

        [Required]
        public int Floor { get; set; }

        public int Options { get; set; }

        public int Capacity { get; set; }

        [StringLength(10)]
        public string Location { get; set; }
    }
}
