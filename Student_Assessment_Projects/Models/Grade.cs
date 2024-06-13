namespace Student_Assessment_Projects.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Year { get; set; } // 7 to 10
        public int Score { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
