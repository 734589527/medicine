namespace 医药管理系统.drug
{
    partial class queryDrug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lab1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._update = new System.Windows.Forms.DataGridViewButtonColumn();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.update = new System.Windows.Forms.Button();
            this.countTbx = new System.Windows.Forms.TextBox();
            this.lab3 = new System.Windows.Forms.Label();
            this.goTo = new System.Windows.Forms.Button();
            this.lab2 = new System.Windows.Forms.Label();
            this.noTbx = new System.Windows.Forms.TextBox();
            this.nextPage = new System.Windows.Forms.Button();
            this.pageNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pageNo = new System.Windows.Forms.Label();
            this.lastPage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.specificationtbx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numtbx = new System.Windows.Forms.TextBox();
            this.packingtbx = new System.Windows.Forms.TextBox();
            this.pricetbx = new System.Windows.Forms.TextBox();
            this.approvaltbx = new System.Windows.Forms.TextBox();
            this.unittbx = new System.Windows.Forms.TextBox();
            this.bidtbx = new System.Windows.Forms.TextBox();
            this.tbxname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(157, 67);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(0, 12);
            this.lab1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.specification,
            this.cost,
            this.salePrice,
            this.unit,
            this.package,
            this.num,
            this.approval,
            this._update,
            this._delete});
            this.dgv.Location = new System.Drawing.Point(33, 157);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(845, 184);
            this.dgv.TabIndex = 1;
            this.dgv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDown);
            // 
            // id
            // 
            this.id.FillWeight = 70F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "药品名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // specification
            // 
            this.specification.HeaderText = "规格";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.HeaderText = "进价";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 70;
            // 
            // salePrice
            // 
            this.salePrice.HeaderText = "售价";
            this.salePrice.Name = "salePrice";
            this.salePrice.ReadOnly = true;
            this.salePrice.Width = 70;
            // 
            // unit
            // 
            this.unit.HeaderText = "记录单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 80;
            // 
            // package
            // 
            this.package.HeaderText = "包装数量";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 80;
            // 
            // num
            // 
            this.num.HeaderText = "库存量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Width = 70;
            // 
            // approval
            // 
            this.approval.HeaderText = "批准文号";
            this.approval.Name = "approval";
            this.approval.ReadOnly = true;
            this.approval.Width = 80;
            // 
            // _update
            // 
            this._update.HeaderText = "";
            this._update.Name = "_update";
            this._update.ReadOnly = true;
            this._update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._update.Width = 50;
            // 
            // _delete
            // 
            this._delete.HeaderText = "";
            this._delete.Name = "_delete";
            this._delete.ReadOnly = true;
            this._delete.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.countTbx);
            this.panel1.Controls.Add(this.lab3);
            this.panel1.Controls.Add(this.goTo);
            this.panel1.Controls.Add(this.lab2);
            this.panel1.Controls.Add(this.noTbx);
            this.panel1.Controls.Add(this.nextPage);
            this.panel1.Controls.Add(this.pageNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pageNo);
            this.panel1.Controls.Add(this.lastPage);
            this.panel1.Location = new System.Drawing.Point(33, 380);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 31);
            this.panel1.TabIndex = 2;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(637, 5);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 10;
            this.update.Text = "更改";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // countTbx
            // 
            this.countTbx.Location = new System.Drawing.Point(581, 5);
            this.countTbx.Name = "countTbx";
            this.countTbx.Size = new System.Drawing.Size(47, 21);
            this.countTbx.TabIndex = 9;
            // 
            // lab3
            // 
            this.lab3.AutoSize = true;
            this.lab3.Location = new System.Drawing.Point(512, 10);
            this.lab3.Name = "lab3";
            this.lab3.Size = new System.Drawing.Size(53, 12);
            this.lab3.TabIndex = 8;
            this.lab3.Text = "每页显示";
            // 
            // goTo
            // 
            this.goTo.Location = new System.Drawing.Point(421, 5);
            this.goTo.Name = "goTo";
            this.goTo.Size = new System.Drawing.Size(75, 23);
            this.goTo.TabIndex = 7;
            this.goTo.Text = "转到";
            this.goTo.UseVisualStyleBackColor = true;
            this.goTo.Click += new System.EventHandler(this.goTo_Click);
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(398, 10);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(17, 12);
            this.lab2.TabIndex = 6;
            this.lab2.Text = "页";
            // 
            // noTbx
            // 
            this.noTbx.Location = new System.Drawing.Point(345, 5);
            this.noTbx.Name = "noTbx";
            this.noTbx.Size = new System.Drawing.Size(47, 21);
            this.noTbx.TabIndex = 5;
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(246, 5);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(75, 23);
            this.nextPage.TabIndex = 4;
            this.nextPage.Text = "下一页";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // pageNum
            // 
            this.pageNum.AutoSize = true;
            this.pageNum.Location = new System.Drawing.Point(222, 10);
            this.pageNum.Name = "pageNum";
            this.pageNum.Size = new System.Drawing.Size(0, 12);
            this.pageNum.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "/";
            // 
            // pageNo
            // 
            this.pageNo.AutoSize = true;
            this.pageNo.Location = new System.Drawing.Point(188, 10);
            this.pageNo.Name = "pageNo";
            this.pageNo.Size = new System.Drawing.Size(11, 12);
            this.pageNo.TabIndex = 1;
            this.pageNo.Text = "1";
            // 
            // lastPage
            // 
            this.lastPage.Location = new System.Drawing.Point(107, 5);
            this.lastPage.Name = "lastPage";
            this.lastPage.Size = new System.Drawing.Size(75, 23);
            this.lastPage.TabIndex = 0;
            this.lastPage.Text = "上一页";
            this.lastPage.UseVisualStyleBackColor = true;
            this.lastPage.Click += new System.EventHandler(this.lastPage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.specificationtbx);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numtbx);
            this.groupBox1.Controls.Add(this.packingtbx);
            this.groupBox1.Controls.Add(this.pricetbx);
            this.groupBox1.Controls.Add(this.approvaltbx);
            this.groupBox1.Controls.Add(this.unittbx);
            this.groupBox1.Controls.Add(this.bidtbx);
            this.groupBox1.Controls.Add(this.tbxname);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // specificationtbx
            // 
            this.specificationtbx.Location = new System.Drawing.Point(529, 70);
            this.specificationtbx.Name = "specificationtbx";
            this.specificationtbx.Size = new System.Drawing.Size(83, 21);
            this.specificationtbx.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "规格";
            // 
            // numtbx
            // 
            this.numtbx.Location = new System.Drawing.Point(530, 28);
            this.numtbx.Name = "numtbx";
            this.numtbx.Size = new System.Drawing.Size(83, 21);
            this.numtbx.TabIndex = 4;
            this.numtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numtbx_KeyPress);
            // 
            // packingtbx
            // 
            this.packingtbx.Location = new System.Drawing.Point(386, 70);
            this.packingtbx.Name = "packingtbx";
            this.packingtbx.Size = new System.Drawing.Size(83, 21);
            this.packingtbx.TabIndex = 7;
            this.packingtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.packingtbx_KeyPress);
            // 
            // pricetbx
            // 
            this.pricetbx.Location = new System.Drawing.Point(223, 70);
            this.pricetbx.Name = "pricetbx";
            this.pricetbx.Size = new System.Drawing.Size(83, 21);
            this.pricetbx.TabIndex = 6;
            this.pricetbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pricetbx_KeyPress);
            // 
            // approvaltbx
            // 
            this.approvaltbx.Location = new System.Drawing.Point(92, 70);
            this.approvaltbx.Name = "approvaltbx";
            this.approvaltbx.Size = new System.Drawing.Size(83, 21);
            this.approvaltbx.TabIndex = 5;
            // 
            // unittbx
            // 
            this.unittbx.Location = new System.Drawing.Point(386, 28);
            this.unittbx.Name = "unittbx";
            this.unittbx.Size = new System.Drawing.Size(83, 21);
            this.unittbx.TabIndex = 3;
            // 
            // bidtbx
            // 
            this.bidtbx.Location = new System.Drawing.Point(223, 28);
            this.bidtbx.Name = "bidtbx";
            this.bidtbx.Size = new System.Drawing.Size(83, 21);
            this.bidtbx.TabIndex = 1;
            this.bidtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bidtbx_KeyPress);
            // 
            // tbxname
            // 
            this.tbxname.Location = new System.Drawing.Point(92, 28);
            this.tbxname.Name = "tbxname";
            this.tbxname.Size = new System.Drawing.Size(83, 21);
            this.tbxname.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "包装数量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "批准文号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "库存量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "记录单位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "售价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "进价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "药品名";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(760, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // queryDrug
            // 
            this.ClientSize = new System.Drawing.Size(914, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lab1);
            this.Name = "queryDrug";
            this.Text = "药品信息查看";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox countTbx;
        private System.Windows.Forms.Label lab3;
        private System.Windows.Forms.Button goTo;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.TextBox noTbx;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label pageNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pageNo;
        private System.Windows.Forms.Button lastPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox numtbx;
        private System.Windows.Forms.TextBox packingtbx;
        private System.Windows.Forms.TextBox pricetbx;
        private System.Windows.Forms.TextBox approvaltbx;
        private System.Windows.Forms.TextBox unittbx;
        private System.Windows.Forms.TextBox bidtbx;
        private System.Windows.Forms.TextBox tbxname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox specificationtbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn approval;
        private System.Windows.Forms.DataGridViewButtonColumn _update;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
        private System.Windows.Forms.Button button3;
    }
}

