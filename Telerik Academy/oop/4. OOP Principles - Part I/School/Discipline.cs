using System;

namespace School
{
    public class Discipline : ICommentable
    {
        private string name;
        private int lecturesNumber;
        private int exercisesNumber;
        public string FreeTextBlock { get; set; }

        public Discipline(string name, int lecturesNumber, int exercisesNumber)
        {
            this.name = name;
            this.lecturesNumber = lecturesNumber;
            this.exercisesNumber = exercisesNumber;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int LecturesNumber
        {
            get { return lecturesNumber; }
            set { lecturesNumber = value; }
        }

        public int ExercisesNumber
        {
            get { return exercisesNumber; }
            set { exercisesNumber = value; }
        }
    }
}
