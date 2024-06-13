
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Assessment_Projects.Data;
using Student_Assessment_Projects.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize(Roles = "Student")]
public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Student/Dashboard
    public async Task<IActionResult> Dashboard()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var student = await _context.Students
            .Include(s => s.Grades)
            .FirstOrDefaultAsync(s => s.Id == userId);

        // Logic to determine strand based on grades
        var strand = DetermineStrand(student);

        ViewBag.Strand = strand;
        return View(student);
    }

    private string DetermineStrand(Student student)
    {
        // Implement your logic to determine the strand based on grades
        return "Science"; // Example
    }
}

