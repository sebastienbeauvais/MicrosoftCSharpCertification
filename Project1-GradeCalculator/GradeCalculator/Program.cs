using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

public class Program
{
    public static void Main(string[] args)
    {
        // Details - data setup
        string studentName = "Sophia Johnson";

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

        var creditHours = CalculateCreditHours(courseCredits);
        var totalGradePoints = CalculateTotalGradePoints(courseCreditsEarned, courseCredits);
        var gradePointAverage = CalculateGradePointAverage(totalGradePoints, creditHours);
        var formattedGradePointAverage = FormatGradePointAverage(gradePointAverage);

        // This will all be moved to its own function
        CreateFinalReport(studentName, sophiasCourses, courseCreditsEarned, courseCredits, formattedGradePointAverage);
        
        
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
    private static decimal CalculateGradePointAverage(int totalGradePoints, int totalCredits)
    {
        return (decimal) totalGradePoints / (decimal) totalCredits;
    }
    private static decimal FormatGradePointAverage(decimal gpa)
    {
        return Math.Round(gpa, 2);
    }
    private static void CreateFinalReport(string studentName
        , List<string> classesTaken
        , List<string> gradesEarned
        , List<int> courseCreditsPerClass
        , decimal gpa)
    {
        Console.WriteLine($"Student: {studentName}\n");
        PrintHeader();
        var additionalListsIterrator = 0;
        foreach (string classTaken in classesTaken) 
        {
            if(classTaken.Contains("Computer Science"))
            {
                Console.WriteLine($"{classTaken}\t{gradesEarned[additionalListsIterrator]}\t{courseCreditsPerClass[additionalListsIterrator]}");

            }
            else
            {
                Console.WriteLine($"{classTaken}\t\t{gradesEarned[additionalListsIterrator]}\t{courseCreditsPerClass[additionalListsIterrator]}");
            }
            additionalListsIterrator++;
        }
        Console.WriteLine($"Final GPA:\t\t{gpa}");

    }
    private static void PrintHeader()
    {
        Console.WriteLine("Course\t\t\tCredit\tCredit Hour");
    }
}