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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(195, 101);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(286, 31);
            this.textBox_ip.TabIndex = 5;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(195, 190);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(286, 31);
            this.textBox_port.TabIndex = 6;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(195, 278);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(286, 31);
            this.textBox_username.TabIndex = 7;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(195, 346);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(226, 50);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(540, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(481, 622);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sweet:";
            // 
            // button_getSweets
            // 
            this.button_getSweets.Enabled = false;
            this.button_getSweets.Location = new System.Drawing.Point(195, 449);
            this.button_getSweets.Name = "button_getSweets";
            this.button_getSweets.Size = new System.Drawing.Size(226, 50);
            this.button_getSweets.TabIndex = 11;
            this.button_getSweets.Text = "Get Sweets";
            this.button_getSweets.UseVisualStyleBackColor = true;
            // 
            // textBox_sweet
            // 
            this.textBox_sweet.Enabled = false;
            this.textBox_sweet.Location = new System.Drawing.Point(195, 539);
            this.textBox_sweet.Multiline = true;
            this.textBox_sweet.Name = "textBox_sweet";
            this.textBox_sweet.Size = new System.Drawing.Size(286, 127);
            this.textBox_sweet.TabIndex = 12;
            // 
            // button_sendSweet
            // 
            this.button_sendSweet.Enabled = false;
            this.button_sendSweet.Location = new System.Drawing.Point(195, 694);
            this.button_sendSweet.Name = "button_sendSweet";
            this.button_sendSweet.Size = new System.Drawing.Size(226, 50);
            this.button_sendSweet.TabIndex = 13;
            this.button_sendSweet.Text = "Send Sweet";
            this.button_sendSweet.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 809);
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
    }
}

