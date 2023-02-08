namespace Datebase_
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.authBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.psdBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.loginBox);
            this.groupBox1.Controls.Add(this.authBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.psdBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 243);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Authentication:";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(126, 125);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(168, 23);
            this.loginBox.TabIndex = 2;
            // 
            // authBox
            // 
            this.authBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authBox.Items.AddRange(new object[] {
            "Windows",
            "By login"});
            this.authBox.Location = new System.Drawing.Point(126, 79);
            this.authBox.Name = "authBox";
            this.authBox.Size = new System.Drawing.Size(168, 23);
            this.authBox.TabIndex = 7;
            this.authBox.SelectedIndexChanged += new System.EventHandler(this.onAuthChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // psdBox
            // 
            this.psdBox.Location = new System.Drawing.Point(126, 177);
            this.psdBox.Name = "psdBox";
            this.psdBox.PasswordChar = '*';
            this.psdBox.Size = new System.Drawing.Size(168, 23);
            this.psdBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name:";
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(143, 70);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(168, 23);
            this.serverBox.TabIndex = 5;
            this.serverBox.Text = "localhost";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(236, 302);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.serverBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 328);
            this.panel1.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 348);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private TextBox loginBox;
        private ComboBox authBox;
        private Label label2;
        private TextBox psdBox;
        private Label label1;
        private TextBox serverBox;
        private Button btnConnect;
        private Label label3;
        private Panel panel1;
    }
}