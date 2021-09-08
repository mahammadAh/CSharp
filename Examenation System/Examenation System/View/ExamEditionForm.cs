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
    public partial class ExamEditionForm : Form, IExamEditionView
    {
        public ExamEditionForm()
        {
            InitializeComponent();
        }

        public string Question => questionTextBox.Text;

        public string Option1 => option1TextBox.Text;

        public string Option2 => option2TextBox.Text;

        public string Option3 => option3TextBox.Text;

        public string Option4 => option4TextBox.Text;

        public bool Option1RadioButton => option1RadioButton.Checked;

        public bool Option2RadioButton => option2RadioButton.Checked;

        public bool Option3RadioButton => option3RadioButton.Checked;

        public bool Option4RadioButton => option4RadioButton.Checked;

        public event Action Save;

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save?.Invoke();
            questionTextBox.Clear();
            option1TextBox.Clear();
            option2TextBox.Clear();
            option3TextBox.Clear();
            option4TextBox.Clear();
        }

        public void UpdateExamForm(Exam exam)
        {
            questionTextBox.Text = exam.Question;
            option1TextBox.Text = exam.Option1;
            option2TextBox.Text = exam.Option2;
            option3TextBox.Text = exam.Option3;
            option4TextBox.Text = exam.Option4;

            if (exam.myAnsewer == 0)
            {
                option1RadioButton.Checked = false;
                option2RadioButton.Checked = false;
                option3RadioButton.Checked = false;
                option4RadioButton.Checked = false;

            }
            if (exam.myAnsewer == 1)
            {
                option1RadioButton.Checked = true;
            }
            if (exam.myAnsewer == 2)
            {
                option2RadioButton.Checked = true;
            }
            if (exam.myAnsewer == 3)
            {
                option3RadioButton.Checked = true;
            }
            if (exam.myAnsewer == 4)
            {
                option4RadioButton.Checked = true;
            }
        }


        private void closaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public event Action Next;
        public event Action Last;


        private void nextButton_Click(object sender, EventArgs e)
        {
            Next?.Invoke();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            Last?.Invoke();
        }

       
    }
}
