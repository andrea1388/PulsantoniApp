namespace pulsantoni2
{
    partial class FMain
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comandiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostraSegnaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startVoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopVoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoppedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSlaveNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstato = new System.Windows.Forms.Label();
            this.rt1 = new System.Windows.Forms.RichTextBox();
            this.bstartpolling = new System.Windows.Forms.Button();
            this.bstartvote = new System.Windows.Forms.Button();
            this.bstopvote = new System.Windows.Forms.Button();
            this.bstoppolling = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comandiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1773, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comandiToolStripMenuItem
            // 
            this.comandiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostraSegnaleToolStripMenuItem,
            this.startPollingToolStripMenuItem,
            this.startVoteToolStripMenuItem,
            this.stopVoteToolStripMenuItem,
            this.stoppedToolStripMenuItem,
            this.changeSlaveNumberToolStripMenuItem});
            this.comandiToolStripMenuItem.Name = "comandiToolStripMenuItem";
            this.comandiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.comandiToolStripMenuItem.Text = "&Comandi";
            // 
            // mostraSegnaleToolStripMenuItem
            // 
            this.mostraSegnaleToolStripMenuItem.Name = "mostraSegnaleToolStripMenuItem";
            this.mostraSegnaleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.mostraSegnaleToolStripMenuItem.Text = "Show extra info";
            this.mostraSegnaleToolStripMenuItem.Click += new System.EventHandler(this.mostraSegnaleToolStripMenuItem_Click);
            // 
            // startPollingToolStripMenuItem
            // 
            this.startPollingToolStripMenuItem.Name = "startPollingToolStripMenuItem";
            this.startPollingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.startPollingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startPollingToolStripMenuItem.Text = "Start polling";
            this.startPollingToolStripMenuItem.Click += new System.EventHandler(this.startPollingToolStripMenuItem_Click);
            // 
            // startVoteToolStripMenuItem
            // 
            this.startVoteToolStripMenuItem.Name = "startVoteToolStripMenuItem";
            this.startVoteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.startVoteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startVoteToolStripMenuItem.Text = "Start vote";
            this.startVoteToolStripMenuItem.Click += new System.EventHandler(this.startVoteToolStripMenuItem_Click);
            // 
            // stopVoteToolStripMenuItem
            // 
            this.stopVoteToolStripMenuItem.Name = "stopVoteToolStripMenuItem";
            this.stopVoteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.stopVoteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.stopVoteToolStripMenuItem.Text = "Stop vote";
            this.stopVoteToolStripMenuItem.Click += new System.EventHandler(this.stopVoteToolStripMenuItem_Click);
            // 
            // stoppedToolStripMenuItem
            // 
            this.stoppedToolStripMenuItem.Name = "stoppedToolStripMenuItem";
            this.stoppedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.stoppedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.stoppedToolStripMenuItem.Text = "Stopped";
            this.stoppedToolStripMenuItem.Click += new System.EventHandler(this.stoppedToolStripMenuItem_Click);
            // 
            // changeSlaveNumberToolStripMenuItem
            // 
            this.changeSlaveNumberToolStripMenuItem.Name = "changeSlaveNumberToolStripMenuItem";
            this.changeSlaveNumberToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.changeSlaveNumberToolStripMenuItem.Text = "Change Slave number";
            this.changeSlaveNumberToolStripMenuItem.Click += new System.EventHandler(this.changeSlaveNumberToolStripMenuItem_Click);
            // 
            // lstato
            // 
            this.lstato.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstato.Location = new System.Drawing.Point(12, 24);
            this.lstato.Name = "lstato";
            this.lstato.Size = new System.Drawing.Size(696, 25);
            this.lstato.TabIndex = 2;
            this.lstato.Text = "Waiting connection";
            // 
            // rt1
            // 
            this.rt1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rt1.DetectUrls = false;
            this.rt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rt1.Location = new System.Drawing.Point(207, 64);
            this.rt1.Name = "rt1";
            this.rt1.ReadOnly = true;
            this.rt1.Size = new System.Drawing.Size(1542, 194);
            this.rt1.TabIndex = 3;
            this.rt1.TabStop = false;
            this.rt1.Text = "";
            // 
            // bstartpolling
            // 
            this.bstartpolling.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstartpolling.Location = new System.Drawing.Point(17, 64);
            this.bstartpolling.Name = "bstartpolling";
            this.bstartpolling.Size = new System.Drawing.Size(168, 44);
            this.bstartpolling.TabIndex = 4;
            this.bstartpolling.Text = "Start polling";
            this.bstartpolling.UseVisualStyleBackColor = true;
            this.bstartpolling.Click += new System.EventHandler(this.bstartpolling_Click);
            // 
            // bstartvote
            // 
            this.bstartvote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstartvote.Location = new System.Drawing.Point(17, 114);
            this.bstartvote.Name = "bstartvote";
            this.bstartvote.Size = new System.Drawing.Size(168, 44);
            this.bstartvote.TabIndex = 5;
            this.bstartvote.Text = "Start vote";
            this.bstartvote.UseVisualStyleBackColor = true;
            this.bstartvote.Click += new System.EventHandler(this.bstartvote_Click);
            // 
            // bstopvote
            // 
            this.bstopvote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstopvote.Location = new System.Drawing.Point(17, 164);
            this.bstopvote.Name = "bstopvote";
            this.bstopvote.Size = new System.Drawing.Size(168, 44);
            this.bstopvote.TabIndex = 6;
            this.bstopvote.Text = "Stop vote";
            this.bstopvote.UseVisualStyleBackColor = true;
            this.bstopvote.Click += new System.EventHandler(this.bstopvote_Click);
            // 
            // bstoppolling
            // 
            this.bstoppolling.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstoppolling.Location = new System.Drawing.Point(17, 214);
            this.bstoppolling.Name = "bstoppolling";
            this.bstoppolling.Size = new System.Drawing.Size(168, 44);
            this.bstoppolling.TabIndex = 7;
            this.bstoppolling.Text = "Stopped";
            this.bstoppolling.UseVisualStyleBackColor = true;
            this.bstoppolling.Click += new System.EventHandler(this.bstoppolling_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1773, 400);
            this.Controls.Add(this.bstoppolling);
            this.Controls.Add(this.bstopvote);
            this.Controls.Add(this.bstartvote);
            this.Controls.Add(this.bstartpolling);
            this.Controls.Add(this.rt1);
            this.Controls.Add(this.lstato);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FMain";
            this.Text = "Pulsantoni";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Resize += new System.EventHandler(this.FMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comandiToolStripMenuItem;
        private System.Windows.Forms.Label lstato;
        private System.Windows.Forms.RichTextBox rt1;
        private System.Windows.Forms.Button bstartpolling;
        private System.Windows.Forms.Button bstartvote;
        private System.Windows.Forms.Button bstopvote;
        private System.Windows.Forms.Button bstoppolling;
        private System.Windows.Forms.ToolStripMenuItem mostraSegnaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startPollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startVoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopVoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoppedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSlaveNumberToolStripMenuItem;
    }
}

