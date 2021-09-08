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
    public partial class CreatNewTestBlockForm : Form, ICreateNewTestBlockForm
    {
        public CreatNewTestBlockForm()
        {
            InitializeComponent();
        }

        public string BLockName { get => nameTextBox.Text; }

        public event Action Add;

        private void addButton_Click(object sender, EventArgs e)
        {
            Add?.Invoke();
            nameTextBox.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
