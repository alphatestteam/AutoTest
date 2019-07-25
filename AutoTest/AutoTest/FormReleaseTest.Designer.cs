namespace AutoTest
{
    partial class FormReleaseTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReleaseTest));
            this.comboBox_TestItem = new System.Windows.Forms.ComboBox();
            this.button_Pass = new System.Windows.Forms.Button();
            this.button_Fail = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.button_None = new System.Windows.Forms.Button();
            this.textBox_Comment = new System.Windows.Forms.TextBox();
            this.dataGridView_Report = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Generate = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Last = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_TestItem
            // 
            this.comboBox_TestItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_TestItem.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_TestItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TestItem.Enabled = false;
            this.comboBox_TestItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_TestItem.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_TestItem.FormattingEnabled = true;
            this.comboBox_TestItem.ItemHeight = 20;
            this.comboBox_TestItem.Location = new System.Drawing.Point(28, 39);
            this.comboBox_TestItem.Name = "comboBox_TestItem";
            this.comboBox_TestItem.Size = new System.Drawing.Size(245, 28);
            this.comboBox_TestItem.TabIndex = 0;
            this.comboBox_TestItem.SelectedIndexChanged += new System.EventHandler(this.comboBox_TestItem_SelectedIndexChanged);
            // 
            // button_Pass
            // 
            this.button_Pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_Pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pass.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Pass.Location = new System.Drawing.Point(311, 299);
            this.button_Pass.Name = "button_Pass";
            this.button_Pass.Size = new System.Drawing.Size(75, 23);
            this.button_Pass.TabIndex = 1;
            this.button_Pass.Text = "PASS";
            this.button_Pass.UseVisualStyleBackColor = false;
            this.button_Pass.Click += new System.EventHandler(this.button_Pass_Click);
            // 
            // button_Fail
            // 
            this.button_Fail.BackColor = System.Drawing.Color.Red;
            this.button_Fail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Fail.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Fail.Location = new System.Drawing.Point(409, 299);
            this.button_Fail.Name = "button_Fail";
            this.button_Fail.Size = new System.Drawing.Size(75, 23);
            this.button_Fail.TabIndex = 2;
            this.button_Fail.Text = "FAIL";
            this.button_Fail.UseVisualStyleBackColor = false;
            this.button_Fail.Click += new System.EventHandler(this.button_Fail_Click);
            // 
            // button_Run
            // 
            this.button_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Run.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Run.Location = new System.Drawing.Point(112, 299);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 3;
            this.button_Run.Text = "RUN";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // button_None
            // 
            this.button_None.BackColor = System.Drawing.Color.Silver;
            this.button_None.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_None.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_None.Location = new System.Drawing.Point(503, 299);
            this.button_None.Name = "button_None";
            this.button_None.Size = new System.Drawing.Size(75, 23);
            this.button_None.TabIndex = 5;
            this.button_None.Text = "NONE";
            this.button_None.UseVisualStyleBackColor = false;
            this.button_None.Click += new System.EventHandler(this.button_None_Click);
            // 
            // textBox_Comment
            // 
            this.textBox_Comment.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Comment.Location = new System.Drawing.Point(28, 82);
            this.textBox_Comment.Multiline = true;
            this.textBox_Comment.Name = "textBox_Comment";
            this.textBox_Comment.Size = new System.Drawing.Size(245, 195);
            this.textBox_Comment.TabIndex = 6;
            this.textBox_Comment.TextChanged += new System.EventHandler(this.textBox_Comment_TextChanged);
            // 
            // dataGridView_Report
            // 
            this.dataGridView_Report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Report.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_Report.Location = new System.Drawing.Point(311, 39);
            this.dataGridView_Report.Name = "dataGridView_Report";
            this.dataGridView_Report.ReadOnly = true;
            this.dataGridView_Report.RowTemplate.Height = 24;
            this.dataGridView_Report.Size = new System.Drawing.Size(443, 238);
            this.dataGridView_Report.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Test";
            this.Column1.FillWeight = 90F;
            this.Column1.HeaderText = "Test";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Result";
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "Result";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Comment";
            this.Column3.FillWeight = 89.0863F;
            this.Column3.HeaderText = "Comment";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // button_Generate
            // 
            this.button_Generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Generate.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Generate.Location = new System.Drawing.Point(660, 299);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(94, 23);
            this.button_Generate.TabIndex = 8;
            this.button_Generate.Text = "GENERATE";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // button_Next
            // 
            this.button_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Next.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Next.Location = new System.Drawing.Point(198, 299);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(75, 23);
            this.button_Next.TabIndex = 9;
            this.button_Next.Text = "NEXT";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Last
            // 
            this.button_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Last.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Last.Location = new System.Drawing.Point(25, 299);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(75, 23);
            this.button_Last.TabIndex = 10;
            this.button_Last.Text = "LAST";
            this.button_Last.UseVisualStyleBackColor = true;
            this.button_Last.Click += new System.EventHandler(this.button_Last_Click);
            // 
            // FormReleaseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 357);
            this.Controls.Add(this.button_Last);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.dataGridView_Report);
            this.Controls.Add(this.textBox_Comment);
            this.Controls.Add(this.button_None);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.button_Fail);
            this.Controls.Add(this.button_Pass);
            this.Controls.Add(this.comboBox_TestItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReleaseTest";
            this.Text = "Release Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReleaseTest_FormClosed);
            this.Load += new System.EventHandler(this.FormReleaseTest_Load);
            this.Shown += new System.EventHandler(this.FormReleaseTest_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox_TestItem;
        private System.Windows.Forms.Button button_Pass;
        private System.Windows.Forms.Button button_Fail;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Button button_None;
        private System.Windows.Forms.TextBox textBox_Comment;
        private System.Windows.Forms.DataGridView dataGridView_Report;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Last;
    }
}