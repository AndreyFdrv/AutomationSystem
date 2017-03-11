namespace Automation.View
{
    partial class ModuleConfigurator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleConfigurator));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberLbl = new System.Windows.Forms.Label();
            this.schemeNameLbl = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.moduleNameTxb = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleNameTxb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название модуля:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер:";
            // 
            // numberLbl
            // 
            this.numberLbl.AutoSize = true;
            this.numberLbl.Location = new System.Drawing.Point(65, 517);
            this.numberLbl.Name = "numberLbl";
            this.numberLbl.Size = new System.Drawing.Size(0, 13);
            this.numberLbl.TabIndex = 6;
            // 
            // schemeNameLbl
            // 
            this.schemeNameLbl.AutoSize = true;
            this.schemeNameLbl.Location = new System.Drawing.Point(121, 518);
            this.schemeNameLbl.Name = "schemeNameLbl";
            this.schemeNameLbl.Size = new System.Drawing.Size(89, 13);
            this.schemeNameLbl.TabIndex = 7;
            this.schemeNameLbl.Text = "schemeNameLbl";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radListView1);
            this.radGroupBox1.HeaderText = "Форма модуля";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 58);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(668, 432);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "Форма модуля";
            // 
            // radListView1
            // 
            this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListView1.Location = new System.Drawing.Point(2, 18);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(664, 412);
            this.radListView1.TabIndex = 0;
            this.radListView1.Text = "radListView1";
            this.radListView1.ViewTypeChanged += new System.EventHandler(this.radListView1_ViewTypeChanged);
            // 
            // moduleNameTxb
            // 
            this.moduleNameTxb.Location = new System.Drawing.Point(134, 21);
            this.moduleNameTxb.Name = "moduleNameTxb";
            this.moduleNameTxb.Size = new System.Drawing.Size(310, 20);
            this.moduleNameTxb.TabIndex = 9;
            this.moduleNameTxb.Text = "Тест";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(590, 508);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(83, 33);
            this.radButton1.TabIndex = 10;
            this.radButton1.Text = "Применить";
            this.radButton1.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // ModuleConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 556);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.moduleNameTxb);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.schemeNameLbl);
            this.Controls.Add(this.numberLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleConfigurator";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурирование нового модуля";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleNameTxb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numberLbl;
        private System.Windows.Forms.Label schemeNameLbl;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.UI.RadTextBox moduleNameTxb;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}