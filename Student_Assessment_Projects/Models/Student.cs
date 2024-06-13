using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Student_Assessment_Projects.Models
{
    public class Student : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
