using Microsoft.AspNetCore.Identity;
namespace Student_Assessment_Projects.Models
{
    public class Teacher : IdentityUser
    {
        public string FullName { get; set; }
    }
}

