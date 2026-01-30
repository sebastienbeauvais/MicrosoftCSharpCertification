using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        // Details
        string studentName = "Sophia Johnson";
        string course1Name = "English 101";
        string course2Name = "Algebra 101";
        string course3Name = "Biology 101";
        string course4Name = "Computer Science I";
        string course5Name = "Psychology 101";

        int course1Credit = 3;
        int course2Credit = 3;
        int course3Credit = 4;
        int course4Credit = 4;
        int course5Credit = 3;

        // String representation of grades
        string course1Grade = "A";
        string course2Grade = "B";
        string course3Grade = "B";
        string course4Grade = "B";
        string course5Grade = "A";

        /*
        Console.WriteLine($"{course1Name} {course1Grade} {course1Credit}");
        Console.WriteLine($"{course2Name} {course2Grade} {course2Credit}");
        Console.WriteLine($"{course3Name} {course3Grade} {course3Credit}");
        Console.WriteLine($"{course4Name} {course4Grade} {course4Credit}");
        Console.WriteLine($"{course5Name} {course5Grade} {course5Credit}");
        */

        //reformat string and ints into a list
        List<string> sophiasCourses = new List<string>
        {
            "English 101",
            "Algebra 101",
            "Biology 101",
            "Computer Science I",
            "Phycology 101"
        };

        List<string> courseCreditsEarned = new List<string>
        {
            "A",
            "B",
            "B",
            "B",
            "A"
        };
        List<int> courseCredits = new List<int>
        {
            3, 3, 4, 4, 3
        };

        // Calculating the sum of credit hours

        var creditHours = CalculateCreditHours(courseCredits);
        var totalGradePoints = CalculateTotalGradePoints(courseCreditsEarned, courseCredits);

        // This will all be moved to its own function
        Console.WriteLine($"Student Name: {studentName}");
        Console.WriteLine($"total grade points earn: {totalGradePoints}\ttotal credit hours: {creditHours}");
        PrintHeader();
        
        
    }
    private static void PrintHeader()
    {
        Console.WriteLine("Course\t\tCredit\tCredit Hour\tGrade Points");
    }
    private static int ConvertCourseLetterToCredit(string courseCreditEarned)
    {
        var courseCredit = 0;
        if(courseCreditEarned == "A")
        {
            courseCredit = 4;
        }
        else if (courseCreditEarned == "B")
        {
            courseCredit = 3;
        }
        return courseCredit;
    }
    private static int CalculateCreditHours(List<int> courseCredits)
    {
        var totalCourseCreditHours = 0;
        foreach(var courseCredit in courseCredits)
        {
            totalCourseCreditHours += courseCredit;
        }
        return totalCourseCreditHours;
    }
    private static int CalculateTotalGradePoints(List<string> courseGradesEarned, List<int> courseCredits)
    {
        var gradePoints = 0;
        
        // First we need to convert the course grade to a credit earned
        List<int> courseCreditEarned = new List<int>();
        foreach(string courseGradeEarned in courseGradesEarned)
        {
            var credit = ConvertCourseLetterToCredit(courseGradeEarned);
            courseCreditEarned.Add(credit);
        }
        int courseCreditIterrator = 0;
        foreach (int credit in courseCreditEarned)
        {
            gradePoints += credit * courseCredits[courseCreditIterrator];
            courseCreditIterrator++;
        }
        return gradePoints;
    }
}