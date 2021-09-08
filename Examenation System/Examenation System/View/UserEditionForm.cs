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

    public partial class UserEditionForm : Form,IUserEditionView
    {
        public UserEditionForm()
        {
            InitializeComponent();

            
        }

        public string UserName => nameTextBox.Text;
        
        public string Surname => surnameTextBox.Text;

        public string Group => groupTextBox.Text;

        public string Login => loginTextBox.Text;

        public string Password =>passwordTextBox.Text;

        public string RepeatPasword => repeatPaaswordTextBox.Text;

        public string Image => pictureBox1.Name;

        public bool Student => studentRadioButton.Checked;

        public bool Teacher => teacherRadioButton.Checked;

        public event Action Save;

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save?.Invoke();

            nameTextBox.Clear();
            surnameTextBox.Clear();
            groupTextBox.Clear();
            loginTextBox.Clear();
            passwordTextBox.Clear();
            repeatPaaswordTextBox.Clear();
            studentRadioButton.Checked = false;
            teacherRadioButton.Checked = false;

        }

        public void FillUserInformation(UserData myUserData)
        {
            nameTextBox.Text = myUserData.Name;

            surnameTextBox.Text = myUserData.Surname;

            groupTextBox.Text = myUserData.Group;

            loginTextBox.Text = myUserData.Login;

            passwordTextBox.Text = myUserData.Password;

            repeatPaaswordTextBox.Text = myUserData.Password;

            pictureBox1.Name = myUserData.Image;

            if (myUserData.Status == "Student")
            {
                studentRadioButton.Checked = true;
            }
            if (myUserData.Status == "Teacher")
            {
                teacherRadioButton.Checked = true;
            }
    }

        private void canelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
