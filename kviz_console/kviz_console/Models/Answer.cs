using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kviz_console.Models
{
    public class Answer : BaseEntity
    {
        public AnswerValidity Validity { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Text={Text}, Validity={Validity}";
        }
    }
}
