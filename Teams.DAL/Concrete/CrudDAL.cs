using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Core.Context;
using Teams.Core.DTO;
using Teams.Core.Entities;
using Teams.DAL.Interfaces;

namespace Teams.DAL.Concrete
{
    public class CrudDAL : ICrudDAL
    {
        TeamsContext _db;
        public CrudDAL(TeamsContext db)
        {
            _db = db;
        }
        public EmployeeDTO Add(EmployeeDTO Empinfo)
        {
            _db.Add(Empinfo);// Bakarım hata alırsam
            _db.SaveChanges();
            return Empinfo;
        }
     
        public List<EmployeeDTO> GetAll()
        {
            var personList = (from p in _db.Person
                              join pd in _db.PersonDetail on p.PersonID equals pd.PersonID
                              join t in _db.Team on pd.TeamID equals t.TeamID 
                              join tit in _db.Title on pd.TitleID equals tit.TitleID
                              select new EmployeeDTO()
                              {
                                  PersonID = p.PersonID,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,                             
                                  TeamsName = t.TeamsName,
                                  TitleName = tit.TitleName
                              }).ToList();
            return personList;


        }
    }
}
