using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BDO_Grind_Tracker
{
    public partial class ItemList : Form
    {
        private string zone;
        public ItemList(string str)
        {
            InitializeComponent();
            zone = str;
            zoneItemList.Text += zone;
            LoadItems();
        }

        private void LoadItems()
        {
            itemListView.Items.Clear();
            zoneItemView.Items.Clear();

            itemListView.Items.AddRange(DatabaseHandler.GetItems());
            List<Drop> drops = DatabaseHandler.GetDrops(new TreeNode(zone));
            foreach(Drop drop in drops)
            {
                zoneItemView.Items.Add(new ListViewItem(drop.name));
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in itemListView.SelectedItems)
            {
                DatabaseHandler.AddDrop(item.Text, zone);
            }

            LoadItems();
        }

        private void finish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ItemEntry entry = new ItemEntry();
            entry.SetDesktopLocation(this.Left + 10, this.Top + 10);
            entry.ShowDialog();

            LoadItems();
        }
    }
}