using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Student_Assessment_Projects.Data;
using Student_Assessment_Projects.Models;

[Authorize(Roles = "Teacher")]
public class TeacherController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeacherController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Teacher/Dashboard
    public async Task<IActionResult> Dashboard()
    {
        return View(await _context.Students.Include(s => s.Grades).ToListAsync());
    }

    // GET: Teacher/CreateStudent
    public IActionResult CreateStudent()
    {
        return View();
    }

    // POST: Teacher/CreateStudent
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }
        return View(student);
    }

    // Additional actions for adding grades, etc.
}
