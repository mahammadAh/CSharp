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
    public partial class EnterForm : Form , IEnterView
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        public string Login => LoginTextBox.Text;

        public string Password => PasswordTextBox.Text;

        
        public event Action Enter;

        private void enterButton_Click(object sender, EventArgs e)
        {
            Enter?.Invoke();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
