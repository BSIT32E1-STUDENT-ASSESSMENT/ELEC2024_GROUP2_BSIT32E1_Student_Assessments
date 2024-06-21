using Microsoft.AspNetCore.Mvc;

using Student_Assessment_Projects.Models;

public class StudentController : Controller
{
    public ActionResult Adviser()
    {
        var studentGrades = InMemoryDatabase.StudentGrade;
        if (studentGrades == null || !studentGrades.Any())
        {
            // Log or handle the case where studentGrades is null or empty
        }
        return View(studentGrades); // Ensure this returns the correct view
    }

    public ActionResult AddGrade()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddGrade(StudentGrade studentGrade)
    {
        if (InMemoryDatabase.StudentGrade.Any(s => s.StudentNumber == studentGrade.StudentNumber))
        {
            ModelState.AddModelError("StudentNumber", "Student number already exists.");
            return View(studentGrade);
        }

        InMemoryDatabase.StudentGrade.Add(studentGrade);
        return RedirectToAction("Adviser"); // Redirect to Adviser action
    }


    public ActionResult RecommendStrand(int id)
    {
        var studentGrade = InMemoryDatabase.StudentGrade.FirstOrDefault(s => s.Id == id);
        if (studentGrade == null)
        {
            return NotFound(); // Change this line
        }
        var recommendedStrand = InMemoryDatabase.GetRecommendedStrands(studentGrade);
        ViewBag.RecommendedStrand = recommendedStrand;
        return View(studentGrade);
    }

}

