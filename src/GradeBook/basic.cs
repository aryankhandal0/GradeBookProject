using System;

namespace GradeBook{
    class BasicStarter{
        static void Main_Starter(string[] args)
        {
            var x = 3.14;
            double y = 1.86;
            double z = x + y;
            Console.WriteLine(z);
            //array1
            double[] numbers = new double[3];
            numbers[0] = 12.7;
            numbers[1] = 10.2;
            numbers[2] = 6.1;
            //array2
            var num = new[] {12.7,10.2,6.1};
            double result = 0.0;
            //for loop
            foreach(var number in num){
                result += number;
            }
            Console.WriteLine(result);
    // System Arguments
            if(args.Length>0){
                Console.WriteLine($"Hello, {args[0]}!");
            } else {
                Console.WriteLine("Hello");
            }
        }
    }
}