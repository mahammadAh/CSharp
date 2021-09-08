using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface ITeacherView
    {
        void UpdateInformationBox(UserData userData);

        void UpdateExamsWorkListBox(List<ExamData> examDataList);

        int GetSellectIndex();

        int GetSellectTestIndex();

        void UpdateDeletTestWorkListBox(ExamData examData);



        event Action Exams;
        event Action CreatNewTestBlock;
        event Action AddNewTest;
        event Action EditExam;
        event Action DeleteExam;
        event Action DeleteTest;
        event Action DeleteSelectedTest;
    }
}
