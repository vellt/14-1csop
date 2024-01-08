using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKvizApp.Models
{
    public class Question : BaseEntity
    {
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
