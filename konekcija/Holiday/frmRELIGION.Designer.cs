namespace konekcija
{
    partial class frmRELIGION
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblReligionName = new System.Windows.Forms.Label();
            this.lblReligiousDates = new System.Windows.Forms.Label();
            this.btnReligiousDates = new System.Windows.Forms.Button();
            this.txtTotalReligionDays = new System.Windows.Forms.TextBox();
            this.btnReligionName = new System.Windows.Forms.Button();
            this.cbxReligionName = new System.Windows.Forms.ComboBox();
            this.religionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgReligionHolidays = new System.Windows.Forms.DataGridView();
            this.religionHolidaysDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.religionHolidayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTotalReligiousDays = new System.Windows.Forms.Label();
            this.btnRemoveReligion = new System.Windows.Forms.Button();
            this.btnRemoveReligionDates = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.religionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReligionHolidays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.religionHolidayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 114);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // lblReligionName
            // 
            this.lblReligionName.AutoSize = true;
            this.lblReligionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReligionName.Location = new System.Drawing.Point(42, 59);
            this.lblReligionName.Name = "lblReligionName";
            this.lblReligionName.Size = new System.Drawing.Size(91, 13);
            this.lblReligionName.TabIndex = 1;
            this.lblReligionName.Text = "Religion name:";
            // 
            // lblReligiousDates
            // 
            this.lblReligiousDates.AutoSize = true;
            this.lblReligiousDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReligiousDates.Location = new System.Drawing.Point(38, 118);
            this.lblReligiousDates.Name = "lblReligiousDates";
            this.lblReligiousDates.Size = new System.Drawing.Size(96, 13);
            this.lblReligiousDates.TabIndex = 3;
            this.lblReligiousDates.Text = "Religious Dates";
            // 
            // btnReligiousDates
            // 
            this.btnReligiousDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReligiousDates.Location = new System.Drawing.Point(414, 112);
            this.btnReligiousDates.Name = "btnReligiousDates";
            this.btnReligiousDates.Size = new System.Drawing.Size(84, 25);
            this.btnReligiousDates.TabIndex = 4;
            this.btnReligiousDates.Text = "Add";
            this.btnReligiousDates.UseVisualStyleBackColor = true;
            this.btnReligiousDates.Click += new System.EventHandler(this.btnReligiousDates_Click);
            // 
            // txtTotalReligionDays
            // 
            this.txtTotalReligionDays.Location = new System.Drawing.Point(41, 183);
            this.txtTotalReligionDays.Multiline = true;
            this.txtTotalReligionDays.Name = "txtTotalReligionDays";
            this.txtTotalReligionDays.Size = new System.Drawing.Size(73, 26);
            this.txtTotalReligionDays.TabIndex = 6;
            // 
            // btnReligionName
            // 
            this.btnReligionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReligionName.Location = new System.Drawing.Point(414, 56);
            this.btnReligionName.Name = "btnReligionName";
            this.btnReligionName.Size = new System.Drawing.Size(84, 25);
            this.btnReligionName.TabIndex = 8;
            this.btnReligionName.Text = "Add";
            this.btnReligionName.UseVisualStyleBackColor = true;
            this.btnReligionName.Click += new System.EventHandler(this.btnReligionName_Click);
            // 
            // cbxReligionName
            // 
            this.cbxReligionName.DataSource = this.religionBindingSource;
            this.cbxReligionName.DisplayMember = "Name";
            this.cbxReligionName.FormattingEnabled = true;
            this.cbxReligionName.Location = new System.Drawing.Point(174, 56);
            this.cbxReligionName.Name = "cbxReligionName";
            this.cbxReligionName.Size = new System.Drawing.Size(200, 21);
            this.cbxReligionName.TabIndex = 9;
            this.cbxReligionName.TextChanged += new System.EventHandler(this.txtReligionName_TextChanged);
            // 
            // religionBindingSource
            // 
            this.religionBindingSource.DataSource = typeof(konekcija.Religion);
            // 
            // dgReligionHolidays
            // 
            this.dgReligionHolidays.AutoGenerateColumns = false;
            this.dgReligionHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReligionHolidays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.religionHolidaysDate});
            this.dgReligionHolidays.DataSource = this.religionHolidayBindingSource;
            this.dgReligionHolidays.Location = new System.Drawing.Point(173, 155);
            this.dgReligionHolidays.Name = "dgReligionHolidays";
            this.dgReligionHolidays.Size = new System.Drawing.Size(201, 147);
            this.dgReligionHolidays.TabIndex = 10;
            // 
            // religionHolidaysDate
            // 
            this.religionHolidaysDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.religionHolidaysDate.DataPropertyName = "ReligionHolidaysDate";
            this.religionHolidaysDate.HeaderText = "ReligionHolidaysDate";
            this.religionHolidaysDate.Name = "religionHolidaysDate";
            // 
            // religionHolidayBindingSource
            // 
            this.religionHolidayBindingSource.DataSource = typeof(konekcija.ReligionHoliday);
            // 
            // lblTotalReligiousDays
            // 
            this.lblTotalReligiousDays.AutoSize = true;
            this.lblTotalReligiousDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReligiousDays.Location = new System.Drawing.Point(38, 155);
            this.lblTotalReligiousDays.Name = "lblTotalReligiousDays";
            this.lblTotalReligiousDays.Size = new System.Drawing.Size(124, 13);
            this.lblTotalReligiousDays.TabIndex = 11;
            this.lblTotalReligiousDays.Text = "Total Religious Days";
            // 
            // btnRemoveReligion
            // 
            this.btnRemoveReligion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReligion.Location = new System.Drawing.Point(525, 56);
            this.btnRemoveReligion.Name = "btnRemoveReligion";
            this.btnRemoveReligion.Size = new System.Drawing.Size(80, 25);
            this.btnRemoveReligion.TabIndex = 12;
            this.btnRemoveReligion.Text = "Remove";
            this.btnRemoveReligion.UseVisualStyleBackColor = true;
            this.btnRemoveReligion.Click += new System.EventHandler(this.btnRemoveReligion_Click);
            // 
            // btnRemoveReligionDates
            // 
            this.btnRemoveReligionDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReligionDates.Location = new System.Drawing.Point(523, 112);
            this.btnRemoveReligionDates.Name = "btnRemoveReligionDates";
            this.btnRemoveReligionDates.Size = new System.Drawing.Size(80, 25);
            this.btnRemoveReligionDates.TabIndex = 13;
            this.btnRemoveReligionDates.Text = "Remove";
            this.btnRemoveReligionDates.UseVisualStyleBackColor = true;
            this.btnRemoveReligionDates.Click += new System.EventHandler(this.btnRemoveReligionDates_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.No;
            this.btnClose.Location = new System.Drawing.Point(463, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 29);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRELIGION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 308);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveReligionDates);
            this.Controls.Add(this.btnRemoveReligion);
            this.Controls.Add(this.lblTotalReligiousDays);
            this.Controls.Add(this.dgReligionHolidays);
            this.Controls.Add(this.cbxReligionName);
            this.Controls.Add(this.btnReligionName);
            this.Controls.Add(this.txtTotalReligionDays);
            this.Controls.Add(this.btnReligiousDates);
            this.Controls.Add(this.lblReligiousDates);
            this.Controls.Add(this.lblReligionName);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmRELIGION";
            this.Text = "frmRELIGION";
            this.Load += new System.EventHandler(this.frmRELIGION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.religionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReligionHolidays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.religionHolidayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblReligionName;
        private System.Windows.Forms.Label lblReligiousDates;
        private System.Windows.Forms.Button btnReligiousDates;
        private System.Windows.Forms.TextBox txtTotalReligionDays;
        private System.Windows.Forms.Button btnReligionName;
        private System.Windows.Forms.ComboBox cbxReligionName;
        private System.Windows.Forms.BindingSource religionBindingSource;
        private System.Windows.Forms.DataGridView dgReligionHolidays;
        private System.Windows.Forms.BindingSource religionHolidayBindingSource;
        private System.Windows.Forms.Label lblTotalReligiousDays;
        private System.Windows.Forms.Button btnRemoveReligion;
        private System.Windows.Forms.Button btnRemoveReligionDates;
        private System.Windows.Forms.DataGridViewTextBoxColumn religionHolidaysDate;
        private System.Windows.Forms.Button btnClose;
    }
}