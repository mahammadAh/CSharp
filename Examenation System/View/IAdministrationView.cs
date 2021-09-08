using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IAdministrationView
    {
        event Action Users;

        event Action Exams;

        event Action AddUser;

        event Action EditSelectUser;

        event Action DeleteSelectUser;
        void UpdateInformationBox(UserData userData);
        void UpdateUsersWorkListBox(List<UserData> userDataList);
        void UpdateExamWorkListBox(List<ExamData> examDataList);
        int GetSelectUserIndex();
    }
}
