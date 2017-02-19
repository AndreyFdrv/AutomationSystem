﻿namespace Automation.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleManager));
            this.allModulesInformationDgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addSimilarModuleBtn = new System.Windows.Forms.Button();
            this.deleteModuleBtn = new System.Windows.Forms.Button();
            this.addNewModuleBtn = new System.Windows.Forms.Button();
            this.modulesLbx = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.selectedModuleInformationDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // allModulesInformationDgv
            // 
            this.allModulesInformationDgv.AllowUserToAddRows = false;
            this.allModulesInformationDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allModulesInformationDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allModulesInformationDgv.Location = new System.Drawing.Point(3, 16);
            this.allModulesInformationDgv.Name = "allModulesInformationDgv";
            this.allModulesInformationDgv.Size = new System.Drawing.Size(961, 338);
            this.allModulesInformationDgv.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addSimilarModuleBtn);
            this.groupBox1.Controls.Add(this.deleteModuleBtn);
            this.groupBox1.Controls.Add(this.addNewModuleBtn);
            this.groupBox1.Controls.Add(this.modulesLbx);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 624);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список модулей";
            // 
            // addSimilarModuleBtn
            // 
            this.addSimilarModuleBtn.Location = new System.Drawing.Point(6, 464);
            this.addSimilarModuleBtn.Name = "addSimilarModuleBtn";
            this.addSimilarModuleBtn.Size = new System.Drawing.Size(94, 40);
            this.addSimilarModuleBtn.TabIndex = 1;
            this.addSimilarModuleBtn.Text = "Добавить предыдущий";
            this.addSimilarModuleBtn.UseVisualStyleBackColor = true;
            this.addSimilarModuleBtn.Click += new System.EventHandler(this.addSimilarBtn_Click);
            // 
            // deleteModuleBtn
            // 
            this.deleteModuleBtn.Location = new System.Drawing.Point(5, 524);
            this.deleteModuleBtn.Name = "deleteModuleBtn";
            this.deleteModuleBtn.Size = new System.Drawing.Size(94, 39);
            this.deleteModuleBtn.TabIndex = 1;
            this.deleteModuleBtn.Text = "Удалить";
            this.deleteModuleBtn.UseVisualStyleBackColor = true;
            this.deleteModuleBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addNewModuleBtn
            // 
            this.addNewModuleBtn.Location = new System.Drawing.Point(6, 407);
            this.addNewModuleBtn.Name = "addNewModuleBtn";
            this.addNewModuleBtn.Size = new System.Drawing.Size(94, 39);
            this.addNewModuleBtn.TabIndex = 1;
            this.addNewModuleBtn.Text = "Добавить";
            this.addNewModuleBtn.UseVisualStyleBackColor = true;
            this.addNewModuleBtn.Click += new System.EventHandler(this.add_Click);
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
            this.groupBox3.Controls.Add(this.applyBtn);
            this.groupBox3.Controls.Add(this.selectedModuleInformationDgv);
            this.groupBox3.Location = new System.Drawing.Point(131, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(967, 258);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка выбранного модуля";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(871, 217);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(78, 29);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "Обновить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.UpdateModuleInfoBtn);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка модулей ";
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView allModulesInformationDgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addSimilarModuleBtn;
        private System.Windows.Forms.Button deleteModuleBtn;
        private System.Windows.Forms.Button addNewModuleBtn;
        private System.Windows.Forms.ListBox modulesLbx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.DataGridView selectedModuleInformationDgv;
    }
}