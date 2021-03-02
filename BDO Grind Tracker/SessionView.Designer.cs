
namespace BDO_Grind_Tracker
{
    partial class SessionView
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
            this.components = new System.ComponentModel.Container();
            this.sessionListView = new System.Windows.Forms.ListView();
            this.date = new System.Windows.Forms.ColumnHeader();
            this.duration = new System.Windows.Forms.ColumnHeader();
            this.zone = new System.Windows.Forms.ColumnHeader();
            this.rotation = new System.Windows.Forms.ColumnHeader();
            this.ap = new System.Windows.Forms.ColumnHeader();
            this.scroll = new System.Windows.Forms.ColumnHeader();
            this.agris = new System.Windows.Forms.ColumnHeader();
            this.sessionContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.Button();
            this.done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sessionListView
            // 
            this.sessionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.duration,
            this.zone,
            this.rotation,
            this.ap,
            this.scroll,
            this.agris});
            this.sessionListView.ContextMenuStrip = this.sessionContext;
            this.sessionListView.HideSelection = false;
            this.sessionListView.Location = new System.Drawing.Point(13, 24);
            this.sessionListView.Name = "sessionListView";
            this.sessionListView.Size = new System.Drawing.Size(539, 342);
            this.sessionListView.TabIndex = 0;
            this.sessionListView.UseCompatibleStateImageBehavior = false;
            this.sessionListView.View = System.Windows.Forms.View.Details;
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // duration
            // 
            this.duration.Text = "Duration";
            // 
            // zone
            // 
            this.zone.Text = "Zone";
            // 
            // rotation
            // 
            this.rotation.Text = "Rotation";
            // 
            // ap
            // 
            this.ap.Text = "AP";
            // 
            // scroll
            // 
            this.scroll.Text = "Scroll";
            // 
            // agris
            // 
            this.agris.Text = "Agris";
            // 
            // sessionContext
            // 
            this.sessionContext.Name = "sessionContext";
            this.sessionContext.Size = new System.Drawing.Size(61, 4);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(12, 372);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 1;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(477, 372);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(75, 23);
            this.done.TabIndex = 2;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // SessionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 406);
            this.Controls.Add(this.done);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.sessionListView);
            this.Name = "SessionView";
            this.Text = "SessionView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView sessionListView;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader duration;
        private System.Windows.Forms.ColumnHeader zone;
        private System.Windows.Forms.ColumnHeader rotation;
        private System.Windows.Forms.ColumnHeader ap;
        private System.Windows.Forms.ColumnHeader scroll;
        private System.Windows.Forms.ColumnHeader agris;
        private System.Windows.Forms.ContextMenuStrip sessionContext;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button done;
    }
}