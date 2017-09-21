namespace 医药管理系统.drug
{
    partial class addDrug
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.packing = new System.Windows.Forms.ComboBox();
            this.unit = new System.Windows.Forms.ComboBox();
            this.specification = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.bid = new System.Windows.Forms.TextBox();
            this.approval = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.packing);
            this.groupBox1.Controls.Add(this.unit);
            this.groupBox1.Controls.Add(this.specification);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.bid);
            this.groupBox1.Controls.Add(this.approval);
            this.groupBox1.Controls.Add(this.price);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Location = new System.Drawing.Point(70, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "药品信息记录项";
            // 
            // packing
            // 
            this.packing.FormattingEnabled = true;
            this.packing.Location = new System.Drawing.Point(577, 95);
            this.packing.Name = "packing";
            this.packing.Size = new System.Drawing.Size(120, 20);
            this.packing.TabIndex = 5;
            // 
            // unit
            // 
            this.unit.FormattingEnabled = true;
            this.unit.Location = new System.Drawing.Point(577, 27);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(120, 20);
            this.unit.TabIndex = 2;
            this.unit.SelectedIndexChanged += new System.EventHandler(this.unit_SelectedIndexChanged);
            // 
            // specification
            // 
            this.specification.CausesValidation = false;
            this.specification.FormattingEnabled = true;
            this.specification.Location = new System.Drawing.Point(333, 28);
            this.specification.Name = "specification";
            this.specification.Size = new System.Drawing.Size(120, 20);
            this.specification.TabIndex = 1;
            this.specification.SelectedIndexChanged += new System.EventHandler(this.specification_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(72, 26);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(112, 21);
            this.name.TabIndex = 0;
            // 
            // bid
            // 
            this.bid.Location = new System.Drawing.Point(72, 97);
            this.bid.Name = "bid";
            this.bid.Size = new System.Drawing.Size(112, 21);
            this.bid.TabIndex = 3;
            this.bid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bid_KeyPress);
            // 
            // approval
            // 
            this.approval.Location = new System.Drawing.Point(72, 167);
            this.approval.Name = "approval";
            this.approval.Size = new System.Drawing.Size(112, 21);
            this.approval.TabIndex = 6;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(333, 97);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(120, 21);
            this.price.TabIndex = 4;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "批准文号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "包装数量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "药品售价";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(287, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 4;
            this.label30.Text = "规格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "记录单位";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 2;
            this.label22.Text = "药品进价";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "药品名";
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(142, 310);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(93, 23);
            this.addbtn.TabIndex = 1;
            this.addbtn.Text = "添加";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // resetbtn
            // 
            this.resetbtn.Location = new System.Drawing.Point(319, 310);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(93, 23);
            this.resetbtn.TabIndex = 2;
            this.resetbtn.Text = "重置";
            this.resetbtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "单位管理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(647, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "规格管理";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addDrug
            // 
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.groupBox1);
            this.Size = new System.Drawing.Size(914, 451);
            this.Text = "添加药品信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox packing;
        private System.Windows.Forms.ComboBox unit;
        private System.Windows.Forms.ComboBox specification;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox bid;
        private System.Windows.Forms.TextBox approval;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}