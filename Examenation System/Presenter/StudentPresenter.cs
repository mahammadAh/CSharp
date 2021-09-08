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
    class StudentPresenter
    {
        private IStudentView student;   
        private IExamDataRepository examData;
        private UserData myUserData;
        public StudentPresenter(IStudentView student,  IExamDataRepository examData, UserData myUserData)
        {
            this.student = student;   
            this.examData = examData;
            this.student.UpdateInformationBox(myUserData);
            this.myUserData = myUserData;
            this.student.Exam += Exams;
            this.student.Marks += Marks;
            this.student.StartTest += StartTest;
        }

        public void Exams()
        {
            student.UpdateExamsWorkListBox(examData.GetAllTasks());
        }

        public void Marks()
        {
            student.UpdateMarksWorkListBox(myUserData);
        }

        public void StartTest()
        {
            Program.StartTest(myUserData, student.GetSellectIndex());
        }
    }
}
