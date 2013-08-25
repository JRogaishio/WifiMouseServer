namespace WifiMouseServer
{
    partial class WifiMouserServer
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
            this.btn_startServer = new System.Windows.Forms.Button();
            this.lbl_serverIp = new System.Windows.Forms.Label();
            this.lbl_pos = new System.Windows.Forms.Label();
            this.btn_stopServer = new System.Windows.Forms.Button();
            this.grp_status = new System.Windows.Forms.GroupBox();
            this.lbl_clientStatus = new System.Windows.Forms.Label();
            this.lbl_serverStatus = new System.Windows.Forms.Label();
            this.grp_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_startServer
            // 
            this.btn_startServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_startServer.Location = new System.Drawing.Point(12, 12);
            this.btn_startServer.Name = "btn_startServer";
            this.btn_startServer.Size = new System.Drawing.Size(112, 43);
            this.btn_startServer.TabIndex = 0;
            this.btn_startServer.Text = "Start";
            this.btn_startServer.UseVisualStyleBackColor = false;
            this.btn_startServer.Click += new System.EventHandler(this.btn_startServer_Click);
            // 
            // lbl_serverIp
            // 
            this.lbl_serverIp.Location = new System.Drawing.Point(12, 66);
            this.lbl_serverIp.Name = "lbl_serverIp";
            this.lbl_serverIp.Size = new System.Drawing.Size(149, 23);
            this.lbl_serverIp.TabIndex = 11;
            this.lbl_serverIp.Text = "Server IP: xxx.xxx.xxx.xxx";
            // 
            // lbl_pos
            // 
            this.lbl_pos.Location = new System.Drawing.Point(6, 74);
            this.lbl_pos.Name = "lbl_pos";
            this.lbl_pos.Size = new System.Drawing.Size(204, 23);
            this.lbl_pos.TabIndex = 12;
            this.lbl_pos.Text = "Mouse Pos: ";
            // 
            // btn_stopServer
            // 
            this.btn_stopServer.BackColor = System.Drawing.Color.Red;
            this.btn_stopServer.Enabled = false;
            this.btn_stopServer.Location = new System.Drawing.Point(130, 12);
            this.btn_stopServer.Name = "btn_stopServer";
            this.btn_stopServer.Size = new System.Drawing.Size(109, 43);
            this.btn_stopServer.TabIndex = 13;
            this.btn_stopServer.Text = "Stop";
            this.btn_stopServer.UseVisualStyleBackColor = false;
            this.btn_stopServer.Click += new System.EventHandler(this.btn_stopServer_Click);
            // 
            // grp_status
            // 
            this.grp_status.Controls.Add(this.lbl_serverStatus);
            this.grp_status.Controls.Add(this.lbl_clientStatus);
            this.grp_status.Controls.Add(this.lbl_pos);
            this.grp_status.Location = new System.Drawing.Point(15, 92);
            this.grp_status.Name = "grp_status";
            this.grp_status.Size = new System.Drawing.Size(219, 115);
            this.grp_status.TabIndex = 14;
            this.grp_status.TabStop = false;
            this.grp_status.Text = "Status";
            // 
            // lbl_clientStatus
            // 
            this.lbl_clientStatus.AutoSize = true;
            this.lbl_clientStatus.Location = new System.Drawing.Point(6, 42);
            this.lbl_clientStatus.Name = "lbl_clientStatus";
            this.lbl_clientStatus.Size = new System.Drawing.Size(119, 13);
            this.lbl_clientStatus.TabIndex = 0;
            this.lbl_clientStatus.Text = "Client Connected: False";
            // 
            // lbl_serverStatus
            // 
            this.lbl_serverStatus.AutoSize = true;
            this.lbl_serverStatus.Location = new System.Drawing.Point(6, 16);
            this.lbl_serverStatus.Name = "lbl_serverStatus";
            this.lbl_serverStatus.Size = new System.Drawing.Size(94, 13);
            this.lbl_serverStatus.TabIndex = 1;
            this.lbl_serverStatus.Text = "Server Status:  Off";
            // 
            // WifiMouserServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 217);
            this.Controls.Add(this.grp_status);
            this.Controls.Add(this.btn_stopServer);
            this.Controls.Add(this.lbl_serverIp);
            this.Controls.Add(this.btn_startServer);
            this.Name = "WifiMouserServer";
            this.Text = "WifiMouse Server";
            this.Load += new System.EventHandler(this.WifiMouserServer_Load);
            this.grp_status.ResumeLayout(false);
            this.grp_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_startServer;
        private System.Windows.Forms.Label lbl_serverIp;
        private System.Windows.Forms.Button btn_stopServer;
        private System.Windows.Forms.GroupBox grp_status;
        private System.Windows.Forms.Label lbl_pos;
        private System.Windows.Forms.Label lbl_clientStatus;
        private System.Windows.Forms.Label lbl_serverStatus;
    }
}

