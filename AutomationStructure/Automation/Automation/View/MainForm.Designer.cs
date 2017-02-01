namespace Automation.View
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsProjectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.типИзделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кухняВерхниеМодулиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кухняНижниеМодулиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMI = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.turnBtn = new System.Windows.Forms.Button();
            this.panelCustomer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.customerDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.modulesPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modulesDGV = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).BeginInit();
            this.modulesPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modulesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 696);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1105, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.типИзделияToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectMI,
            this.openProjectMI,
            this.toolStripSeparator1,
            this.saveProjectMI,
            this.saveAsProjectMI,
            this.toolStripSeparator2,
            this.exitMI});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // newProjectMI
            // 
            this.newProjectMI.Name = "newProjectMI";
            this.newProjectMI.Size = new System.Drawing.Size(162, 22);
            this.newProjectMI.Text = "Новый проект";
            this.newProjectMI.Click += new System.EventHandler(this.newProjectMI_Click);
            // 
            // openProjectMI
            // 
            this.openProjectMI.Name = "openProjectMI";
            this.openProjectMI.Size = new System.Drawing.Size(162, 22);
            this.openProjectMI.Text = "Открыть проект";
            this.openProjectMI.Click += new System.EventHandler(this.openProjectMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // saveProjectMI
            // 
            this.saveProjectMI.Name = "saveProjectMI";
            this.saveProjectMI.Size = new System.Drawing.Size(162, 22);
            this.saveProjectMI.Text = "Сохранить";
            this.saveProjectMI.Click += new System.EventHandler(this.save_Click);
            // 
            // saveAsProjectMI
            // 
            this.saveAsProjectMI.Name = "saveAsProjectMI";
            this.saveAsProjectMI.Size = new System.Drawing.Size(162, 22);
            this.saveAsProjectMI.Text = "Сохранить как...";
            this.saveAsProjectMI.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // exitMI
            // 
            this.exitMI.Name = "exitMI";
            this.exitMI.Size = new System.Drawing.Size(162, 22);
            this.exitMI.Text = "Выход";
            this.exitMI.Click += new System.EventHandler(this.close_Click);
            // 
            // типИзделияToolStripMenuItem
            // 
            this.типИзделияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кухняВерхниеМодулиToolStripMenuItem,
            this.кухняНижниеМодулиToolStripMenuItem});
            this.типИзделияToolStripMenuItem.Name = "типИзделияToolStripMenuItem";
            this.типИзделияToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.типИзделияToolStripMenuItem.Text = "Тип изделия";
            // 
            // кухняВерхниеМодулиToolStripMenuItem
            // 
            this.кухняВерхниеМодулиToolStripMenuItem.Name = "кухняВерхниеМодулиToolStripMenuItem";
            this.кухняВерхниеМодулиToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.кухняВерхниеМодулиToolStripMenuItem.Text = "Кухня верхние модули";
            this.кухняВерхниеМодулиToolStripMenuItem.Click += new System.EventHandler(this.kitchenUpModules_Click);
            // 
            // кухняНижниеМодулиToolStripMenuItem
            // 
            this.кухняНижниеМодулиToolStripMenuItem.Name = "кухняНижниеМодулиToolStripMenuItem";
            this.кухняНижниеМодулиToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.кухняНижниеМодулиToolStripMenuItem.Text = "Кухня нижние модули";
            this.кухняНижниеМодулиToolStripMenuItem.Click += new System.EventHandler(this.kitchenDownModules_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMI});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // aboutMI
            // 
            this.aboutMI.Name = "aboutMI";
            this.aboutMI.Size = new System.Drawing.Size(149, 22);
            this.aboutMI.Text = "О программе";
            this.aboutMI.Click += new System.EventHandler(this.about_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panelCustomer);
            this.flowLayoutPanel1.Controls.Add(this.modulesPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1105, 672);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.turnBtn);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 36);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ОФОРМЛЕНИЕ ЗАКАЗА";
            // 
            // turnBtn
            // 
            this.turnBtn.Location = new System.Drawing.Point(8, 3);
            this.turnBtn.Name = "turnBtn";
            this.turnBtn.Size = new System.Drawing.Size(29, 30);
            this.turnBtn.TabIndex = 0;
            this.turnBtn.UseVisualStyleBackColor = true;
            this.turnBtn.Click += new System.EventHandler(this.turn_Click);
            // 
            // panelCustomer
            // 
            this.panelCustomer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCustomer.Controls.Add(this.button1);
            this.panelCustomer.Controls.Add(this.customerDGV);
            this.panelCustomer.Controls.Add(this.label3);
            this.panelCustomer.Location = new System.Drawing.Point(3, 45);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Size = new System.Drawing.Size(1097, 263);
            this.panelCustomer.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(999, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "SaveChanges";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customerDGV
            // 
            this.customerDGV.AllowUserToAddRows = false;
            this.customerDGV.AllowUserToDeleteRows = false;
            this.customerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.customerDGV.Location = new System.Drawing.Point(9, 72);
            this.customerDGV.Name = "customerDGV";
            this.customerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDGV.Size = new System.Drawing.Size(1072, 142);
            this.customerDGV.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Материал";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Фирма изготовитель";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Цвет";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Код цвета";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Толщина материала";
            this.Column5.Items.AddRange(new object[] {
            "10 мм",
            "16 мм",
            "18 мм",
            "20 мм",
            "22 мм"});
            this.Column5.Name = "Column5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Заказчик:";
            // 
            // modulesPanel
            // 
            this.modulesPanel.Controls.Add(this.groupBox1);
            this.modulesPanel.Controls.Add(this.label4);
            this.modulesPanel.Location = new System.Drawing.Point(3, 314);
            this.modulesPanel.Name = "modulesPanel";
            this.modulesPanel.Size = new System.Drawing.Size(1097, 352);
            this.modulesPanel.TabIndex = 3;
            this.modulesPanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modulesDGV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1097, 352);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление модулей типов изделий";
            // 
            // modulesDGV
            // 
            this.modulesDGV.AllowUserToAddRows = false;
            this.modulesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modulesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            this.modulesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesDGV.Location = new System.Drawing.Point(3, 16);
            this.modulesDGV.Name = "modulesDGV";
            this.modulesDGV.Size = new System.Drawing.Size(1091, 333);
            this.modulesDGV.TabIndex = 2;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Название";
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Количество введёных модулей";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Новый модуль";
            this.Column8.Name = "Column8";
            this.Column8.Text = "Добавить";
            this.Column8.ToolTipText = "Позволяет добавить новый модуль";
            this.Column8.UseColumnTextForButtonValue = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 718);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автоматизированная система проектирования мебели";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCustomer.ResumeLayout(false);
            this.panelCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).EndInit();
            this.modulesPanel.ResumeLayout(false);
            this.modulesPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modulesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectMI;
        private System.Windows.Forms.ToolStripMenuItem openProjectMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveProjectMI;
        private System.Windows.Forms.ToolStripMenuItem saveAsProjectMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMI;
        private System.Windows.Forms.ToolStripMenuItem типИзделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMI;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button turnBtn;
        private System.Windows.Forms.Panel panelCustomer;
        private System.Windows.Forms.Panel modulesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView customerDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView modulesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem кухняВерхниеМодулиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кухняНижниеМодулиToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

