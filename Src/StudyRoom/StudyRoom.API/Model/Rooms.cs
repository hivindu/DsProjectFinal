using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Model
{
    public class Rooms
    {
        [Key]
        public int SId { get; set; }

        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int Options { get; set; }
        public string Location { get; set; }
    }
}
