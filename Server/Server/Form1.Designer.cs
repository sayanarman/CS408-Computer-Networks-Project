namespace Server
{
    partial class Server
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Activity Monitor on Port:";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(148, 263);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(842, 434);
            this.logs.TabIndex = 2;
            this.logs.Text = "";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(299, 129);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(438, 31);
            this.textBox_port.TabIndex = 3;
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(769, 116);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(221, 57);
            this.button_listen.TabIndex = 4;
            this.button_listen.Text = "Start Listening Port";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // Server
            // 
            this.ClientSize = new System.Drawing.Size(1099, 809);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_listen;
    }
}

