using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace BDO_Grind_Tracker
{
    public partial class MainForm : Form
    {
        private Timer timer;
        private const int timerInterval = 1000;
        private int elapsedTime;
        public static Queue<string> TextData { get; set; }
        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
            AttachListeners();
        }

        private void EnterStringForm(string str)
        {
            StringEntry entry = new StringEntry(str);
            entry.SetDesktopLocation(this.Left + 10, this.Top + 10);
            entry.ShowDialog();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DatabaseHandler.Load();
            RefreshTree();
            UpdateItemList();
            TextData = new Queue<string>();
        }
        private void AttachListeners()
        {
            zoneView.AfterSelect += ZoneView_AfterSelect;
            zoneView.NodeMouseClick += (sender, args) => zoneView.SelectedNode = args.Node;
            zoneView.MouseDown += ZoneView_MouseDown;
            zoneView.MouseLeave += ZoneView_MouseLeave;
            treeViewContext.ItemClicked += TreeViewContext_ItemClicked;
            itemPane.DoubleClick += ItemPane_DoubleClick;
        }

        //---Timer---
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = timerInterval;
            timer.Tick += new EventHandler(OnTimedEvent);
        }
        private void OnTimedEvent(Object source, EventArgs e)
        {
            elapsedTime++;
            UpdateTimerDisplay();
        }
        private void UpdateTimerDisplay()
        {
            TimeSpan result = TimeSpan.FromSeconds(elapsedTime);
            timerDisplay.Text = result.ToString("hh':'mm':'ss");
        }
        private void start_Click(object sender, EventArgs e)
        {
            if(zoneView.SelectedNode?.Parent == null)
            {
                MessageBox.Show("Select a Rotation", "No Rotation Selected",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            elapsedTime = 0;
            UpdateTimerDisplay();
            timer.Enabled = true;

            start.Enabled = false;
            pause.Enabled = true;
            stop.Enabled = true;
            zonesPanel.Enabled = false;
        }
        private void pause_Click(object sender, EventArgs e) => timer.Enabled = !timer.Enabled;
        private void stop_Click(object sender, EventArgs e)
        {
            timer.Stop();

            start.Enabled = true;
            pause.Enabled = false;
            stop.Enabled = false;

            SaveSession();
            zonesPanel.Enabled = true;
        }

        //---Session---
        private void SaveSession()
        {
            Session session = new Session();
            session.duration = TimeSpan.FromSeconds(elapsedTime).ToString();
            session.rotation = zoneView.SelectedNode;
            List<Drop> drops = new List<Drop>();

            foreach(ListViewItem item in itemPane.Items)
            {
                EnterStringForm(item.Text);
                Drop drop = new Drop();
                drop.name = item.Text;
                drop.amount = TextData.Dequeue();
                drops.Add(drop);
            }

            DatabaseHandler.SaveSession(session, drops);
            UpdateItemList();
        }

        //---MenuStrip---
        private void MenuClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "sessionViewer":
                    LoadSessionViewer();
                    break;
            }
        }

        private void LoadSessionViewer()
        {
            SessionView sessionView = new SessionView(zoneView.SelectedNode);
            sessionView.SetDesktopLocation(this.Left + 10, this.Top + 10);
            sessionView.ShowDialog();
        }

        private void DataMenuClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "createDB":
                    DatabaseHandler.Load();
                    break;
                case "clearDB":
                    DatabaseHandler.Delete();
                    RefreshTree();
                    break;
                case "fillDB":
                    Test.TestData.FillData();
                    RefreshTree();
                    break;
            }
        }

        //---Zone Panel---
        private void newZone_Click(object sender, EventArgs e) => AddLocation();
        private void newRotation_Click(object sender, EventArgs e) => AddLocation();
        public void RefreshTree()
        {
            zoneView.Nodes.Clear();
            zoneView.Nodes.AddRange(DatabaseHandler.LoadLocations());
        }
        private void AddLocation()
        {
            TreeNode node = zoneView.SelectedNode;

            if (node == null)
                EnterStringForm("Zone");
            else
                EnterStringForm("Rotation");

            if (TextData.Count == 1)
            {
                TreeNode temp = new TreeNode(TextData.Dequeue());

                if (node != null)
                {
                    if (node.Parent == null)
                        node.Nodes.Add(temp);
                    else
                        node.Parent.Nodes.Add(temp);
                }

                node = temp;

                DatabaseHandler.AddLocation(node);
            }
            RefreshTree();
        }
        private void ZoneView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
                start.Enabled = true;
            else
                start.Enabled = false;
            UpdateItemList();
        }
        private void ZoneView_MouseDown(object sender, MouseEventArgs e)
        {
            zoneView.SelectedNode = null;
        }
        private void ZoneView_MouseLeave(object sender, EventArgs e)
        {
            if (zoneView.SelectedNode == null)
            {
                UpdateItemList();
            }
        }

        //---Zone Context Events
        private void TreeViewContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "treeAddZone":
                    AddLocation();
                    break;
                case "treeAddRotation":
                    AddLocation();
                    break;
                case "treeDelete":
                    DeleteFromZone();
                    break;
            }
        }
        private void DeleteFromZone()
        {
            TreeNode node = zoneView.SelectedNode;

            if (node == null)
                return;

            DatabaseHandler.DeleteLocation(node);

            RefreshTree();
        }

        //---Item Panel---
        private void ItemPane_DoubleClick(object sender, EventArgs e)
        {
            UpdatePrice(itemPane.SelectedItems[0]);
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            string zone;

            if (zoneView.SelectedNode == null)
            {
                ItemEntry entry = new ItemEntry();
                entry.SetDesktopLocation(this.Left + 10, this.Top + 10);
                entry.ShowDialog();
                return;
            }

            if (zoneView.SelectedNode.Parent == null)
                zone = zoneView.SelectedNode.Text;
            else
                zone = zoneView.SelectedNode.Parent.Text;

            ItemList itemList = new ItemList(zone);
            itemList.SetDesktopLocation(this.Left + 10, this.Top + 10);
            itemList.ShowDialog();

            UpdateItemList();
        }
        private void UpdateItemList()
        {
            TreeNode node = zoneView.SelectedNode;

            List<Drop> drops = new List<Drop>();
            itemPane.Items.Clear();

            if (node == null)
                drops = DatabaseHandler.GetAllDrops();
            else
                drops = DatabaseHandler.GetDrops(node);

            foreach (Drop drop in drops)
            {
                ListViewItem item = new ListViewItem(drop.name);
                int value;

                if (drop.market != "0")
                {
                    value = Int32.Parse(drop.market);
                    item.SubItems.Add(String.Format("{0:n0}", value));
                }
                else
                    item.SubItems.Add("-");
                if (drop.vendor != "0")
                {
                    value = Int32.Parse(drop.vendor);
                    item.SubItems.Add(String.Format("{0:n0}",value));
                }
                else
                    item.SubItems.Add("-");
                if (drop.amount != "")
                {
                    value = Int32.Parse(drop.amount);
                    item.SubItems.Add(String.Format("{0:n0}", value));
                }
                else
                    item.SubItems.Add("-");

                itemPane.Items.Add(item);
            }

            UpdateTimeDisplay();
        }
        private void UpdatePrice(ListViewItem item)
        {
            ItemData itemToUpdate = new ItemData();

            itemToUpdate.name = item.SubItems[0].Text;
            itemToUpdate.market = item.SubItems[1].Text == "-" ? "0" : item.SubItems[1].Text;
            itemToUpdate.vendor = item.SubItems[2].Text == "-" ? "0" : item.SubItems[2].Text;

            PriceUpdate update = new PriceUpdate(itemToUpdate.name);
            update.SetDesktopLocation(this.Left + 10, this.Top + 10);
            update.ShowDialog();

            if (TextData.Count == 0)
                return;

            if (TextData.Peek() != "")
                itemToUpdate.market = TextData.Dequeue();
            else
                TextData.Dequeue();
            if (TextData.Peek() != "")
                itemToUpdate.vendor = TextData.Dequeue();
            else
                TextData.Dequeue();

            itemToUpdate.market = itemToUpdate.market.Replace(",", "");
            itemToUpdate.vendor = itemToUpdate.vendor.Replace(",", "");

            DatabaseHandler.UpdatePrice(itemToUpdate);
            UpdateItemList();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            if(itemPane.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in itemPane.SelectedItems)
                {
                    DatabaseHandler.DeleteItem(new ItemData(item.Text));
                }

                UpdateItemList();
            }
        }

        //---Silver Display---
        private void UpdateTimeDisplay()
        {
            totalTimeDisplay.Text = DatabaseHandler.GetTotalTime(zoneView.SelectedNode);
            UpdateSilverDisplay();
        }
        private void UpdateSilverDisplay()
        {
            int totalSilver = 0;

            foreach (ListViewItem item in itemPane.Items)
            {
                totalSilver += DatabaseHandler.GetMaxPrice(item.Text,zoneView.SelectedNode);
            }

            totalSilverDisplay.Text = String.Format("{0:n0}", totalSilver);

            UpdateSilverPerHourDisplay(totalSilver);
        }
        private void UpdateSilverPerHourDisplay(int silver)
        {
            TimeSpan time = TimeSpan.Parse(totalTimeDisplay.Text);

            double sph;

            if (time.TotalMilliseconds > 0)
                sph = silver / time.TotalHours;
            else
                sph = 0;

            silverPerHourDisplay.Text = String.Format("{0:n0}",sph);
        }
    }


}
