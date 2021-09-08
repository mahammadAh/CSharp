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
    public partial class StudentForm : Form,IStudentView
    {

        int SelectIndex;
  
        public StudentForm()
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

        public void UpdateInformationBox(UserData userData)
        {
            nameLabel.Text = userData.Name;
            surnameLabel.Text = userData.Surname;
            statusLabel.Text = userData.Status;
            groupLabel.Text = userData.Group;
           
        }

        public void UpdateMarksWorkListBox(UserData userData)
        {
            workListBox.Items.Clear();
            foreach (var item in userData.MarkList)
            {
                workListBox.Items.Add(item.ToString());
            }
        }

        public event Action Exam;
        public event Action Marks;
        private void ElemetsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = ElemetsListBox.SelectedIndex;
            switch (select)
            {
                case 0:
                    Exam?.Invoke();
                    break;
                case 1:
                    Marks?.Invoke();
                    break;
            }
        }

        public int GetSellectIndex()
        {
            return SelectIndex;
        }

        public event Action StartTest;
     

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void workListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ElemetsListBox.SelectedIndex == 0)

            {
                SelectIndex = workListBox.SelectedIndex;
                StartTest?.Invoke();
            }

        }
    }
}
