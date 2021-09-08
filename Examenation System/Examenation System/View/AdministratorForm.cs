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
    public partial class AdministratorForm : Form , IAdministrationView
    {

        int getSelectUserIndex;
        public event Action Users;
        public event Action Exams;
        public event Action AddUser;
        public event Action DeleteSelectUser;
        public event Action EditSelectUser;
        public AdministratorForm()
        {
            InitializeComponent();
        }

      
        public void UpdateExamWorkListBox(List<ExamData> examDataList)
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
        }

   

        public void UpdateUsersWorkListBox(List<UserData> userDataList)
        {
            workListBox.Items.Clear();
            foreach (var item in userDataList)
            {
                workListBox.Items.Add(item.ToString());
            }
        }



       
        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = elementsListBox.SelectedIndex;
            switch (select)
            {
                case 0:
                    Users?.Invoke();
                    break;

                case 1:
                    Exams?.Invoke();
                    break;

                case 2:
                    AddUser?.Invoke();
                    break;
                case 3:
                    Users?.Invoke();
                    break;
                case 4:
                    Users?.Invoke();
                    break;
            }
        }

        

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       public int GetSelectUserIndex ()
        {
            return getSelectUserIndex;
        }



        private void workListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (elementsListBox.SelectedIndex==3)
            {
                getSelectUserIndex = workListBox.SelectedIndex;
                DeleteSelectUser?.Invoke();

            }

            if (elementsListBox.SelectedIndex==4)
            {
                getSelectUserIndex = workListBox.SelectedIndex;
                EditSelectUser?.Invoke();
            }
        }
    }
}
