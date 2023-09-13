using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Core.Entities;

namespace Teams.Core.DTO
{
    public class EmployeeDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamsName { get; set; }
        public string TitleName { get; set; }

    }
}
