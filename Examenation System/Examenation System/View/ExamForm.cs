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
    public partial class ExamForm : Form, IExamView
    {
        public ExamForm()
        {
            InitializeComponent();
        }

        public bool Option1RadioButton => option1RadioButton.Checked;

        public bool Option2RadioButton => option2RadioButton.Checked;

        public bool Option3RadioButton => option3RadioButton.Checked;

        public bool Option4RadioButton => option4RadioButton.Checked;

        public event Action Finish;
        public event Action Next;
        public event Action Last;

        public void UpdateExamForm(Exam exam)
        {
            questionLabel.Text = exam.Question;
            option1Label.Text = exam.Option1;
            option2Label.Text = exam.Option2;
            option3Label.Text = exam.Option3;
            option4Label.Text = exam.Option4;

            

        }

        public void UpdateSelectOption(int myAnsewer)
        {
            if (myAnsewer == 0)
            {
                option1RadioButton.Checked = false;
                option2RadioButton.Checked = false;
                option3RadioButton.Checked = false;
                option4RadioButton.Checked = false;

            }
            if (myAnsewer == 1)
            {
                option1RadioButton.Checked = true;
            }
            if (myAnsewer == 2)
            {
                option2RadioButton.Checked = true;
            }
            if (myAnsewer == 3)
            {
                option3RadioButton.Checked = true;
            }
            if (myAnsewer == 4)
            {
                option4RadioButton.Checked = true;
            }
        }

        public int GetChooseRadioButton ()
        {
            if (option1RadioButton.Checked)
            {
                return 1;
            }
            else if (option2RadioButton.Checked)
            {
                return 2;
            }
            else if (option3RadioButton.Checked)
            {
                return 3;
            }
            else if (option4RadioButton.Checked)
            {
                return 4;
            }

            return 0;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            
            Last?.Invoke();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            Next?.Invoke();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            Finish?.Invoke();
            this.Close();
        }

       
    }
}
