namespace WindowsFormsApplication1
{
    partial class Form_MCManage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检验名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.取样部门 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.包装 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报验日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.化验日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报告日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品批号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检验依据 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结论 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.审核员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.分析员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.化验人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.详情 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.检验名称,
            this.取样部门,
            this.规格,
            this.数量,
            this.包装,
            this.报验日期,
            this.化验日期,
            this.报告日期,
            this.产品批号,
            this.检验依据,
            this.结论,
            this.审核员,
            this.分析员,
            this.化验人,
            this.详情});
            this.dataGridView1.Location = new System.Drawing.Point(5, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(915, 373);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // 编号
            // 
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Width = 54;
            // 
            // 检验名称
            // 
            this.检验名称.HeaderText = "检验名称";
            this.检验名称.Name = "检验名称";
            this.检验名称.ReadOnly = true;
            this.检验名称.Width = 78;
            // 
            // 取样部门
            // 
            this.取样部门.HeaderText = "取样部门";
            this.取样部门.Name = "取样部门";
            this.取样部门.ReadOnly = true;
            this.取样部门.Width = 78;
            // 
            // 规格
            // 
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            this.规格.ReadOnly = true;
            this.规格.Width = 54;
            // 
            // 数量
            // 
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Width = 54;
            // 
            // 包装
            // 
            this.包装.HeaderText = "包装";
            this.包装.Name = "包装";
            this.包装.ReadOnly = true;
            this.包装.Width = 54;
            // 
            // 报验日期
            // 
            this.报验日期.HeaderText = "报验日期";
            this.报验日期.Name = "报验日期";
            this.报验日期.ReadOnly = true;
            this.报验日期.Width = 78;
            // 
            // 化验日期
            // 
            this.化验日期.HeaderText = "化验日期";
            this.化验日期.Name = "化验日期";
            this.化验日期.ReadOnly = true;
            this.化验日期.Width = 78;
            // 
            // 报告日期
            // 
            this.报告日期.HeaderText = "报告日期";
            this.报告日期.Name = "报告日期";
            this.报告日期.ReadOnly = true;
            this.报告日期.Width = 78;
            // 
            // 产品批号
            // 
            this.产品批号.HeaderText = "产品批号";
            this.产品批号.Name = "产品批号";
            this.产品批号.ReadOnly = true;
            this.产品批号.Width = 78;
            // 
            // 检验依据
            // 
            this.检验依据.HeaderText = "检验依据";
            this.检验依据.Name = "检验依据";
            this.检验依据.ReadOnly = true;
            this.检验依据.Width = 78;
            // 
            // 结论
            // 
            this.结论.HeaderText = "结论";
            this.结论.Name = "结论";
            this.结论.ReadOnly = true;
            this.结论.Width = 54;
            // 
            // 审核员
            // 
            this.审核员.HeaderText = "审核员";
            this.审核员.Name = "审核员";
            this.审核员.ReadOnly = true;
            this.审核员.Width = 66;
            // 
            // 分析员
            // 
            this.分析员.HeaderText = "分析员";
            this.分析员.Name = "分析员";
            this.分析员.ReadOnly = true;
            this.分析员.Width = 66;
            // 
            // 化验人
            // 
            this.化验人.HeaderText = "化验人";
            this.化验人.Name = "化验人";
            this.化验人.ReadOnly = true;
            this.化验人.Width = 66;
            // 
            // 详情
            // 
            this.详情.HeaderText = "详情";
            this.详情.Name = "详情";
            this.详情.ReadOnly = true;
            this.详情.Width = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "药品检验表：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(591, 422);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 69;
            this.label18.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "结果总数:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 424);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 67;
            this.label17.Text = "/";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(574, 423);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 66;
            this.label16.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(203, 424);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 65;
            this.label15.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 424);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 64;
            this.label14.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(426, 417);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 63;
            this.button5.Text = "跳转";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(788, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 62;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(765, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "个";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(696, 419);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 21);
            this.textBox2.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(637, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "每页显示";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 58;
            this.label6.Text = "页";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(337, 421);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 21);
            this.textBox3.TabIndex = 57;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(256, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(63, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 55;
            this.button4.Text = "上一页";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form_MCManage
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
           // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 452);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
           // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_MCManage";
           // this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品检验管理";
            //this.Load += new System.EventHandler(this.Form_MCManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检验名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 取样部门;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 包装;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报验日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 化验日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报告日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品批号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检验依据;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结论;
        private System.Windows.Forms.DataGridViewTextBoxColumn 审核员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 分析员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 化验人;
        private System.Windows.Forms.DataGridViewButtonColumn 详情;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}