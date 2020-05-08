using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        
    }
    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line!=null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            // category = "";
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
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
        public override event GradeAddedDelegate GradeAdded;
        
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
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach(var grade in grades)
            {
                result.Add(grade);                
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
        /* Removed in Inheritance
        public string Name
        {
            get;
            set;
            // Blocking Writes
            // private set;
        }
        // readonly string category = "Science";
        // public const string CATEGORY = "Science"; 
        */
    }
}