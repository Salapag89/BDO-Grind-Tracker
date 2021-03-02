using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDO_Grind_Tracker
{
    public partial class SessionView : Form
    {
        TreeNode location;
        public SessionView(TreeNode node = null)
        {
            InitializeComponent();
            location = node;
            UpdateView();
        }

        private void UpdateView()
        {
            sessionListView.Items.Clear();

            List<Session> sessions = DatabaseHandler.LoadSessions(location);

            foreach(Session session in sessions)
            {
                ListViewItem item = new ListViewItem(session.date);
                item.SubItems.Add(session.duration);
                item.SubItems.Add(session.rotation.Parent.Text);
                item.SubItems.Add(session.rotation.Text);
                item.SubItems.Add(session.ap);
                item.SubItems.Add(session.scroll);
                item.SubItems.Add(session.agris);

                sessionListView.Items.Add(item);
            }
        }
        private void done_Click(object sender, EventArgs e) => this.Close();
        private void delete_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in sessionListView.SelectedItems)
            {
                DatabaseHandler.DeleteSession(item.Text);

                UpdateView();
            }
        }
    }
}
