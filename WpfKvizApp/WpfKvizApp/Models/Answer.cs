using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKvizApp.Models
{
    public class Answer : BaseEntity
    {
        public AnswerValidity Validity { get; set; }
        public string ImageSource { get; set; }
    }
}
