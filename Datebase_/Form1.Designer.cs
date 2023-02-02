namespace Datebase_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrganizationDrop = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orgsBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameOrgTextBox = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.dataGridOrg = new System.Windows.Forms.DataGridView();
            this.ID_org = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrganizationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.orgSearchBox = new System.Windows.Forms.TextBox();
            this.orgComboBoxSearch = new System.Windows.Forms.ComboBox();
            this.btnOrgSearch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.empSearchBox = new System.Windows.Forms.TextBox();
            this.empComboBoxSearch = new System.Windows.Forms.ComboBox();
            this.btnEmpSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EmployeeName,
            this.Age,
            this.Email,
            this.OrganizationDrop,
            this.Image});
            this.dataGridView.Location = new System.Drawing.Point(12, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(836, 445);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // OrganizationDrop
            // 
            this.OrganizationDrop.HeaderText = "Organization";
            this.OrganizationDrop.Items.AddRange(new object[] {
            "-Select-"});
            this.OrganizationDrop.Name = "OrganizationDrop";
            this.OrganizationDrop.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Image.HeaderText = "Photo";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Image.Width = 64;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(31, 329);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Submit";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddEmployeeClick);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(31, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(139, 23);
            this.nameTextBox.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(28, 36);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(31, 99);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(31, 15);
            this.ageLabel.TabIndex = 5;
            this.ageLabel.Text = "Age:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(31, 129);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(139, 23);
            this.ageTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddPhoto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.orgsBox);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.ageTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.ageLabel);
            this.groupBox1.Location = new System.Drawing.Point(871, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 445);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(31, 193);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(139, 23);
            this.emailTextBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(202, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(107, 139);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Employee Form";
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(202, 192);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(107, 22);
            this.btnAddPhoto.TabIndex = 10;
            this.btnAddPhoto.Text = "Add photo";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.BtnAddImageClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Organization:";
            // 
            // orgsBox
            // 
            this.orgsBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.orgsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgsBox.Items.AddRange(new object[] {
            "-Select-"});
            this.orgsBox.Location = new System.Drawing.Point(31, 269);
            this.orgsBox.Name = "orgsBox";
            this.orgsBox.Size = new System.Drawing.Size(139, 23);
            this.orgsBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.addressTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nameOrgTextBox);
            this.groupBox2.Location = new System.Drawing.Point(871, 536);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 387);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(37, 148);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(139, 23);
            this.addressTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Organization Form";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 11;
            this.button1.TabStop = false;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddOrganizationClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // nameOrgTextBox
            // 
            this.nameOrgTextBox.Location = new System.Drawing.Point(37, 79);
            this.nameOrgTextBox.Name = "nameOrgTextBox";
            this.nameOrgTextBox.Size = new System.Drawing.Size(139, 23);
            this.nameOrgTextBox.TabIndex = 5;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(225, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 24);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(113, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 24);
            this.btnClear.TabIndex = 11;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Deselect";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(0, 12);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(107, 24);
            this.btnFill.TabIndex = 12;
            this.btnFill.TabStop = false;
            this.btnFill.Text = "Load data";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.BtnFillDb);
            // 
            // dataGridOrg
            // 
            this.dataGridOrg.AllowUserToDeleteRows = false;
            this.dataGridOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_org,
            this.OrganizationName,
            this.Address});
            this.dataGridOrg.Location = new System.Drawing.Point(12, 536);
            this.dataGridOrg.Name = "dataGridOrg";
            this.dataGridOrg.ReadOnly = true;
            this.dataGridOrg.RowTemplate.Height = 25;
            this.dataGridOrg.Size = new System.Drawing.Size(836, 387);
            this.dataGridOrg.TabIndex = 13;
            this.dataGridOrg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellOrgClick);
            // 
            // ID_org
            // 
            this.ID_org.HeaderText = "ID";
            this.ID_org.Name = "ID_org";
            this.ID_org.ReadOnly = true;
            // 
            // OrganizationName
            // 
            this.OrganizationName.HeaderText = "Name";
            this.OrganizationName.Name = "OrganizationName";
            this.OrganizationName.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnFill);
            this.panel1.Location = new System.Drawing.Point(871, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 39);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.orgSearchBox);
            this.panel2.Controls.Add(this.orgComboBoxSearch);
            this.panel2.Controls.Add(this.btnOrgSearch);
            this.panel2.Location = new System.Drawing.Point(4, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 36);
            this.panel2.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(661, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Field:";
            // 
            // orgSearchBox
            // 
            this.orgSearchBox.Location = new System.Drawing.Point(47, 13);
            this.orgSearchBox.Name = "orgSearchBox";
            this.orgSearchBox.Size = new System.Drawing.Size(499, 23);
            this.orgSearchBox.TabIndex = 20;
            // 
            // orgComboBoxSearch
            // 
            this.orgComboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgComboBoxSearch.FormattingEnabled = true;
            this.orgComboBoxSearch.Items.AddRange(new object[] {
            "-Select-",
            "ID",
            "Name",
            "Address"});
            this.orgComboBoxSearch.Location = new System.Drawing.Point(702, 12);
            this.orgComboBoxSearch.Name = "orgComboBoxSearch";
            this.orgComboBoxSearch.Size = new System.Drawing.Size(142, 23);
            this.orgComboBoxSearch.TabIndex = 22;
            // 
            // btnOrgSearch
            // 
            this.btnOrgSearch.Location = new System.Drawing.Point(563, 12);
            this.btnOrgSearch.Name = "btnOrgSearch";
            this.btnOrgSearch.Size = new System.Drawing.Size(75, 23);
            this.btnOrgSearch.TabIndex = 21;
            this.btnOrgSearch.Text = "Search";
            this.btnOrgSearch.UseVisualStyleBackColor = true;
            this.btnOrgSearch.Click += new System.EventHandler(this.OrgSearchClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.empSearchBox);
            this.panel3.Controls.Add(this.empComboBoxSearch);
            this.panel3.Controls.Add(this.btnEmpSearch);
            this.panel3.Location = new System.Drawing.Point(4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 39);
            this.panel3.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Field:";
            // 
            // empSearchBox
            // 
            this.empSearchBox.Location = new System.Drawing.Point(47, 13);
            this.empSearchBox.Name = "empSearchBox";
            this.empSearchBox.Size = new System.Drawing.Size(499, 23);
            this.empSearchBox.TabIndex = 20;
            // 
            // empComboBoxSearch
            // 
            this.empComboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empComboBoxSearch.FormattingEnabled = true;
            this.empComboBoxSearch.Items.AddRange(new object[] {
            "-Select-",
            "ID",
            "Name",
            "Age",
            "Email",
            "Organization"});
            this.empComboBoxSearch.Location = new System.Drawing.Point(702, 12);
            this.empComboBoxSearch.Name = "empComboBoxSearch";
            this.empComboBoxSearch.Size = new System.Drawing.Size(142, 23);
            this.empComboBoxSearch.TabIndex = 22;
            // 
            // btnEmpSearch
            // 
            this.btnEmpSearch.Location = new System.Drawing.Point(563, 13);
            this.btnEmpSearch.Name = "btnEmpSearch";
            this.btnEmpSearch.Size = new System.Drawing.Size(75, 23);
            this.btnEmpSearch.TabIndex = 21;
            this.btnEmpSearch.Text = "Search";
            this.btnEmpSearch.UseVisualStyleBackColor = true;
            this.btnEmpSearch.Click += new System.EventHandler(this.EmpSearchClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1222, 935);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridOrg);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView;
        private Button btnAdd;
        private TextBox nameTextBox;
        private Label nameLabel;
        private Label ageLabel;
        private TextBox ageTextBox;
        private GroupBox groupBox1;
        private Button btnAddPhoto;
        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox orgsBox;
        private GroupBox groupBox2;
        private Button button1;
        private Label label2;
        private TextBox nameOrgTextBox;
        private Label label3;
        private Label label4;
        private Button btnRemove;
        private Button btnClear;
        private GroupBox groupBox3;
        private Button btnFill;
        private DataGridView dataGridOrg;
        private TextBox emailTextBox;
        private Label label5;
        private Label label6;
        private TextBox addressTextBox;
        private DataGridViewTextBoxColumn ID_org;
        private DataGridViewTextBoxColumn OrganizationName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewComboBoxColumn OrganizationDrop;
        private DataGridViewImageColumn Image;
        private Panel panel1;
        private Panel panel2;
        private Label label8;
        private TextBox orgSearchBox;
        private ComboBox orgComboBoxSearch;
        private Button btnOrgSearch;
        private Panel panel3;
        private Label label7;
        private TextBox empSearchBox;
        private ComboBox empComboBoxSearch;
        private Button btnEmpSearch;
    }
}