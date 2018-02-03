namespace Automation.View
{
    partial class ModuleManager
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.modulesLbx = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.allModulesInformationDgv = new Telerik.WinControls.UI.RadGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectedModuleInformationDgv = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radButton4);
            this.groupBox1.Controls.Add(this.radButton3);
            this.groupBox1.Controls.Add(this.radButton2);
            this.groupBox1.Controls.Add(this.modulesLbx);
            this.groupBox1.Location = new System.Drawing.Point(704, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 309);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список модулей";
            // 
            // radButton4
            // 
            this.radButton4.Location = new System.Drawing.Point(6, 128);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(75, 34);
            this.radButton4.TabIndex = 3;
            this.radButton4.Text = "Удалить";
            this.radButton4.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(6, 82);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(75, 35);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "Добавить предыдущий";
            this.radButton3.TextWrap = true;
            this.radButton3.Click += new System.EventHandler(this.addSimilarBtn_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(6, 35);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(75, 35);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Добавить";
            this.radButton2.Click += new System.EventHandler(this.add_Click);
            // 
            // modulesLbx
            // 
            this.modulesLbx.FormattingEnabled = true;
            this.modulesLbx.Location = new System.Drawing.Point(6, 178);
            this.modulesLbx.Name = "modulesLbx";
            this.modulesLbx.Size = new System.Drawing.Size(75, 121);
            this.modulesLbx.TabIndex = 0;
            this.modulesLbx.SelectedIndexChanged += new System.EventHandler(this.modulesLbx_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.allModulesInformationDgv);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 315);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация обо всех модулях";
            // 
            // allModulesInformationDgv
            // 
            this.allModulesInformationDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allModulesInformationDgv.Location = new System.Drawing.Point(3, 18);
            // 
            // 
            // 
            this.allModulesInformationDgv.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.allModulesInformationDgv.Name = "allModulesInformationDgv";
            this.allModulesInformationDgv.ReadOnly = true;
            this.allModulesInformationDgv.Size = new System.Drawing.Size(689, 294);
            this.allModulesInformationDgv.TabIndex = 1;
            this.allModulesInformationDgv.Text = "radGridView1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 213);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка выбранного модуля";
            // 
            // selectedModuleInformationDgv
            // 
            this.selectedModuleInformationDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.selectedModuleInformationDgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectedModuleInformationDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedModuleInformationDgv.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.selectedModuleInformationDgv.ForeColor = System.Drawing.Color.Black;
            this.selectedModuleInformationDgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectedModuleInformationDgv.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.selectedModuleInformationDgv.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.selectedModuleInformationDgv.Name = "selectedModuleInformationDgv";
            this.selectedModuleInformationDgv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectedModuleInformationDgv.Size = new System.Drawing.Size(706, 186);
            this.selectedModuleInformationDgv.TabIndex = 3;
            this.selectedModuleInformationDgv.Text = "radGridView1";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(715, 3);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(76, 29);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Обновить";
            this.radButton1.Click += new System.EventHandler(this.UpdateModuleInfoBtn);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.19802F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.80198F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 546);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 222);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 321);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.selectedModuleInformationDgv, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.radButton1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 192);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ModuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 546);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ModuleManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка модулей ";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox modulesLbx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView allModulesInformationDgv;
        private Telerik.WinControls.UI.RadGridView selectedModuleInformationDgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}