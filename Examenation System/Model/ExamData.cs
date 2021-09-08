using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Model
{
    public class ExamData
    {
        public string Name { get; set; }

        public int ID { get; set; }
        public List<Exam> Quetion { get; set; }

        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
