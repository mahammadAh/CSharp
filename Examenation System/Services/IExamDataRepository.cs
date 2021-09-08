using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Services
{
    interface IExamDataRepository
    {
        List<ExamData> GetAllTasks();
        void AddExamBox(ExamData exam);

        void RemoveExamBox(int index);

        void AddTest(Exam exam , int examIndex);

        void RemoveTest(int examIndex , int TestIndex);

        void AddTestByIndex(Exam exam, int examIndex, int testIndex);
    }
}
