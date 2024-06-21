﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Student_Assessment_Projects.Models
{
    public class Student : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Strand { get; set; }
        public string FullName { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
