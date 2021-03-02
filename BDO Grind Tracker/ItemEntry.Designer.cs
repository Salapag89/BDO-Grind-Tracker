
namespace BDO_Grind_Tracker
{
    partial class ItemEntry
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
            this.itemLabel = new System.Windows.Forms.Label();
            this.itemBox = new System.Windows.Forms.TextBox();
            this.marketBox = new System.Windows.Forms.TextBox();
            this.vendorBox = new System.Windows.Forms.TextBox();
            this.catBox = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.catLabel = new System.Windows.Forms.Label();
            this.marketLabel = new System.Windows.Forms.Label();
            this.vendorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(13, 21);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(31, 15);
            this.itemLabel.TabIndex = 0;
            this.itemLabel.Text = "Item";
            // 
            // itemBox
            // 
            this.itemBox.Location = new System.Drawing.Point(95, 12);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(100, 23);
            this.itemBox.TabIndex = 1;
            // 
            // marketBox
            // 
            this.marketBox.Location = new System.Drawing.Point(95, 71);
            this.marketBox.Name = "marketBox";
            this.marketBox.Size = new System.Drawing.Size(100, 23);
            this.marketBox.TabIndex = 2;
            // 
            // vendorBox
            // 
            this.vendorBox.Location = new System.Drawing.Point(95, 101);
            this.vendorBox.Name = "vendorBox";
            this.vendorBox.Size = new System.Drawing.Size(100, 23);
            this.vendorBox.TabIndex = 3;
            // 
            // catBox
            // 
            this.catBox.FormattingEnabled = true;
            this.catBox.Location = new System.Drawing.Point(95, 42);
            this.catBox.Name = "catBox";
            this.catBox.Size = new System.Drawing.Size(121, 23);
            this.catBox.TabIndex = 4;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(95, 131);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // catLabel
            // 
            this.catLabel.AutoSize = true;
            this.catLabel.Location = new System.Drawing.Point(13, 50);
            this.catLabel.Name = "catLabel";
            this.catLabel.Size = new System.Drawing.Size(55, 15);
            this.catLabel.TabIndex = 6;
            this.catLabel.Text = "Category";
            // 
            // marketLabel
            // 
            this.marketLabel.AutoSize = true;
            this.marketLabel.Location = new System.Drawing.Point(13, 79);
            this.marketLabel.Name = "marketLabel";
            this.marketLabel.Size = new System.Drawing.Size(73, 15);
            this.marketLabel.TabIndex = 7;
            this.marketLabel.Text = "Market Price";
            // 
            // vendorLabel
            // 
            this.vendorLabel.AutoSize = true;
            this.vendorLabel.Location = new System.Drawing.Point(13, 110);
            this.vendorLabel.Name = "vendorLabel";
            this.vendorLabel.Size = new System.Drawing.Size(73, 15);
            this.vendorLabel.TabIndex = 8;
            this.vendorLabel.Text = "Vendor Price";
            // 
            // ItemEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 166);
            this.Controls.Add(this.vendorLabel);
            this.Controls.Add(this.marketLabel);
            this.Controls.Add(this.catLabel);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.catBox);
            this.Controls.Add(this.vendorBox);
            this.Controls.Add(this.marketBox);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.itemLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemEntry";
            this.Text = "New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.TextBox itemBox;
        private System.Windows.Forms.TextBox marketBox;
        private System.Windows.Forms.TextBox vendorBox;
        private System.Windows.Forms.ComboBox catBox;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label catLabel;
        private System.Windows.Forms.Label marketLabel;
        private System.Windows.Forms.Label vendorLabel;
    }
}