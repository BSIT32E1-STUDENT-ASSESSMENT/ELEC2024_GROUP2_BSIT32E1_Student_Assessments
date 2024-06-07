using Microsoft.AspNetCore.Mvc;
using Student_Assessment_Projects.Models;
using System.Collections.Generic;
using System.Web;
using Student_Assessment_Projects.Models;

namespace Student_Assessment_Projects.Controllers
{
    public class AdviserModuleController : Controller
    {
        public ActionResult Index()
        {
            var studentGrades = new List<StudentGrade>
            {
                new StudentGrade { SubjectCode = "Sci01", Subject = "Science", FinalGrade7 = 90, FinalGrade8 = 98, FinalGrade9 = 91, FinalGrade10 = 93, Strand = "STEM" },
                new StudentGrade { SubjectCode = "Eng01", Subject = "English", FinalGrade7 = 89, FinalGrade8 = 87, FinalGrade9 = 86, FinalGrade10 = 87, Strand = "Regular text column" },
                new StudentGrade { SubjectCode = "Math03", Subject = "Mathematics", FinalGrade7 = 85, FinalGrade8 = 86, FinalGrade9 = 87, FinalGrade10 = 86, Strand = "Regular text column" },
                new StudentGrade { SubjectCode = "His02", Subject = "History", FinalGrade7 = 89, FinalGrade8 = 90, FinalGrade9 = 87, FinalGrade10 = 89, Strand = "Regular text column" },
                new StudentGrade { SubjectCode = "Fil04", Subject = "Filipino", FinalGrade7 = 89, FinalGrade8 = 91, FinalGrade9 = 94, FinalGrade10 = 91, Strand = "Regular text column" }
            };
            return View(studentGrades);
        }
    }
}
