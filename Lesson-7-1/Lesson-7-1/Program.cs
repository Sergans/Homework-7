using System;

namespace Lesson_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
           decimal price= 45.9M;
           int oktan = 95;
           string name = "бензин";
            Console.WriteLine($"Цена на {name} марки АИ {oktan} = {price} рублей");
        }
    }
}
