using kviz_console.Models;
using kviz_console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kviz_console
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            List<Question> questions= dataService.GetSampleQuestions();
            /*
            foreach (Question question in questions)
            {
                Console.WriteLine(question);
            }
            */
            int joValaszokSzamlalo = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i].Text);
                for (int j = 0; j < questions[i].Answers.Count; j++)
                {
                    Console.WriteLine($"\t{j+1}.) {questions[i].Answers[j].Text}");
                }
                Console.Write("Megoldás: ");
                int megoldas = Convert.ToInt32(Console.ReadLine());
                Answer felhMegoldasa = questions[i].Answers[megoldas - 1];
                if (felhMegoldasa.Validity == AnswerValidity.Correct) joValaszokSzamlalo++;
            }
            Console.WriteLine($"Pontok Száma: {joValaszokSzamlalo}/{questions.Count}");

            Console.ReadKey();
        }
    }
}
