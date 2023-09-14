using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.Core.Entities
{
   public class Title
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }

    
        public virtual ICollection<PersonDetail> PersonDetail { get; set; }
    }
}
