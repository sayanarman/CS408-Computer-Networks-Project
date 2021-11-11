namespace Client
{
    partial class Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_getSweets = new System.Windows.Forms.Button();
            this.textBox_sweet = new System.Windows.Forms.TextBox();
            this.button_sendSweet = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.sweetId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(146, 81);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(216, 26);
            this.textBox_ip.TabIndex = 5;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(146, 152);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(216, 26);
            this.textBox_port.TabIndex = 6;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(146, 222);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(216, 26);
            this.textBox_username.TabIndex = 7;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(146, 277);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(170, 40);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(405, 81);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(311, 498);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 431);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sweet:";
            // 
            // button_getSweets
            // 
            this.button_getSweets.Enabled = false;
            this.button_getSweets.Location = new System.Drawing.Point(146, 359);
            this.button_getSweets.Margin = new System.Windows.Forms.Padding(2);
            this.button_getSweets.Name = "button_getSweets";
            this.button_getSweets.Size = new System.Drawing.Size(170, 40);
            this.button_getSweets.TabIndex = 11;
            this.button_getSweets.Text = "Get Sweets";
            this.button_getSweets.UseVisualStyleBackColor = true;
            this.button_getSweets.Click += new System.EventHandler(this.button_getSweets_Click);
            // 
            // textBox_sweet
            // 
            this.textBox_sweet.Enabled = false;
            this.textBox_sweet.Location = new System.Drawing.Point(146, 431);
            this.textBox_sweet.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sweet.Multiline = true;
            this.textBox_sweet.Name = "textBox_sweet";
            this.textBox_sweet.Size = new System.Drawing.Size(216, 102);
            this.textBox_sweet.TabIndex = 12;
            // 
            // button_sendSweet
            // 
            this.button_sendSweet.Enabled = false;
            this.button_sendSweet.Location = new System.Drawing.Point(146, 555);
            this.button_sendSweet.Margin = new System.Windows.Forms.Padding(2);
            this.button_sendSweet.Name = "button_sendSweet";
            this.button_sendSweet.Size = new System.Drawing.Size(170, 40);
            this.button_sendSweet.TabIndex = 13;
            this.button_sendSweet.Text = "Send Sweet";
            this.button_sendSweet.UseVisualStyleBackColor = true;
            this.button_sendSweet.Click += new System.EventHandler(this.button_sendSweet_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sweetId,
            this.username,
            this.timeStamp,
            this.content});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(757, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(511, 498);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // sweetId
            // 
            this.sweetId.Text = "SweetId";
            this.sweetId.Width = 74;
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 91;
            // 
            // timeStamp
            // 
            this.timeStamp.Text = "Timestamp";
            this.timeStamp.Width = 59;
            // 
            // content
            // 
            this.content.Text = "Content";
            this.content.Width = 308;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 751);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_sendSweet);
            this.Controls.Add(this.textBox_sweet);
            this.Controls.Add(this.button_getSweets);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Client";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_getSweets;
        private System.Windows.Forms.TextBox textBox_sweet;
        private System.Windows.Forms.Button button_sendSweet;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader sweetId;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader timeStamp;
        private System.Windows.Forms.ColumnHeader content;
    }
}

