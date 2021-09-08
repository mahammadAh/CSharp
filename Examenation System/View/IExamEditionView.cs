using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IExamEditionView
    {
        string Question { get; }

        string Option1 { get; }

        string Option2 { get; }

        string Option3 { get; }

        string Option4 { get; }

        bool Option1RadioButton { get; }
        bool Option2RadioButton { get; }
        bool Option3RadioButton { get; }
        bool Option4RadioButton { get; }

        void UpdateExamForm(Exam exam);

        

        event Action Save;

        event Action Next;

        event Action Last;

    }
}
