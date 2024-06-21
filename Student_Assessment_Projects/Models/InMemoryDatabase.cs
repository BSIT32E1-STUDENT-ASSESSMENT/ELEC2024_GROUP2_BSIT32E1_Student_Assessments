using Student_Assessment_Projects.Models;

public static class InMemoryDatabase
{
    public static List<StudentGrade> StudentGrade { get; } = new List<StudentGrade>();

    public static (string, string) GetRecommendedStrands(StudentGrade studentGrade)
    {
        if (studentGrade == null)
        {
            throw new ArgumentNullException(nameof(studentGrade));
        }

        return Strand.GetRecommendedStrands(
            studentGrade.Math, studentGrade.English, studentGrade.Science,
            studentGrade.History, studentGrade.Values, studentGrade.Filipino,
            studentGrade.TLE);
    }
}