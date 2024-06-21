using Microsoft.AspNetCore.Mvc;
using Student_Assessment_Projects.Models;
using System.Diagnostics;

namespace Student_Assessment_Projects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult StudentDetails(int id, string StudentNumber, string StudentName, int Math, int English, int Science, int History, int Values, int Filipino, int TLE, string FirstChoice, string SecondChoice)
        {
            var model = new StudentGrade
            {
                StudentNumber = StudentNumber,
                StudentName = StudentName,
                Math = Math,
                English = English,
                Science = Science,
                History = History,
                Values = Values,
                Filipino = Filipino,
                TLE = TLE,
                FirstChoice = FirstChoice,
                SecondChoice = SecondChoice
            };

            ViewBag.RecommendedStrands = GetRecommendedStrands(model); // Assuming you have this method

            return View(model);
        }
        private Tuple<string, string, string, string, string, string, string> GetRecommendedStrands(StudentGrade model)
        {
            // Your logic to get recommended strands based on the student's grades
            return new Tuple<string, string, string, string, string, string, string>("IA", "HE", "ICT", "STEM", "ABM", "HUMSS", "GAS");
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Adviser()
        {
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }

        public IActionResult NewAdviser()
        {
            return View();
        }

        public IActionResult AddNew()
        {
            return View();
        }

        public IActionResult Test()
        {
            return Ok("test");
        }




        public IActionResult RecommendStrand(string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrade.FirstOrDefault(s => s.StudentNumber == studentNumber);
            if (studentGrade == null)
            {
                return NotFound(); // Return a 404 error if student not found
            }

            var recommendedStrands = Strand.GetRecommendedStrands(studentGrade.Math, studentGrade.English, studentGrade.Science,
                                                                  studentGrade.History, studentGrade.Values, studentGrade.Filipino,
                                                                  studentGrade.TLE);

            ViewBag.RecommendedStrands = recommendedStrands;

            return View("StudentDetails", studentGrade);
        }


        [HttpPost]
        public IActionResult EnterStudentNumber(string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrade.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return RedirectToAction("Students"); // Handle the case where student is not found
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            ViewBag.StudentGrade = studentGrade;
            ViewBag.RecommendedStrands = recommendedStrands;

            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Redirect to StudentDetails action to display student information
            return RedirectToAction("StudentDetails", studentGrade);
        }

        [HttpGet]
        public IActionResult GetStudentGrade([FromQuery] string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrade.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return NotFound(); // Handle the case where student is not found
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Return the student grade object
            return Ok(studentGrade);
        }


        public IActionResult AddGrade()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}