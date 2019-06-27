namespace konekcija
{
    partial class frmNONWORKINGDAYS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNONWORKINGDAYS));
            this.label1 = new System.Windows.Forms.Label();
            this.cboxCARDHOLDER = new System.Windows.Forms.ComboBox();
            this.cardholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtTOTAL = new System.Windows.Forms.TextBox();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxFIRM = new System.Windows.Forms.ComboBox();
            this.firmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.gbCONTRACT = new System.Windows.Forms.GroupBox();
            this.btnDELETE = new System.Windows.Forms.Button();
            this.btnADD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddNewReligion = new System.Windows.Forms.Button();
            this.btnAssignReligion = new System.Windows.Forms.Button();
            this.cbxReligion = new System.Windows.Forms.ComboBox();
            this.religionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.cardholderBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).BeginInit();
            this.gbCONTRACT.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.religionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Worker:";
            // 
            // cboxCARDHOLDER
            // 
            this.cboxCARDHOLDER.DataSource = this.cardholderBindingSource;
            this.cboxCARDHOLDER.DisplayMember = "NAME";
            this.cboxCARDHOLDER.FormattingEnabled = true;
            this.cboxCARDHOLDER.Location = new System.Drawing.Point(67, 62);
            this.cboxCARDHOLDER.Name = "cboxCARDHOLDER";
            this.cboxCARDHOLDER.Size = new System.Drawing.Size(182, 21);
            this.cboxCARDHOLDER.TabIndex = 1;
            this.cboxCARDHOLDER.SelectedIndexChanged += new System.EventHandler(this.cboxCARDHOLDER_SelectedIndexChanged);
            // 
            // cardholderBindingSource
            // 
            this.cardholderBindingSource.DataSource = typeof(konekcija.Cardholder);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total:";
            // 
            // txtTOTAL
            // 
            this.txtTOTAL.Location = new System.Drawing.Point(60, 35);
            this.txtTOTAL.MaxLength = 2;
            this.txtTOTAL.Name = "txtTOTAL";
            this.txtTOTAL.Size = new System.Drawing.Size(76, 20);
            this.txtTOTAL.TabIndex = 3;
            this.txtTOTAL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTOTAL_KeyPress);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Location = new System.Drawing.Point(161, 35);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(75, 23);
            this.btnSAVE.TabIndex = 4;
            this.btnSAVE.Text = "Save";
            this.btnSAVE.UseVisualStyleBackColor = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnSAVE);
            this.groupBox1.Controls.Add(this.txtTOTAL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(369, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of days";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxCARDHOLDER);
            this.groupBox2.Controls.Add(this.cboxFIRM);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(23, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Worker";
            // 
            // cboxFIRM
            // 
            this.cboxFIRM.DataSource = this.firmBindingSource;
            this.cboxFIRM.DisplayMember = "Name";
            this.cboxFIRM.FormattingEnabled = true;
            this.cboxFIRM.Location = new System.Drawing.Point(67, 20);
            this.cboxFIRM.Name = "cboxFIRM";
            this.cboxFIRM.Size = new System.Drawing.Size(182, 21);
            this.cboxFIRM.TabIndex = 3;
            this.cboxFIRM.TextChanged += new System.EventHandler(this.cboxFIRM_TextChanged);
            // 
            // firmBindingSource
            // 
            this.firmBindingSource.DataSource = typeof(konekcija.Firm);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Firm:";
            // 
            // gbCONTRACT
            // 
            this.gbCONTRACT.Controls.Add(this.btnDELETE);
            this.gbCONTRACT.Controls.Add(this.btnADD);
            this.gbCONTRACT.Controls.Add(this.label6);
            this.gbCONTRACT.Controls.Add(this.label5);
            this.gbCONTRACT.Controls.Add(this.dateTimePicker2);
            this.gbCONTRACT.Controls.Add(this.dateTimePicker1);
            this.gbCONTRACT.Location = new System.Drawing.Point(23, 336);
            this.gbCONTRACT.Name = "gbCONTRACT";
            this.gbCONTRACT.Size = new System.Drawing.Size(275, 153);
            this.gbCONTRACT.TabIndex = 7;
            this.gbCONTRACT.TabStop = false;
            this.gbCONTRACT.Text = "Contract";
            // 
            // btnDELETE
            // 
            this.btnDELETE.Location = new System.Drawing.Point(198, 116);
            this.btnDELETE.Name = "btnDELETE";
            this.btnDELETE.Size = new System.Drawing.Size(68, 24);
            this.btnDELETE.TabIndex = 6;
            this.btnDELETE.Text = "Delete";
            this.btnDELETE.UseVisualStyleBackColor = true;
            this.btnDELETE.Click += new System.EventHandler(this.btnDELETE_Click);
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(19, 117);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(62, 24);
            this.btnADD.TabIndex = 4;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(67, 83);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(67, 39);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddNewReligion);
            this.groupBox4.Controls.Add(this.btnAssignReligion);
            this.groupBox4.Controls.Add(this.cbxReligion);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(305, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 130);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Religion";
            // 
            // btnAddNewReligion
            // 
            this.btnAddNewReligion.Location = new System.Drawing.Point(94, 77);
            this.btnAddNewReligion.Name = "btnAddNewReligion";
            this.btnAddNewReligion.Size = new System.Drawing.Size(106, 23);
            this.btnAddNewReligion.TabIndex = 6;
            this.btnAddNewReligion.Text = "Add New Religion";
            this.btnAddNewReligion.UseVisualStyleBackColor = true;
            this.btnAddNewReligion.Click += new System.EventHandler(this.btnAddNewReligion_Click);
            // 
            // btnAssignReligion
            // 
            this.btnAssignReligion.Location = new System.Drawing.Point(301, 23);
            this.btnAssignReligion.Name = "btnAssignReligion";
            this.btnAssignReligion.Size = new System.Drawing.Size(75, 23);
            this.btnAssignReligion.TabIndex = 5;
            this.btnAssignReligion.Text = "Assign";
            this.btnAssignReligion.UseVisualStyleBackColor = true;
            this.btnAssignReligion.Click += new System.EventHandler(this.btnAssignReligion_Click);
            // 
            // cbxReligion
            // 
            this.cbxReligion.DataSource = this.religionBindingSource;
            this.cbxReligion.DisplayMember = "Name";
            this.cbxReligion.FormattingEnabled = true;
            this.cbxReligion.Location = new System.Drawing.Point(94, 25);
            this.cbxReligion.Name = "cbxReligion";
            this.cbxReligion.Size = new System.Drawing.Size(182, 21);
            this.cbxReligion.TabIndex = 3;
            this.cbxReligion.SelectedIndexChanged += new System.EventHandler(this.cbxReligion_SelectedIndexChanged);
            //this.cbxReligion.Click += new System.EventHandler(this.cbxReligion_Click);
            //this.cbxReligion.TextChanged += new System.EventHandler(this.cbxReligion_TextChanged);
            // 
            // religionBindingSource
            // 
            this.religionBindingSource.DataSource = typeof(konekcija.Religion);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Choose religion:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // frmNONWORKINGDAYS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(712, 545);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbCONTRACT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmNONWORKINGDAYS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non-working days";
            this.Load += new System.EventHandler(this.frmNONWORKINGDAYS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardholderBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).EndInit();
            this.gbCONTRACT.ResumeLayout(false);
            this.gbCONTRACT.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.religionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxCARDHOLDER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTOTAL;
        private System.Windows.Forms.BindingSource cardholderBindingSource;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboxFIRM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbCONTRACT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.BindingSource firmBindingSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddNewReligion;
        private System.Windows.Forms.Button btnAssignReligion;
        private System.Windows.Forms.ComboBox cbxReligion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource religionBindingSource;
        private System.Windows.Forms.Button btnDELETE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Diagnostics.EventLog eventLog1;
    }
}