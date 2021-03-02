
namespace BDO_Grind_Tracker
{
    partial class PriceUpdate
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
            this.marketBox = new System.Windows.Forms.TextBox();
            this.vendorBox = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.marketLabel = new System.Windows.Forms.Label();
            this.vendorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // marketBox
            // 
            this.marketBox.Location = new System.Drawing.Point(92, 18);
            this.marketBox.Name = "marketBox";
            this.marketBox.Size = new System.Drawing.Size(100, 23);
            this.marketBox.TabIndex = 2;
            // 
            // vendorBox
            // 
            this.vendorBox.Location = new System.Drawing.Point(92, 48);
            this.vendorBox.Name = "vendorBox";
            this.vendorBox.Size = new System.Drawing.Size(100, 23);
            this.vendorBox.TabIndex = 3;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(92, 78);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // marketLabel
            // 
            this.marketLabel.AutoSize = true;
            this.marketLabel.Location = new System.Drawing.Point(10, 26);
            this.marketLabel.Name = "marketLabel";
            this.marketLabel.Size = new System.Drawing.Size(73, 15);
            this.marketLabel.TabIndex = 7;
            this.marketLabel.Text = "Market Price";
            // 
            // vendorLabel
            // 
            this.vendorLabel.AutoSize = true;
            this.vendorLabel.Location = new System.Drawing.Point(10, 57);
            this.vendorLabel.Name = "vendorLabel";
            this.vendorLabel.Size = new System.Drawing.Size(73, 15);
            this.vendorLabel.TabIndex = 8;
            this.vendorLabel.Text = "Vendor Price";
            // 
            // PriceUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 118);
            this.Controls.Add(this.vendorLabel);
            this.Controls.Add(this.marketLabel);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.vendorBox);
            this.Controls.Add(this.marketBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PriceUpdate";
            this.Text = "New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox marketBox;
        private System.Windows.Forms.TextBox vendorBox;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label marketLabel;
        private System.Windows.Forms.Label vendorLabel;
    }
}