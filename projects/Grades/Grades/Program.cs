using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synts = new SpeechSynthesizer();
            synts.Speak("E se chamar polícia, a boca espuma de ódio");

            GradeBook book = new GradeBook();
            book.AddGrade(81);
            book.AddGrade(91.5f); // incluir o f para considerar o numero como float e nao como double
            book.AddGrade(100);

    
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Nota mais alta:", (int)stats.HighestGrade);
            WriteResult("Nota mais alta:", (int)stats.LowestGrade);
            WriteResult("Nota mais alta:", stats.AverageGrade);

        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }
    }
}
