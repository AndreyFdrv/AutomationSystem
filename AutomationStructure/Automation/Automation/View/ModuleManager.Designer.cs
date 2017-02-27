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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modulesLbx = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectedModuleInformationDgv = new System.Windows.Forms.DataGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.allModulesInformationDgv = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radButton4);
            this.groupBox1.Controls.Add(this.radButton3);
            this.groupBox1.Controls.Add(this.radButton2);
            this.groupBox1.Controls.Add(this.modulesLbx);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 624);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список модулей";
            // 
            // modulesLbx
            // 
            this.modulesLbx.FormattingEnabled = true;
            this.modulesLbx.Location = new System.Drawing.Point(6, 16);
            this.modulesLbx.Name = "modulesLbx";
            this.modulesLbx.Size = new System.Drawing.Size(96, 342);
            this.modulesLbx.TabIndex = 0;
            this.modulesLbx.SelectedIndexChanged += new System.EventHandler(this.modulesLbx_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.allModulesInformationDgv);
            this.groupBox2.Location = new System.Drawing.Point(131, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 357);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация обо всех модулях";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radButton1);
            this.groupBox3.Controls.Add(this.selectedModuleInformationDgv);
            this.groupBox3.Location = new System.Drawing.Point(131, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(967, 258);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка выбранного модуля";
            // 
            // selectedModuleInformationDgv
            // 
            this.selectedModuleInformationDgv.AllowUserToAddRows = false;
            this.selectedModuleInformationDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedModuleInformationDgv.Location = new System.Drawing.Point(3, 19);
            this.selectedModuleInformationDgv.Name = "selectedModuleInformationDgv";
            this.selectedModuleInformationDgv.Size = new System.Drawing.Size(958, 183);
            this.selectedModuleInformationDgv.TabIndex = 0;
            this.selectedModuleInformationDgv.Scroll += new System.Windows.Forms.ScrollEventHandler(this.selectedModuleInformationDgv_Scroll);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(876, 215);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(83, 29);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Обновить";
            this.radButton1.Click += new System.EventHandler(this.UpdateModuleInfoBtn);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(6, 364);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(93, 35);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Добавить";
            this.radButton2.Click += new System.EventHandler(this.add_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(6, 405);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(93, 35);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "Добавить предыдущий";
            this.radButton3.TextWrap = true;
            this.radButton3.Click += new System.EventHandler(this.addSimilarBtn_Click);
            // 
            // radButton4
            // 
            this.radButton4.Location = new System.Drawing.Point(6, 453);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(93, 34);
            this.radButton4.TabIndex = 3;
            this.radButton4.Text = "Удалить";
            this.radButton4.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // allModulesInformationDgv
            // 
            this.allModulesInformationDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allModulesInformationDgv.Location = new System.Drawing.Point(3, 18);
            // 
            // 
            // 
            this.allModulesInformationDgv.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.allModulesInformationDgv.Name = "allModulesInformationDgv";
            this.allModulesInformationDgv.Size = new System.Drawing.Size(961, 336);
            this.allModulesInformationDgv.TabIndex = 1;
            this.allModulesInformationDgv.Text = "radGridView1";
            // 
            // ModuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 642);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка модулей ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox modulesLbx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView selectedModuleInformationDgv;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView allModulesInformationDgv;
    }
}