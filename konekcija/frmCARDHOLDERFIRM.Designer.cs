namespace konekcija
{
    partial class frmCARDHOLDERFIRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCARDHOLDERFIRM));
            this.btnASSIGN = new System.Windows.Forms.Button();
            this.cboxCARDHOLDER = new System.Windows.Forms.ComboBox();
            this.cardholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboxFIRM = new System.Windows.Forms.ComboBox();
            this.firmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnMODIFY = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnREMOVE = new System.Windows.Forms.Button();
            this.btnADD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkComboBox1 = new konekcija.CheckComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cardholderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnASSIGN
            // 
            this.btnASSIGN.Location = new System.Drawing.Point(157, 76);
            this.btnASSIGN.Name = "btnASSIGN";
            this.btnASSIGN.Size = new System.Drawing.Size(75, 23);
            this.btnASSIGN.TabIndex = 0;
            this.btnASSIGN.Text = "Assign";
            this.btnASSIGN.UseVisualStyleBackColor = true;
            this.btnASSIGN.Click += new System.EventHandler(this.btnASSIGN_Click);
            // 
            // cboxCARDHOLDER
            // 
            this.cboxCARDHOLDER.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxCARDHOLDER.DataSource = this.cardholderBindingSource;
            this.cboxCARDHOLDER.DisplayMember = "Name";
            this.cboxCARDHOLDER.FormattingEnabled = true;
            this.cboxCARDHOLDER.Location = new System.Drawing.Point(71, 41);
            this.cboxCARDHOLDER.Name = "cboxCARDHOLDER";
            this.cboxCARDHOLDER.Size = new System.Drawing.Size(161, 21);
            this.cboxCARDHOLDER.TabIndex = 1;
            this.cboxCARDHOLDER.SelectedIndexChanged += new System.EventHandler(this.cboxCARDHOLDER_SelectedIndexChanged);
            // 
            // cardholderBindingSource
            // 
            this.cardholderBindingSource.DataSource = typeof(konekcija.Cardholder);
            // 
            // cboxFIRM
            // 
            this.cboxFIRM.DataSource = this.firmBindingSource;
            this.cboxFIRM.DisplayMember = "Name";
            this.cboxFIRM.FormattingEnabled = true;
            this.cboxFIRM.Location = new System.Drawing.Point(283, 41);
            this.cboxFIRM.Name = "cboxFIRM";
            this.cboxFIRM.Size = new System.Drawing.Size(153, 21);
            this.cboxFIRM.TabIndex = 2;
            // 
            // firmBindingSource
            // 
            this.firmBindingSource.DataSource = typeof(konekcija.Firm);
            // 
            // btnMODIFY
            // 
            this.btnMODIFY.Location = new System.Drawing.Point(283, 76);
            this.btnMODIFY.Name = "btnMODIFY";
            this.btnMODIFY.Size = new System.Drawing.Size(75, 23);
            this.btnMODIFY.TabIndex = 3;
            this.btnMODIFY.Text = "Modify";
            this.btnMODIFY.UseVisualStyleBackColor = true;
            this.btnMODIFY.Click += new System.EventHandler(this.btnMODIFY_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkComboBox1);
            this.groupBox1.Controls.Add(this.btnREMOVE);
            this.groupBox1.Controls.Add(this.btnADD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboxCARDHOLDER);
            this.groupBox1.Controls.Add(this.btnASSIGN);
            this.groupBox1.Controls.Add(this.btnMODIFY);
            this.groupBox1.Controls.Add(this.cboxFIRM);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 195);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cardholder - Firm";
            // 
            // btnREMOVE
            // 
            this.btnREMOVE.Location = new System.Drawing.Point(480, 39);
            this.btnREMOVE.Name = "btnREMOVE";
            this.btnREMOVE.Size = new System.Drawing.Size(32, 23);
            this.btnREMOVE.TabIndex = 8;
            this.btnREMOVE.Text = "-";
            this.btnREMOVE.UseVisualStyleBackColor = true;
            this.btnREMOVE.Click += new System.EventHandler(this.btnREMOVE_Click);
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(442, 39);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(32, 23);
            this.btnADD.TabIndex = 7;
            this.btnADD.Text = "+";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Firm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Worker:";
            // 
            // checkComboBox1
            // 
            this.checkComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.checkComboBox1.FormattingEnabled = true;
            this.checkComboBox1.Location = new System.Drawing.Point(71, 155);
            this.checkComboBox1.Name = "checkComboBox1";
            this.checkComboBox1.Size = new System.Drawing.Size(161, 21);
            this.checkComboBox1.TabIndex = 9;
            // 
            // frmCARDHOLDERFIRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(571, 387);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCARDHOLDERFIRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cardholder-Firm";
            this.Load += new System.EventHandler(this.frmCARDHOLDERFIRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardholderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnASSIGN;
        private System.Windows.Forms.ComboBox cboxCARDHOLDER;
        private System.Windows.Forms.ComboBox cboxFIRM;
        private System.Windows.Forms.Button btnMODIFY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource cardholderBindingSource;
        private System.Windows.Forms.Button btnREMOVE;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.BindingSource firmBindingSource;
        private CheckComboBox checkComboBox1;
    }
}