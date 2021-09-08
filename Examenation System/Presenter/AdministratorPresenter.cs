using Examenation_System.Model;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examenation_System.Presenter
{
    class AdministratorPresenter
    {

        private IAdministrationView administration;
        private IUserDataRepository userData;
        private IExamDataRepository examData;
        UserData myUserData;
        public AdministratorPresenter (IAdministrationView administration,IUserDataRepository userData,IExamDataRepository examData ,UserData myUserData)
        {
            this.administration = administration;
            this.userData = userData;
            this.examData = examData;
            this.myUserData = myUserData;
            this.administration.UpdateInformationBox(myUserData);
            this.administration.Users += Users;
            this.administration.Exams += Exams;
            this.administration.AddUser += AddUser;
            this.administration.DeleteSelectUser += DeleteSelectUser;
            this.administration.EditSelectUser += EditSelectUser;
        }

        public void Users ()
        {
            administration.UpdateUsersWorkListBox(userData.GetAllTasks());
        }

        public void Exams()
        {
            administration.UpdateExamWorkListBox(examData.GetAllTasks());
        }

        public void AddUser()
        {
            Program.AddUser(myUserData);
        }

      

        public void DeleteSelectUser()
        {
            if (administration.GetSelectUserIndex() > 0)
            {
                userData.RemoveUser(administration.GetSelectUserIndex());
                administration.UpdateUsersWorkListBox(userData.GetAllTasks());

            }
            else MessageBox.Show("You can't delete the Admin");
        }


        public void EditSelectUser()
        {
            Program.EditSelectUser(myUserData, administration.GetSelectUserIndex());
        }

    }
}
