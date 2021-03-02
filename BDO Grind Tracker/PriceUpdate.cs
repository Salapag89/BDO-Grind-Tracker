using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDO_Grind_Tracker
{
    public partial class PriceUpdate : Form
    {
        public PriceUpdate(string str)
        {
            InitializeComponent();
            this.Text = str;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (marketBox.Text != "")
                MainForm.TextData.Enqueue(marketBox.Text);
            else
                MainForm.TextData.Enqueue("");

            if(vendorBox.Text != "")
                MainForm.TextData.Enqueue(vendorBox.Text);
            else
                MainForm.TextData.Enqueue("");


            this.Close();

        }
    }
}
