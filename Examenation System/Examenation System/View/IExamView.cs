using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IExamView
    {


        void UpdateExamForm(Exam exam);

        void UpdateSelectOption(int myAnsewer);
        bool Option1RadioButton { get; }

        bool Option2RadioButton { get; }

        bool Option3RadioButton { get; }

        bool Option4RadioButton { get; }

        event Action Finish;
        event Action Next;
        event Action Last;

        int GetChooseRadioButton();
    }
}
