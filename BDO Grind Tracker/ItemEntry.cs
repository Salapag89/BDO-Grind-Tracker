using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDO_Grind_Tracker
{
    public partial class ItemEntry : Form
    {
        public ItemEntry()
        {
            InitializeComponent();
            catBox.Items.AddRange(Database.itemCat);
            catBox.SelectedIndex = 0;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (itemBox.Text == null)
            {
                MessageBox.Show("Enter item name.");
                return;
            }

            ItemData item = new ItemData();

            item.name = itemBox.Text;
            item.category = catBox.SelectedIndex.ToString();

            if (marketBox.Text == "")
                item.market = "0";
            else
                item.market = marketBox.Text;
            if (vendorBox.Text == "")
                item.vendor = "0";
            else
                item.vendor = vendorBox.Text;

            DatabaseHandler.AddItem(item);

            this.Close();

        }
    }
}
