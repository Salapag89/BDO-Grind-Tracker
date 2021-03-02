
namespace BDO_Grind_Tracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test",
            "1,000,000",
            "20,000",
            "100"}, -1);
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerDisplay = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.sessionPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sessionViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTab = new System.Windows.Forms.ToolStripMenuItem();
            this.createDB = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDB = new System.Windows.Forms.ToolStripMenuItem();
            this.characterPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kutumBox = new System.Windows.Forms.CheckBox();
            this.apLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.zonesPanel = new System.Windows.Forms.Panel();
            this.silverPerHourDisplay = new System.Windows.Forms.Label();
            this.totalSilverDisplay = new System.Windows.Forms.Label();
            this.silverPerHourLabel = new System.Windows.Forms.Label();
            this.totalSilverLabel = new System.Windows.Forms.Label();
            this.totalTimeDisplay = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.delItem = new System.Windows.Forms.Button();
            this.itemPane = new System.Windows.Forms.ListView();
            this.itemCol = new System.Windows.Forms.ColumnHeader();
            this.market = new System.Windows.Forms.ColumnHeader();
            this.vendor = new System.Windows.Forms.ColumnHeader();
            this.amountCol = new System.Windows.Forms.ColumnHeader();
            this.addItem = new System.Windows.Forms.Button();
            this.newRotation = new System.Windows.Forms.Button();
            this.newZone = new System.Windows.Forms.Button();
            this.zoneView = new System.Windows.Forms.TreeView();
            this.treeViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeAddZone = new System.Windows.Forms.ToolStripMenuItem();
            this.treeAddRotation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.treeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.characterPanel.SuspendLayout();
            this.zonesPanel.SuspendLayout();
            this.treeViewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(12, 15);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(36, 15);
            this.timerLabel.TabIndex = 1;
            this.timerLabel.Text = "Time:";
            // 
            // timerDisplay
            // 
            this.timerDisplay.AutoSize = true;
            this.timerDisplay.Location = new System.Drawing.Point(61, 15);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.Size = new System.Drawing.Size(49, 15);
            this.timerDisplay.TabIndex = 2;
            this.timerDisplay.Text = "00:00:00";
            // 
            // start
            // 
            this.start.Enabled = false;
            this.start.Location = new System.Drawing.Point(16, 33);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(25, 24);
            this.start.TabIndex = 3;
            this.start.Text = "▶";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // pause
            // 
            this.pause.Enabled = false;
            this.pause.Location = new System.Drawing.Point(47, 34);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(25, 24);
            this.pause.TabIndex = 4;
            this.pause.Text = "❚❚";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(78, 34);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(25, 24);
            this.stop.TabIndex = 5;
            this.stop.Text = "■";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // sessionPanel
            // 
            this.sessionPanel.Controls.Add(this.timerLabel);
            this.sessionPanel.Controls.Add(this.stop);
            this.sessionPanel.Controls.Add(this.timerDisplay);
            this.sessionPanel.Controls.Add(this.pause);
            this.sessionPanel.Controls.Add(this.start);
            this.sessionPanel.Location = new System.Drawing.Point(10, 35);
            this.sessionPanel.Name = "sessionPanel";
            this.sessionPanel.Size = new System.Drawing.Size(128, 71);
            this.sessionPanel.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionViewer,
            this.dataTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuClicked);
            // 
            // sessionViewer
            // 
            this.sessionViewer.Name = "sessionViewer";
            this.sessionViewer.Size = new System.Drawing.Size(63, 20);
            this.sessionViewer.Text = "Sessions";
            // 
            // dataTab
            // 
            this.dataTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDB,
            this.clearDB});
            this.dataTab.Name = "dataTab";
            this.dataTab.Size = new System.Drawing.Size(43, 20);
            this.dataTab.Text = "Data";
            this.dataTab.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DataMenuClicked);
            // 
            // createDB
            // 
            this.createDB.Name = "createDB";
            this.createDB.Size = new System.Drawing.Size(126, 22);
            this.createDB.Text = "Create DB";
            // 
            // clearDB
            // 
            this.clearDB.Name = "clearDB";
            this.clearDB.Size = new System.Drawing.Size(126, 22);
            this.clearDB.Text = "Clear DB";
            // 
            // characterPanel
            // 
            this.characterPanel.Controls.Add(this.textBox2);
            this.characterPanel.Controls.Add(this.textBox1);
            this.characterPanel.Controls.Add(this.kutumBox);
            this.characterPanel.Controls.Add(this.apLabel);
            this.characterPanel.Controls.Add(this.nameLabel);
            this.characterPanel.Location = new System.Drawing.Point(144, 35);
            this.characterPanel.Name = "characterPanel";
            this.characterPanel.Size = new System.Drawing.Size(234, 71);
            this.characterPanel.TabIndex = 14;
            this.characterPanel.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 3;
            // 
            // kutumBox
            // 
            this.kutumBox.AutoSize = true;
            this.kutumBox.Location = new System.Drawing.Point(171, 42);
            this.kutumBox.Name = "kutumBox";
            this.kutumBox.Size = new System.Drawing.Size(62, 19);
            this.kutumBox.TabIndex = 2;
            this.kutumBox.Text = "Kutum";
            this.kutumBox.UseVisualStyleBackColor = true;
            // 
            // apLabel
            // 
            this.apLabel.AutoSize = true;
            this.apLabel.Location = new System.Drawing.Point(12, 42);
            this.apLabel.Name = "apLabel";
            this.apLabel.Size = new System.Drawing.Size(28, 15);
            this.apLabel.TabIndex = 1;
            this.apLabel.Text = "AP :";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(48, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name : ";
            // 
            // zonesPanel
            // 
            this.zonesPanel.Controls.Add(this.silverPerHourDisplay);
            this.zonesPanel.Controls.Add(this.totalSilverDisplay);
            this.zonesPanel.Controls.Add(this.silverPerHourLabel);
            this.zonesPanel.Controls.Add(this.totalSilverLabel);
            this.zonesPanel.Controls.Add(this.totalTimeDisplay);
            this.zonesPanel.Controls.Add(this.totalTimeLabel);
            this.zonesPanel.Controls.Add(this.delItem);
            this.zonesPanel.Controls.Add(this.itemPane);
            this.zonesPanel.Controls.Add(this.addItem);
            this.zonesPanel.Controls.Add(this.newRotation);
            this.zonesPanel.Controls.Add(this.newZone);
            this.zonesPanel.Controls.Add(this.zoneView);
            this.zonesPanel.Location = new System.Drawing.Point(10, 112);
            this.zonesPanel.Name = "zonesPanel";
            this.zonesPanel.Size = new System.Drawing.Size(525, 375);
            this.zonesPanel.TabIndex = 15;
            // 
            // silverPerHourDisplay
            // 
            this.silverPerHourDisplay.AutoSize = true;
            this.silverPerHourDisplay.Location = new System.Drawing.Point(325, 343);
            this.silverPerHourDisplay.Name = "silverPerHourDisplay";
            this.silverPerHourDisplay.Size = new System.Drawing.Size(13, 15);
            this.silverPerHourDisplay.TabIndex = 11;
            this.silverPerHourDisplay.Text = "0";
            // 
            // totalSilverDisplay
            // 
            this.totalSilverDisplay.AutoSize = true;
            this.totalSilverDisplay.Location = new System.Drawing.Point(297, 325);
            this.totalSilverDisplay.Name = "totalSilverDisplay";
            this.totalSilverDisplay.Size = new System.Drawing.Size(13, 15);
            this.totalSilverDisplay.TabIndex = 10;
            this.totalSilverDisplay.Text = "0";
            // 
            // silverPerHourLabel
            // 
            this.silverPerHourLabel.AutoSize = true;
            this.silverPerHourLabel.Location = new System.Drawing.Point(227, 344);
            this.silverPerHourLabel.Name = "silverPerHourLabel";
            this.silverPerHourLabel.Size = new System.Drawing.Size(91, 15);
            this.silverPerHourLabel.TabIndex = 9;
            this.silverPerHourLabel.Text = "Silver Per Hour :";
            // 
            // totalSilverLabel
            // 
            this.totalSilverLabel.AutoSize = true;
            this.totalSilverLabel.Location = new System.Drawing.Point(227, 325);
            this.totalSilverLabel.Name = "totalSilverLabel";
            this.totalSilverLabel.Size = new System.Drawing.Size(69, 15);
            this.totalSilverLabel.TabIndex = 8;
            this.totalSilverLabel.Text = "Total Silver :";
            // 
            // totalTimeDisplay
            // 
            this.totalTimeDisplay.AutoSize = true;
            this.totalTimeDisplay.Location = new System.Drawing.Point(297, 306);
            this.totalTimeDisplay.Name = "totalTimeDisplay";
            this.totalTimeDisplay.Size = new System.Drawing.Size(49, 15);
            this.totalTimeDisplay.TabIndex = 7;
            this.totalTimeDisplay.Text = "00:00:00";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Location = new System.Drawing.Point(227, 306);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(67, 15);
            this.totalTimeLabel.TabIndex = 6;
            this.totalTimeLabel.Text = "Total Time :";
            // 
            // delItem
            // 
            this.delItem.Location = new System.Drawing.Point(307, 25);
            this.delItem.Name = "delItem";
            this.delItem.Size = new System.Drawing.Size(75, 23);
            this.delItem.TabIndex = 5;
            this.delItem.Text = "Delete Item";
            this.delItem.UseVisualStyleBackColor = true;
            this.delItem.Click += new System.EventHandler(this.delItem_Click);
            // 
            // itemPane
            // 
            this.itemPane.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemCol,
            this.market,
            this.vendor,
            this.amountCol});
            this.itemPane.HideSelection = false;
            listViewItem1.UseItemStyleForSubItems = false;
            this.itemPane.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.itemPane.Location = new System.Drawing.Point(226, 54);
            this.itemPane.Name = "itemPane";
            this.itemPane.Size = new System.Drawing.Size(287, 245);
            this.itemPane.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.itemPane.TabIndex = 4;
            this.itemPane.UseCompatibleStateImageBehavior = false;
            this.itemPane.View = System.Windows.Forms.View.Details;
            // 
            // itemCol
            // 
            this.itemCol.Text = "Item";
            this.itemCol.Width = 100;
            // 
            // market
            // 
            this.market.Text = "Market";
            // 
            // vendor
            // 
            this.vendor.Text = "Vendor";
            // 
            // amountCol
            // 
            this.amountCol.Text = "Amount";
            this.amountCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(226, 25);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(75, 23);
            this.addItem.TabIndex = 3;
            this.addItem.Text = "Add Item";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // newRotation
            // 
            this.newRotation.Location = new System.Drawing.Point(78, 0);
            this.newRotation.Name = "newRotation";
            this.newRotation.Size = new System.Drawing.Size(90, 23);
            this.newRotation.TabIndex = 2;
            this.newRotation.Text = "Add Rotation";
            this.newRotation.UseVisualStyleBackColor = true;
            this.newRotation.Click += new System.EventHandler(this.newRotation_Click);
            // 
            // newZone
            // 
            this.newZone.Location = new System.Drawing.Point(0, 0);
            this.newZone.Name = "newZone";
            this.newZone.Size = new System.Drawing.Size(75, 23);
            this.newZone.TabIndex = 1;
            this.newZone.Text = "Add Zone";
            this.newZone.UseVisualStyleBackColor = true;
            this.newZone.Click += new System.EventHandler(this.newZone_Click);
            // 
            // zoneView
            // 
            this.zoneView.ContextMenuStrip = this.treeViewContext;
            this.zoneView.HideSelection = false;
            this.zoneView.Location = new System.Drawing.Point(2, 25);
            this.zoneView.Name = "zoneView";
            this.zoneView.Size = new System.Drawing.Size(218, 350);
            this.zoneView.TabIndex = 0;
            // 
            // treeViewContext
            // 
            this.treeViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeAddZone,
            this.treeAddRotation,
            this.toolStripSeparator2,
            this.treeDelete});
            this.treeViewContext.Name = "treeViewContext";
            this.treeViewContext.Size = new System.Drawing.Size(145, 76);
            // 
            // treeAddZone
            // 
            this.treeAddZone.Name = "treeAddZone";
            this.treeAddZone.Size = new System.Drawing.Size(144, 22);
            this.treeAddZone.Text = "Add Zone";
            // 
            // treeAddRotation
            // 
            this.treeAddRotation.Name = "treeAddRotation";
            this.treeAddRotation.Size = new System.Drawing.Size(144, 22);
            this.treeAddRotation.Text = "Add Rotation";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // treeDelete
            // 
            this.treeDelete.Name = "treeDelete";
            this.treeDelete.Size = new System.Drawing.Size(144, 22);
            this.treeDelete.Text = "Delete";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 537);
            this.Controls.Add(this.zonesPanel);
            this.Controls.Add(this.characterPanel);
            this.Controls.Add(this.sessionPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sessionPanel.ResumeLayout(false);
            this.sessionPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.characterPanel.ResumeLayout(false);
            this.characterPanel.PerformLayout();
            this.zonesPanel.ResumeLayout(false);
            this.zonesPanel.PerformLayout();
            this.treeViewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label timerDisplay;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Panel sessionPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel characterPanel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox kutumBox;
        private System.Windows.Forms.Label apLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolStripMenuItem sessionViewer;
        private System.Windows.Forms.Panel zonesPanel;
        private System.Windows.Forms.ListView itemPane;
        private System.Windows.Forms.ColumnHeader itemCol;
        private System.Windows.Forms.ColumnHeader amountCol;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.Button newRotation;
        private System.Windows.Forms.Button newZone;
        private System.Windows.Forms.TreeView zoneView;
        private System.Windows.Forms.TreeView zone;
        private System.Windows.Forms.ToolStripMenuItem dataTab;
        private System.Windows.Forms.ToolStripMenuItem createDB;
        private System.Windows.Forms.ToolStripMenuItem clearDB;
        private System.Windows.Forms.ListView temP;
        private System.Windows.Forms.ContextMenuStrip treeViewContext;
        private System.Windows.Forms.ToolStripMenuItem treeAddZone;
        private System.Windows.Forms.ToolStripMenuItem treeDelete;
        private System.Windows.Forms.Button delItem;
        private System.Windows.Forms.ColumnHeader market;
        private System.Windows.Forms.ColumnHeader vendor;
        private System.Windows.Forms.ToolStripMenuItem treeAddRotation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label totalTimeDisplay;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label silverPerHourLabel;
        private System.Windows.Forms.Label totalSilverLabel;
        private System.Windows.Forms.Label totalSilverDisplay;
        private System.Windows.Forms.Label silverPerHourDisplay;
    }
}

