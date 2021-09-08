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
    class ExamPresenter
    {

        private IExamView examEdition;
        private IExamDataRepository examData;
        private IUserDataRepository userData;
        private int index;
        private int questionIndex = 0;
        
        List<int> ansewerTable = new List<int>();
        private int userIndex;
        public ExamPresenter(IExamView examEdition, IExamDataRepository examData, IUserDataRepository userData,UserData myUserData,  int index )
        {
            this.examEdition = examEdition;
            this.examData = examData;
            this.index = index;
            this.examEdition.Last += Last;
            this.examEdition.Next += Next;
            this.examEdition.Finish += Finish;
            this.userData = userData;
            for (int i=0; i< userData.GetAllTasks().Count; i++)
            {
                if (userData.GetAllTasks()[i].Login == myUserData.Login)
                {
                    this.userIndex = i;
                    break;
                }
            }
            
            
            this.examEdition.UpdateExamForm(examData.GetAllTasks()[index].Quetion[0]);
           
        }

        public void Last ()
        {
            if (questionIndex>0)
            {
                if (questionIndex == examData.GetAllTasks()[index].Quetion.Count-1)
                {
                    ansewerTable.Add(examEdition.GetChooseRadioButton());
                }

                examData.GetAllTasks()[index].Quetion[questionIndex].myAnsewer = examEdition.GetChooseRadioButton();
                
                ansewerTable[questionIndex] = examEdition.GetChooseRadioButton();
                questionIndex--;
                examEdition.UpdateExamForm(examData.GetAllTasks()[index].Quetion[questionIndex]);
                if (ansewerTable[questionIndex] == null) {

                    examEdition.UpdateSelectOption(0);
                }
                else examEdition.UpdateSelectOption(ansewerTable[questionIndex]);
            }
        }

        public void Next()
        {
            if (questionIndex< examData.GetAllTasks()[index].Quetion.Count-1)
            {
                examData.GetAllTasks()[index].Quetion[questionIndex].myAnsewer = examEdition.GetChooseRadioButton();          
                
                if (questionIndex >= ansewerTable.Count - 1)
                {
                    ansewerTable.Add(examEdition.GetChooseRadioButton());
                }
                else ansewerTable[questionIndex] = examEdition.GetChooseRadioButton();

                questionIndex++;
                examEdition.UpdateExamForm(examData.GetAllTasks()[index].Quetion[questionIndex]);
                if (questionIndex > ansewerTable.Count - 1)
                {
                    examEdition.UpdateSelectOption(0);
                }
                else examEdition.UpdateSelectOption(ansewerTable[questionIndex]);
            }
        }

        public void Finish()
        {
            if (ansewerTable.Count < examData.GetAllTasks()[index].Quetion.Count)
            {
                ansewerTable.Add(examEdition.GetChooseRadioButton());
            }
            int score = 0;
            for (int i=0; i< ansewerTable.Count; i++)
            {
                if (examData.GetAllTasks()[index].Quetion[i].Ansewer.ToString() == ansewerTable[i].ToString() )
                {
                    score++;
                }
            }

            //myUserData.MarkList.Add(examData.GetAllTasks()[index].Name + ": " + score.ToString() + "/" + examData.GetAllTasks()[index].Quetion.Count+ "\t" + DateTime.Now);
            string examResult = examData.GetAllTasks()[index].Name + ": " + score.ToString() + "/" + examData.GetAllTasks()[index].Quetion.Count + "\t" + DateTime.Now;
            userData.AddMarkInList(examResult,userIndex);
        }
    }
}
