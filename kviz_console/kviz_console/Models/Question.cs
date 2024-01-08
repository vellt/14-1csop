using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kviz_console.Models
{
    public class Question : BaseEntity
    {
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public override string ToString()
        {
            string question = $"Id={Id}, Text={Text}, Answers=\n";
            foreach (Answer answer in Answers)
            {
                question += $"\t{answer}\n";
            }
            return question;
        }
    }
}
