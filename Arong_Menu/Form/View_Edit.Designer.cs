namespace Arong_Menu
{
    partial class View_Edit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Edit));
			this.View1 = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// View1
			// 
			this.View1.AllowColumnReorder = true;
			this.View1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.View1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.View1.FullRowSelect = true;
			this.View1.GridLines = true;
			this.View1.HideSelection = false;
			this.View1.Location = new System.Drawing.Point(3, 22);
			this.View1.Margin = new System.Windows.Forms.Padding(4);
			this.View1.Name = "View1";
			this.View1.Size = new System.Drawing.Size(899, 481);
			this.View1.TabIndex = 0;
			this.View1.UseCompatibleStateImageBehavior = false;
			this.View1.View = System.Windows.Forms.View.Details;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.View1);
			this.groupBox1.Location = new System.Drawing.Point(7, 37);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(905, 506);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "信息";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.comboBox2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Location = new System.Drawing.Point(918, 37);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(275, 152);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "选项";
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Location = new System.Drawing.Point(169, 116);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 30);
			this.button1.TabIndex = 15;
			this.button1.Text = "刷新";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "基准";
			// 
			// comboBox2
			// 
			this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(77, 64);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(192, 24);
			this.comboBox2.TabIndex = 13;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "客户";
			// 
			// comboBox1
			// 
			this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(77, 25);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 24);
			this.comboBox1.TabIndex = 11;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// View_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ClientSize = new System.Drawing.Size(1200, 550);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1200, 550);
			this.Name = "View_Edit";
			this.Shadow = true;
			this.ShadowWidth = 15;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "可视化编辑器";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form4_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.View_Edit_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView View1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
	}
}