using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name");
            string name = Console.ReadLine();
            Console.WriteLine("Quantas horas dormiu noite passada");
            int hoursOfSleep = int.Parse(Console.ReadLine());

            Console.WriteLine("Hello World " + name);
            if (hoursOfSleep > 8)
            {
                Console.WriteLine("Bem dormido");
            } else
            {
                Console.WriteLine("Dorme mais");
            }

        }
    }
}
