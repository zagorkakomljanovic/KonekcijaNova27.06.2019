namespace konekcija
{
    partial class frmCARDHOLDER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCARDHOLDER));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cboxCARDHOLDER = new System.Windows.Forms.ComboBox();
            this.lblRadnik = new System.Windows.Forms.Label();
            this.dgCHECKLIST = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWorktime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardholderIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFIRM = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDO = new System.Windows.Forms.Label();
            this.lblOD = new System.Windows.Forms.Label();
            this.btnPRINT = new System.Windows.Forms.Button();
            this.checkComboBox1 = new konekcija.CheckComboBox();
            this.logIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controllerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardholderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardholderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCHECKLIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessLogBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(40, 53);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // cboxCARDHOLDER
            // 
            this.cboxCARDHOLDER.DisplayMember = "Name";
            this.cboxCARDHOLDER.FormattingEnabled = true;
            this.cboxCARDHOLDER.Location = new System.Drawing.Point(73, 29);
            this.cboxCARDHOLDER.Margin = new System.Windows.Forms.Padding(2);
            this.cboxCARDHOLDER.Name = "cboxCARDHOLDER";
            this.cboxCARDHOLDER.Size = new System.Drawing.Size(191, 21);
            this.cboxCARDHOLDER.TabIndex = 2;
            this.cboxCARDHOLDER.ValueMember = "Name";
            this.cboxCARDHOLDER.SelectedIndexChanged += new System.EventHandler(this.cboxCARDHOLDER_SelectedIndexChanged);
            // 
            // lblRadnik
            // 
            this.lblRadnik.AutoSize = true;
            this.lblRadnik.Location = new System.Drawing.Point(6, 32);
            this.lblRadnik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadnik.Name = "lblRadnik";
            this.lblRadnik.Size = new System.Drawing.Size(45, 13);
            this.lblRadnik.TabIndex = 3;
            this.lblRadnik.Text = "Worker:";
            // 
            // dgCHECKLIST
            // 
            this.dgCHECKLIST.AllowUserToAddRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.dgCHECKLIST.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCHECKLIST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCHECKLIST.AutoGenerateColumns = false;
            this.dgCHECKLIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCHECKLIST.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.direction,
            this.localTime,
            this.TotalWorktime,
            this.CardholderIDColumn,
            this.Name});
            this.dgCHECKLIST.DataSource = this.accessLogBindingSource;
            this.dgCHECKLIST.Location = new System.Drawing.Point(29, 362);
            this.dgCHECKLIST.Margin = new System.Windows.Forms.Padding(2);
            this.dgCHECKLIST.Name = "dgCHECKLIST";
            this.dgCHECKLIST.ReadOnly = true;
            this.dgCHECKLIST.RowTemplate.Height = 24;
            this.dgCHECKLIST.Size = new System.Drawing.Size(438, 400);
            this.dgCHECKLIST.TabIndex = 4;
            this.dgCHECKLIST.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgCHECKLIST_CellFormatting);
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // direction
            // 
            this.direction.DataPropertyName = "Direction";
            this.direction.HeaderText = "Direction";
            this.direction.Name = "direction";
            this.direction.ReadOnly = true;
            // 
            // localTime
            // 
            this.localTime.DataPropertyName = "LocalTime";
            this.localTime.HeaderText = "LocalTime";
            this.localTime.Name = "localTime";
            this.localTime.ReadOnly = true;
            // 
            // TotalWorktime
            // 
            this.TotalWorktime.DataPropertyName = "LogID";
            this.TotalWorktime.HeaderText = "TotalWorktime";
            this.TotalWorktime.Name = "TotalWorktime";
            this.TotalWorktime.ReadOnly = true;
            // 
            // CardholderIDColumn
            // 
            this.CardholderIDColumn.DataPropertyName = "CardholderID";
            this.CardholderIDColumn.HeaderText = "CardholderID";
            this.CardholderIDColumn.Name = "CardholderIDColumn";
            this.CardholderIDColumn.ReadOnly = true;
            this.CardholderIDColumn.Visible = false;
            // 
            // accessLogBindingSource
            // 
            this.accessLogBindingSource.DataSource = typeof(konekcija.AccessLog);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFIRM);
            this.groupBox1.Controls.Add(this.cboxCARDHOLDER);
            this.groupBox1.Controls.Add(this.lblRadnik);
            this.groupBox1.Location = new System.Drawing.Point(29, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(415, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnFIRM
            // 
            this.btnFIRM.Location = new System.Drawing.Point(306, 27);
            this.btnFIRM.Name = "btnFIRM";
            this.btnFIRM.Size = new System.Drawing.Size(95, 23);
            this.btnFIRM.TabIndex = 4;
            this.btnFIRM.Text = "Firm";
            this.btnFIRM.UseVisualStyleBackColor = true;
            this.btnFIRM.Click += new System.EventHandler(this.btnFIRM_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDO);
            this.groupBox2.Controls.Add(this.lblOD);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(29, 264);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(287, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblDO
            // 
            this.lblDO.AutoSize = true;
            this.lblDO.Location = new System.Drawing.Point(15, 56);
            this.lblDO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDO.Name = "lblDO";
            this.lblDO.Size = new System.Drawing.Size(21, 13);
            this.lblDO.TabIndex = 3;
            this.lblDO.Text = "Do";
            // 
            // lblOD
            // 
            this.lblOD.AutoSize = true;
            this.lblOD.Location = new System.Drawing.Point(15, 23);
            this.lblOD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOD.Name = "lblOD";
            this.lblOD.Size = new System.Drawing.Size(21, 13);
            this.lblOD.TabIndex = 2;
            this.lblOD.Text = "Od";
            // 
            // btnPRINT
            // 
            this.btnPRINT.Location = new System.Drawing.Point(335, 287);
            this.btnPRINT.Name = "btnPRINT";
            this.btnPRINT.Size = new System.Drawing.Size(95, 34);
            this.btnPRINT.TabIndex = 7;
            this.btnPRINT.Text = "Print";
            this.btnPRINT.UseVisualStyleBackColor = true;
            this.btnPRINT.Click += new System.EventHandler(this.btnPRINT_Click);
            // 
            // checkComboBox1
            // 
            this.checkComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.checkComboBox1.FormattingEnabled = true;
            this.checkComboBox1.Location = new System.Drawing.Point(454, 164);
            this.checkComboBox1.Name = "checkComboBox1";
            this.checkComboBox1.Size = new System.Drawing.Size(171, 21);
            this.checkComboBox1.TabIndex = 8;
            this.checkComboBox1.SelectedIndexChanged += new System.EventHandler(this.checkComboBox1_SelectedIndexChanged);
            // 
            // logIDDataGridViewTextBoxColumn
            // 
            this.logIDDataGridViewTextBoxColumn.DataPropertyName = "LogID";
            this.logIDDataGridViewTextBoxColumn.HeaderText = "LogID";
            this.logIDDataGridViewTextBoxColumn.Name = "logIDDataGridViewTextBoxColumn";
            // 
            // cardCodeDataGridViewTextBoxColumn
            // 
            this.cardCodeDataGridViewTextBoxColumn.DataPropertyName = "CardCode";
            this.cardCodeDataGridViewTextBoxColumn.HeaderText = "CardCode";
            this.cardCodeDataGridViewTextBoxColumn.Name = "cardCodeDataGridViewTextBoxColumn";
            // 
            // cardTypeDataGridViewTextBoxColumn
            // 
            this.cardTypeDataGridViewTextBoxColumn.DataPropertyName = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.HeaderText = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.Name = "cardTypeDataGridViewTextBoxColumn";
            // 
            // controllerIDDataGridViewTextBoxColumn
            // 
            this.controllerIDDataGridViewTextBoxColumn.DataPropertyName = "ControllerID";
            this.controllerIDDataGridViewTextBoxColumn.HeaderText = "ControllerID";
            this.controllerIDDataGridViewTextBoxColumn.Name = "controllerIDDataGridViewTextBoxColumn";
            // 
            // directionDataGridViewTextBoxColumn
            // 
            this.directionDataGridViewTextBoxColumn.DataPropertyName = "Direction";
            this.directionDataGridViewTextBoxColumn.HeaderText = "Direction";
            this.directionDataGridViewTextBoxColumn.Name = "directionDataGridViewTextBoxColumn";
            // 
            // localTimeDataGridViewTextBoxColumn
            // 
            this.localTimeDataGridViewTextBoxColumn.DataPropertyName = "LocalTime";
            this.localTimeDataGridViewTextBoxColumn.HeaderText = "LocalTime";
            this.localTimeDataGridViewTextBoxColumn.Name = "localTimeDataGridViewTextBoxColumn";
            // 
            // cardholderIDDataGridViewTextBoxColumn
            // 
            this.cardholderIDDataGridViewTextBoxColumn.DataPropertyName = "CardholderID";
            this.cardholderIDDataGridViewTextBoxColumn.HeaderText = "CardholderID";
            this.cardholderIDDataGridViewTextBoxColumn.Name = "cardholderIDDataGridViewTextBoxColumn";
            // 
            // cardholderDataGridViewTextBoxColumn
            // 
            this.cardholderDataGridViewTextBoxColumn.DataPropertyName = "Cardholder";
            this.cardholderDataGridViewTextBoxColumn.HeaderText = "Cardholder";
            this.cardholderDataGridViewTextBoxColumn.Name = "cardholderDataGridViewTextBoxColumn";
            // 
            // frmCARDHOLDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(628, 790);
            this.Controls.Add(this.checkComboBox1);
            this.Controls.Add(this.btnPRINT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgCHECKLIST);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cardholder";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCHECKLIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessLogBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cboxCARDHOLDER;
        private System.Windows.Forms.Label lblRadnik;
        private System.Windows.Forms.DataGridView dgCHECKLIST;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDO;
        private System.Windows.Forms.Label lblOD;
        private System.Windows.Forms.Button btnPRINT;
        private System.Windows.Forms.Button btnFIRM;
        private CheckComboBox checkComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn logIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn controllerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardholderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardholderDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource accessLogBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn localTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWorktime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardholderIDColumn;
    }
}