using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 2)
        {
            throw new ArgumentOutOfRangeException("Solved problems must be 0, 1 or 2.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        switch (ProblemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: half of the tasks solved.");
            case 2:
                return new ExamResult(6, 2, 6, "Excellent result: all tasks solved.");
            default: throw new ArgumentOutOfRangeException("Solved problems must be 0, 1 or 2.");
        }
    }
}
