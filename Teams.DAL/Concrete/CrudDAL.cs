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
        public  bool Add(EmployeeDTO Empinfo)
        {
            Team team = new Team() {TeamsName=Empinfo.TeamsName};
            Title title = new Title() { TitleName=Empinfo.TitleName};

            if ((_db.Title.FirstOrDefault(a => a.TitleName == Empinfo.TitleName) == null))
            {
                title = _db.Title.Add(new Title()
                {
                    TitleName = Empinfo.TitleName
                }).Entity;
            }
            else
            {
                title = _db.Title.FirstOrDefault(a => a.TitleName == Empinfo.TitleName);
            }
            _db.SaveChanges();
            if ((_db.Team.FirstOrDefault(a => a.TeamsName == Empinfo.TeamsName) == null))
            {
                team = _db.Team.Add(new Team()
                {
                    TeamsName = Empinfo.TeamsName
                }).Entity;
            }
            else
            {
                team = _db.Team.FirstOrDefault(a => a.TeamsName == Empinfo.TeamsName);
            }
            _db.SaveChanges();


            Person person =_db.Person.Add(new Person()
            {
                FirstName = Empinfo.FirstName,
                LastName = Empinfo.LastName
            }).Entity;
            _db.SaveChanges();


            _db.PersonDetail.Add(new PersonDetail
            {
                PersonID=person.PersonID,
                TeamID=team.TeamID,
                TitleID=title.TitleID            
            });
          var donenDeger=  _db.SaveChanges();

            if (donenDeger>0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
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
