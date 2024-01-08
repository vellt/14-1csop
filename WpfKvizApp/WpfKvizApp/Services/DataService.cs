using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKvizApp.Models;

namespace WpfKvizApp.Services
{
    class DataService
    {
        public List<Question> GetSampleQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id=Guid.NewGuid().ToString(),
                    Text="Magyarország fővárosa",
                    Answers =
                    {
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            Text="Budapest",
                            Validity=AnswerValidity.Correct,
                            ImageSource="https://www.budapest.org/en/wp-content/uploads/sites/101/parliament-budapest-hungary-hd.jpg",
                        },
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            Text="Debrecen",
                            Validity=AnswerValidity.Incorrect,
                            ImageSource="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Debrecen_f%C5%91t%C3%A9r_2009.jpg/1200px-Debrecen_f%C5%91t%C3%A9r_2009.jpg",
                        },
                        new Answer
                        {
                            Id= Guid.NewGuid().ToString(),
                            Text="Szeged",
                            Validity=AnswerValidity.Incorrect,
                            ImageSource="https://www.magyarkurir.hu/img1.php?id=106299&img=c_IMG_1467.jpg",
                        }
                    }
                },
                new Question
                {
                    Id=Guid.NewGuid().ToString(),
                    Text="Melyik magyar város az, amely kétszer is volt M.o. fővárosa az elmúlt 175 évben?",
                    Answers =
                    {
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            ImageSource="https://www.orszagjaro.net/wp-content/uploads/2017/07/esztergom01-800x445.jpg",
                            Text = "Esztergom",
                            Validity = AnswerValidity.Incorrect,
                        },
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            ImageSource="https://turizmus.szekesfehervar.hu/_upload/catalog_pic/4_329.jpg",
                            Text = "Székesfehérvár",
                            Validity = AnswerValidity.Incorrect,
                        },
                        new Answer
                        {
                            Id=Guid.NewGuid().ToString(),
                            ImageSource="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Debrecen_f%C5%91t%C3%A9r_2009.jpg/1200px-Debrecen_f%C5%91t%C3%A9r_2009.jpg",
                            Text = "Debrecen",
                            Validity = AnswerValidity.Correct,
                        },
                    }
                }

            };
        }
    }
}
