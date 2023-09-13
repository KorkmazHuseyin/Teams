using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Core.Context;
using Teams.Core.DTO;
using Teams.DAL.Interfaces;

namespace Teams.UI.Controllers
{
    public class EmpListController : Controller
    {
       ICrudDAL _cr;
        public EmpListController(ICrudDAL cr)
        {
            _cr = cr;
        }

        [HttpGet]
        public IActionResult Index()
        {
          var list= _cr.GetAll();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index2(EmployeeDTO empinfo)
        {
            
            int maxTeamCapacity = 9;            
            int teamLeaderCount = 0;
            int analystCount = 0;
            int developerCount = 0;
            int testerCount = 0;



            if (empinfo.TeamsName=="A") // Takım adına göre kontrol edebilirsiniz
            {
                //Todo:Burası düzeltilecek
                var list = _cr.GetAll();

                

                if (teamLeaderCount <= 1 || analystCount <= 2 || developerCount<= 5 || testerCount <= 1 ||  maxTeamCapacity<=9)
                {
                   
                    ModelState.AddModelError("", "Takım A'nın kapasitesi aşıldı.");
                    return View(empinfo);
                }
            }
            else if (empinfo.TeamsName == "B")
            {
                if (teamLeaderCount <= 1 || analystCount <= 2 || developerCount <= 5 || testerCount <= 1 || maxTeamCapacity <= 9)
                {
                   
                    ModelState.AddModelError("", "Takım B'nin kapasitesi aşıldı.");
                    return View(empinfo);
                }
            }
            else if (empinfo.TeamsName == "C")
            {
                if (teamLeaderCount <= 1 || analystCount <= 2 || developerCount <= 5 || testerCount <= 1 || maxTeamCapacity <= 9)
                {
                   
                    ModelState.AddModelError("", "Takım C'nin kapasitesi aşıldı.");
                    return View(empinfo);
                }
            }

            // Takım kapasitesi ve ünvan sayılarını artır
            //teamMembersCount++;
            //if (emp.Title == "teamLeader") teamLeadCount++;
            //else if (emp.Title == "analyst") analystCount++;
            //else if (emp.Title == "developer") developerCount++;
            //else if (emp.Title == "tester") testerCount++;

            //// Veritabanına ekle
            //_db.Add(emp);

           
            //TempData["SuccessMessage"] = "Çalışan başarıyla eklendi.";

            return RedirectToAction("Index");

           
        }
    }
}
