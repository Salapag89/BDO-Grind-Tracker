
namespace BDO_Grind_Tracker
{
    partial class ItemList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemListView = new System.Windows.Forms.ListView();
            this.newButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.zoneItemView = new System.Windows.Forms.ListView();
            this.finish = new System.Windows.Forms.Button();
            this.itemListLabel = new System.Windows.Forms.Label();
            this.zoneItemList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemListView
            // 
            this.itemListView.HideSelection = false;
            this.itemListView.Location = new System.Drawing.Point(12, 41);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(156, 338);
            this.itemListView.TabIndex = 0;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.List;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(12, 385);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "New Item";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(174, 156);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(31, 28);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = ">>";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // zoneItemView
            // 
            this.zoneItemView.AllowDrop = true;
            this.zoneItemView.HideSelection = false;
            this.zoneItemView.Location = new System.Drawing.Point(211, 41);
            this.zoneItemView.Name = "zoneItemView";
            this.zoneItemView.Size = new System.Drawing.Size(156, 338);
            this.zoneItemView.TabIndex = 3;
            this.zoneItemView.UseCompatibleStateImageBehavior = false;
            this.zoneItemView.View = System.Windows.Forms.View.List;
            // 
            // finish
            // 
            this.finish.Location = new System.Drawing.Point(292, 385);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(75, 23);
            this.finish.TabIndex = 4;
            this.finish.Text = "Done";
            this.finish.UseVisualStyleBackColor = true;
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // itemListLabel
            // 
            this.itemListLabel.AutoSize = true;
            this.itemListLabel.Location = new System.Drawing.Point(13, 20);
            this.itemListLabel.Name = "itemListLabel";
            this.itemListLabel.Size = new System.Drawing.Size(36, 15);
            this.itemListLabel.TabIndex = 5;
            this.itemListLabel.Text = "Items";
            // 
            // zoneItemList
            // 
            this.zoneItemList.AutoSize = true;
            this.zoneItemList.Location = new System.Drawing.Point(211, 20);
            this.zoneItemList.Name = "zoneItemList";
            this.zoneItemList.Size = new System.Drawing.Size(54, 15);
            this.zoneItemList.TabIndex = 6;
            this.zoneItemList.Text = "Drops in ";
            // 
            // ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 416);
            this.Controls.Add(this.zoneItemList);
            this.Controls.Add(this.itemListLabel);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.zoneItemView);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.itemListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemList";
            this.Text = "Item List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ListView zoneItemView;
        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.Label itemListLabel;
        private System.Windows.Forms.Label zoneItemList;
    }
}