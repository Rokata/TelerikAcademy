using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade must be positive or 0.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Min grade must be at least 0.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade must be bigger than min grade.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentException("Comment must not be empty string.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
