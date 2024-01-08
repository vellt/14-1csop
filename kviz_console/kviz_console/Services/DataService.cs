using kviz_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kviz_console.Services
{
    class DataService
    {
        public List<Question> GetSampleQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id= Guid.NewGuid().ToString(),
                    Text= "Magyarország fővárosa",
                    Answers =
                    {
                        new Answer
                        {
                            Id= Guid.NewGuid().ToString(),
                            Text= "Szeged",
                            Validity= AnswerValidity.Incorrect,
                        },
                        new Answer
                        {
                            Id= Guid.NewGuid().ToString(),
                            Text="Budapest",
                            Validity=AnswerValidity.Correct,
                        },
                        new Answer
                        {
                            Id = Guid.NewGuid().ToString(),
                            Text="Debrecen",
                            Validity=AnswerValidity.Incorrect,
                        }
                    }
                },
                new Question
                {
                    Id=Guid.NewGuid().ToString(),
                    Text="Melyik magyar város volt az, amely " +
                    "kétszer is Magyarország fővárosa volt az elmúlt 175 évben?",
                    Answers =
                    {
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            Text="Esztergom",
                            Validity= AnswerValidity.Incorrect,
                        },
                        new Answer
                        {
                            Id=$"{Guid.NewGuid()}",
                            Text="Székesfehérvár",
                            Validity= AnswerValidity.Incorrect,
                        },
                        new Answer
                        {
                            Id= Guid.NewGuid().ToString(),
                            Text= "Debrecen",
                            Validity=AnswerValidity.Correct,
                        }
                    }
                }
            };
        }
    }
}
