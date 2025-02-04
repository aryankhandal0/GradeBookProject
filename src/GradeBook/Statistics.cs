using System;

namespace GradeBook
{
    public class Statistics
    {
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d>=90.0:
                        return 'A';
                    case var d when d>=80.0:
                        return 'B';
                    case var d when d>=70.0:
                        return 'C';
                    case var d when d>=60.0:
                        return 'D';
                    case var d when d>=50.0:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
        public double Average
        {
            get
            {
                return Sum/Count;
            }
        }
        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        
    }
}