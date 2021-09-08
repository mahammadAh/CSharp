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
    class ExamEditionPresenter
    {
       private IExamEditionView  examEdition;
       private IExamDataRepository examData;
       private int examIndex;
       private int testIndex;
        private bool check = true;
        public ExamEditionPresenter(IExamEditionView examEdition ,IExamDataRepository examData ,int index)
        {
            this.examEdition = examEdition;
            this.examData = examData;
            this.examIndex = index;
            this.examEdition.Save += Save;
        }

        public ExamEditionPresenter(IExamEditionView examEdition, IExamDataRepository examData, int examIndex , int simple)
        {
            this.examEdition = examEdition;
            this.examData = examData;
            this.examIndex = examIndex;
            this.examEdition.Save += Save;
            this.examEdition.UpdateExamForm(examData.GetAllTasks()[examIndex].Quetion[0]);
            check = false;
            this.testIndex = 0;
            this.examEdition.Next += Next;
            this.examEdition.Last += Last;

        }

        public void Save ()
        {
            if (check)
            {
                var test = new Exam();

                test.Question = examEdition.Question;
                test.Option1 = examEdition.Option1;
                test.Option2 = examEdition.Option2;
                test.Option3 = examEdition.Option3;
                test.Option4 = examEdition.Option4;

                if (examEdition.Option1RadioButton)
                {
                    test.Ansewer = 1;
                }

                if (examEdition.Option2RadioButton)
                {
                    test.Ansewer = 2;
                }

                if (examEdition.Option3RadioButton)
                {
                    test.Ansewer = 3;
                }

                if (examEdition.Option4RadioButton)
                {
                    test.Ansewer = 4;
                }



                examData.AddTest(test, examIndex);
            }


            else
            {
                var test = new Exam();
                test.Question = examEdition.Question;
                test.Option1 = examEdition.Option1;
                test.Option2 = examEdition.Option2;
                test.Option3 = examEdition.Option3;
                test.Option4 = examEdition.Option4;

                if ( examEdition.Option1RadioButton)
                {
                    test.Ansewer = 1;
                }
               else if (examEdition.Option2RadioButton)
                {
                    test.Ansewer = 2;
                }
                else if (examEdition.Option3RadioButton)
                {
                    test.Ansewer = 3;
                }
                else if (examEdition.Option4RadioButton)
                {
                    test.Ansewer = 4;
                }

                examData.RemoveTest(examIndex, testIndex);
                examData.AddTestByIndex(test, examIndex, testIndex);

            }


        }

        public void Next ()
        {
            if (testIndex< examData.GetAllTasks()[examIndex].Quetion.Count-1)
            {
                testIndex++;
                examEdition.UpdateExamForm(examData.GetAllTasks()[examIndex].Quetion[testIndex]);

            }

        }


        public void Last()
        {
            if (testIndex > 0)
            {
                testIndex--;
                examEdition.UpdateExamForm(examData.GetAllTasks()[examIndex].Quetion[testIndex]);
            }
        }
    }
}
