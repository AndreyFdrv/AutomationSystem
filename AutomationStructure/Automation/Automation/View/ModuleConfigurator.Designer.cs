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
            this.applyBtn = new System.Windows.Forms.Button();
            this.schemesPbx = new System.Windows.Forms.PictureBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moduleNameTxb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numberLbl = new System.Windows.Forms.Label();
            this.schemeNameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.schemesPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(585, 511);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(84, 33);
            this.applyBtn.TabIndex = 5;
            this.applyBtn.Text = "Применить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // schemesPbx
            // 
            this.schemesPbx.Location = new System.Drawing.Point(12, 84);
            this.schemesPbx.Name = "schemesPbx";
            this.schemesPbx.Size = new System.Drawing.Size(657, 361);
            this.schemesPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.schemesPbx.TabIndex = 1;
            this.schemesPbx.TabStop = false;
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(247, 464);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 34);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "Назад";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(343, 464);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 34);
            this.NextBtn.TabIndex = 2;
            this.NextBtn.Text = "Вперёд";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название модуля:";
            // 
            // moduleNameTxb
            // 
            this.moduleNameTxb.Location = new System.Drawing.Point(133, 17);
            this.moduleNameTxb.Name = "moduleNameTxb";
            this.moduleNameTxb.Size = new System.Drawing.Size(310, 20);
            this.moduleNameTxb.TabIndex = 0;
            this.moduleNameTxb.Text = "тест";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер:";
            // 
            // numberLbl
            // 
            this.numberLbl.AutoSize = true;
            this.numberLbl.Location = new System.Drawing.Point(65, 534);
            this.numberLbl.Name = "numberLbl";
            this.numberLbl.Size = new System.Drawing.Size(0, 13);
            this.numberLbl.TabIndex = 6;
            // 
            // schemeNameLbl
            // 
            this.schemeNameLbl.AutoSize = true;
            this.schemeNameLbl.Location = new System.Drawing.Point(169, 530);
            this.schemeNameLbl.Name = "schemeNameLbl";
            this.schemeNameLbl.Size = new System.Drawing.Size(35, 13);
            this.schemeNameLbl.TabIndex = 7;
            this.schemeNameLbl.Text = "schemeNameLbl";
            // 
            // ModuleConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 556);
            this.Controls.Add(this.schemeNameLbl);
            this.Controls.Add(this.numberLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moduleNameTxb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.schemesPbx);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleConfigurator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурирование модуля";
            ((System.ComponentModel.ISupportInitialize)(this.schemesPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.PictureBox schemesPbx;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moduleNameTxb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numberLbl;
        private System.Windows.Forms.Label schemeNameLbl;
    }
}