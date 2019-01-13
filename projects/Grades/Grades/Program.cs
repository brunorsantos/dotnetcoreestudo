﻿using System;
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

            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.AverageGrade);
        }
    }
}