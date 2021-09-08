using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IStudentView
    {
        
        void UpdateInformationBox(UserData userData);
        void UpdateExamsWorkListBox(List<ExamData> examData);
        void UpdateMarksWorkListBox(UserData userData);
       
        int GetSellectIndex();
        event Action Exam;
        event Action Marks;
        event Action StartTest;
    }
}
