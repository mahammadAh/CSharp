using Examenation_System.Model;
using Examenation_System.Presenter;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examenation_System
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
      

       static IExamDataRepository examData;
       static IUserDataRepository userData;
   
        static EnterForm enterView;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            enterView = new EnterForm();
            examData = new ExamDataJsonRepository();
            userData = new UserDataJsonRepository();

            EnterPresenter enterPresenter = new EnterPresenter(enterView, userData);

            Application.Run(enterView);
        
        
      }

        public static void EnterAdministration(UserData myUserData)
        {
            var dialog = new AdministratorForm();
            var dialogPresenter = new AdministratorPresenter(dialog, userData, examData , myUserData);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                EnterPresenter enterPresenter = new EnterPresenter(enterView, userData);
            }
        }

        public static void EnterStudent(UserData myUserData)
        {
            var dialog = new StudentForm();
            var dialogPresenter = new StudentPresenter(dialog, examData, myUserData);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                EnterPresenter enterPresenter = new EnterPresenter(enterView, userData);
            }
        }

        public static void EnterTeacher(UserData myUserData)
        {
            var dialog = new TeacherForm();
            var dialogPresenter = new TeacherPresenter(dialog, userData, examData, myUserData);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                EnterPresenter enterPresenter = new EnterPresenter(enterView, userData);
            }
        }

        public static void AddUser(UserData myUserData)
        {
            var dialog = new UserEditionForm();
            var dialogPresenter = new UserEditionPresenter(dialog, userData);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var administratorDialog = new AdministratorForm();
                var administratorDialogPresenter = new AdministratorPresenter(administratorDialog, userData, examData, myUserData);
            }
        }

        public static void CreateNewTestBlock(UserData myUserData)
        {
            var dialog = new CreatNewTestBlockForm();
            var dialogPresenter = new CreatNewTestBlockFormPresenter(dialog, examData);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var teacherDialog = new TeacherForm();
                var teacherDialogPresenter = new TeacherPresenter(teacherDialog, userData, examData, myUserData);
            }
        }

        public static void AddNewTest(UserData myUserData , int index)
        {
            var dialog = new ExamEditionForm();
            var dialogPresenter = new ExamEditionPresenter(dialog, examData, index);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var teacherDialog = new TeacherForm();
                var teacherDialogPresenter = new TeacherPresenter(teacherDialog, userData, examData, myUserData);
            }
        }

        public static void StartTest (UserData myUserData , int index  )
        {
            var dialog = new ExamForm();
            var dialogPrsenter = new ExamPresenter(dialog, examData,userData,myUserData, index);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var studentDialog = new StudentForm();
                var studentDialogPresenter = new StudentPresenter(studentDialog, examData, myUserData);
            }
        }

        public static void EditSelectUser(UserData myUserData, int index)
        {
            var dialog = new UserEditionForm();
            var dialogPresenter = new UserEditionPresenter(dialog, userData , index);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var administratorDialog = new AdministratorForm();
                var administratorDialogPresenter = new AdministratorPresenter(administratorDialog, userData, examData, myUserData);
            }
        }

        public static void EditExam(UserData myUserData, int index)
        {
            var dialog = new ExamEditionForm();
            var dialogPresenter = new ExamEditionPresenter(dialog, examData, index, 0);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var teacherDialog = new TeacherForm();
                var teacherDialogPresenter = new TeacherPresenter(teacherDialog, userData, examData, myUserData);
            }
        }
    }
}
