using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string otherInfo;
        private const int MinBirthDateYear = 1950;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Invalid value for first name.");
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Invalid value for last name.");
                lastName = value;
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Invalid date value.");
                birthDate = value;
            }
        }

        public string OtherInfo
        {
            get { return otherInfo; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Invalid value of other info.");
                otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            if (this.birthDate.Year < MinBirthDateYear || other.birthDate.Year < MinBirthDateYear)
                throw new ArgumentException("Invalid student birthdate. Year must have value " + MinBirthDateYear + " or more.");

            return this.birthDate < other.birthDate;
        }
    }
}
