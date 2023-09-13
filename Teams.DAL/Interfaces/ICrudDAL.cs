using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Core.DTO;

namespace Teams.DAL.Interfaces
{
   public interface ICrudDAL
    {
        EmployeeDTO Add(EmployeeDTO Emp);

        List<EmployeeDTO> GetAll();
    }
}
