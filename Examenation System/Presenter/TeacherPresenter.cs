using Examenation_System.Model;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Presenter
{
    class TeacherPresenter
    {

        private ITeacherView teacher;
        private IUserDataRepository userData;
        private IExamDataRepository examData;
        private UserData myUserData;
        public TeacherPresenter(ITeacherView student, IUserDataRepository userData, IExamDataRepository examData, UserData myUserData)
        {
            this.teacher = student;
            this.userData = userData;
            this.examData = examData;
            this.myUserData = myUserData;
            this.teacher.UpdateInformationBox(myUserData);
            this.teacher.Exams += Exams;
            this.teacher.CreatNewTestBlock += CreatNewTestBlock;
            this.teacher.AddNewTest += AddNewTest;
            this.teacher.EditExam += EditExam;
            this.teacher.DeleteExam += DeleteExam;
            this.teacher.DeleteTest += DeleteTest;
            this.teacher.DeleteSelectedTest += DeleteSelectedTest;
        }

        public void Exams()
        {
            teacher.UpdateExamsWorkListBox(examData.GetAllTasks());
        }

        public void CreatNewTestBlock()
        {
            Program.CreateNewTestBlock(myUserData);
        }

        public void AddNewTest()
        {
            Program.AddNewTest(myUserData, teacher.GetSellectIndex());
        }

        public void EditExam()
        {
            Program.EditExam(myUserData, teacher.GetSellectIndex());
        }

        public void DeleteExam()
        {
            examData.RemoveExamBox(teacher.GetSellectIndex());
        }

        public void DeleteSelectedTest()
        {
            teacher.UpdateDeletTestWorkListBox(examData.GetAllTasks()[teacher.GetSellectIndex()]);
        }

        public void DeleteTest()
        {
            examData.RemoveTest(teacher.GetSellectIndex(), teacher.GetSellectTestIndex());
        }
    }
}
