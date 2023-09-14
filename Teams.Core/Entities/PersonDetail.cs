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
        public int PersonDetailID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> TeamID { get; set; }
        public Nullable<int> TitleID { get; set; }

        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
        public virtual Title Title { get; set; }
    }
}
