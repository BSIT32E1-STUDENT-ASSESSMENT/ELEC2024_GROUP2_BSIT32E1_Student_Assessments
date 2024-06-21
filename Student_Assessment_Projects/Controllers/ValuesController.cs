using Microsoft.AspNetCore.Mvc;
using Student_Assessment_Projects.Models; // Ensure correct namespace import

namespace Student_Assessment_Projects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("get-student-grade")]
        public IActionResult GetStudentGrade([FromQuery] string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrade.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return NotFound();
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Optionally, you can return studentGrade or a subset of it
            return Ok(studentGrade);
        }
    }
}