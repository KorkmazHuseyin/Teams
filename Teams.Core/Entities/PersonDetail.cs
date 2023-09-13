using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.Core.Entities
{
    public class PersonDetail
    {
        [Key]
        public int PersonDetailID { get; set; }

        public int PersonID { get; set; }

        public int TeamID { get; set; }

        public int TitleID { get; set; }
    }
}
