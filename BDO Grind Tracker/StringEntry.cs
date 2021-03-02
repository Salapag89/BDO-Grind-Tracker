using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDO_Grind_Tracker
{
    public partial class StringEntry : Form
    {
        private string text;
        public StringEntry(string str)
        {
            InitializeComponent();
            text = str;
            label.Text = str + " :";
        }

        public void SetLabel(string str) => label.Text = str;

        private void submit_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 1)
            {
                MainForm.TextData.Enqueue(textBox.Text);
                this.Close();
            }
            else
                MessageBox.Show("Please enter a name for the " + text + ".");
        }
    }
}
