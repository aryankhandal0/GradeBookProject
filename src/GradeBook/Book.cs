using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    
    public class Book
    {
        public Book(string name)
        {
            // category = "";
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public event GradeAddedDelegate GradeAdded;
        
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A': AddGrade(90);break;
                case 'B': AddGrade(80);break;
                case 'C': AddGrade(70);break;
                case 'D': AddGrade(60);break;
                case 'E': AddGrade(50);break;
                default: AddGrade(0);break;
            }
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            /* For Each Loop */
            foreach(var grade in grades)
            {
                /* Break Statement */
                // if(grade == 42.1)
                // {
                //     break;
                // }

                /* Continue Statement */
                // if(grade == 42.1)
                // {
                //     continue;
                // }

                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            /* Do While Loop */
            // var index = 0;
            // do(){
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];
            //     index += 1;
            // }while(index < grades.Count);

            /*  While Loop */
            // while(index < grades.Count)
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];
            //     index += 1;
            // }

            /* For Loop */
            // for(var index = 0;index < grades.Count; index++)
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];
            // }
            result.Average /= grades.Count;
            switch(result.Average)
            {
                case var d when d>=90.0:
                    result.Letter = 'A';
                    break;
                case var d when d>=80.0:
                    result.Letter = 'B';
                    break;
                case var d when d>=70.0:
                    result.Letter = 'C';
                    break;
                case var d when d>=60.0:
                    result.Letter = 'D';
                    break;
                case var d when d>=50.0:
                    result.Letter = 'E';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;     
        }
        private List<double> grades;
        
        /* Property Write Getter-Setter Complex Code*/
        /*
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        private string name;
        */
        /* Property Write Getter-Setter Easy Code*/
        public string Name
        {
            get;
            set;
            // Blocking Writes
            // private set;
        }
        // readonly string category = "Science";
        // public const string CATEGORY = "Science"; 
    }
}