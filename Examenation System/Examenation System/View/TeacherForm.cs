using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examenation_System.View
{
    public partial class TeacherForm : Form, ITeacherView
    {

        int SelectIndex;
        int SelectTestIndex;
        bool check = true;
        public TeacherForm()
        {
            InitializeComponent();
        }

        public void UpdateExamsWorkListBox(List<ExamData> examDataList)
        {
            workListBox.Items.Clear();
            foreach (var item in examDataList)
            {
                workListBox.Items.Add(item.ToString());
            }
        }

        public void UpdateDeletTestWorkListBox(ExamData examData)
        {
            workListBox.Items.Clear();
            foreach (var item in examData.Quetion)
            {
                workListBox.Items.Add(item.Question);
            }
        }

        public void UpdateInformationBox(UserData userData)
        {
            nameLabel.Text = userData.Name;
            surnameLabel.Text = userData.Surname;
            statusLabel.Text = userData.Status;
        }

        public event Action Exams;
        public event Action CreatNewTestBlock;

       
        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = elementsListBox.SelectedIndex;
            switch (select)
            {
                
                case 0:
                    Exams?.Invoke();
                    break;

                case 1:
                    CreatNewTestBlock?.Invoke();
                    break;

                case 2:
                    Exams?.Invoke();
                    break;
                case 3:
                    Exams?.Invoke();
                    break;
                case 4:
                    check = true;
                    Exams?.Invoke();
                    break;



            }
        }

       public event Action AddNewTest;

        public event Action EditExam;

        public event Action DeleteExam;
        public event Action DeleteTest;
        public int GetSellectIndex ()
        {
            return SelectIndex;
        }

        public int GetSellectTestIndex()
        {
            return SelectTestIndex;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void workListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

            if (elementsListBox.SelectedIndex == 0)
            {
                SelectIndex = workListBox.SelectedIndex;
                AddNewTest?.Invoke();

            }


            if (elementsListBox.SelectedIndex == 2)
            {
                SelectIndex = workListBox.SelectedIndex;
                EditExam?.Invoke();

            }

            if (elementsListBox.SelectedIndex == 3)
            {
                SelectIndex = workListBox.SelectedIndex;
                DeleteExam?.Invoke();

            }

            if (elementsListBox.SelectedIndex == 4 && check)
            {
               
                SelectIndex = workListBox.SelectedIndex;
                DeleteSelectedTest?.Invoke();
                check = false;
            }
            else
            {

                SelectTestIndex = workListBox.SelectedIndex;
                DeleteTest?.Invoke();
            }

        }

        public event Action DeleteSelectedTest;

     
    }
}
