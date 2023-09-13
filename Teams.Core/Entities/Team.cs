using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.Core.Entities
{
   public class Team
    {
        [Key]
        public int TeamID { get; set; }

        public string TeamsName { get; set; }
    }
}
