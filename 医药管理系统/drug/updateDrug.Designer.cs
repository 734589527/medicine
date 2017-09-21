namespace 医药管理系统.drug
{
    partial class updateDrug
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
            this.Icon = new System.Drawing.Icon("C:\\Users\\159\\Desktop\\5000个ICO图标文件\\pop_soft\\netscape03.ico");
            this.specification = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.bid = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.packing = new System.Windows.Forms.ComboBox();
            this.unit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.approval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // specification
            // 
            this.specification.CausesValidation = false;
            this.specification.FormattingEnabled = true;
            this.specification.Location = new System.Drawing.Point(116, 61);
            this.specification.Name = "specification";
            this.specification.Size = new System.Drawing.Size(112, 20);
            this.specification.TabIndex = 1;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(116, 20);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(112, 21);
            this.name.TabIndex = 0;
            // 
            // bid
            // 
            this.bid.Location = new System.Drawing.Point(116, 103);
            this.bid.Name = "bid";
            this.bid.Size = new System.Drawing.Size(112, 21);
            this.bid.TabIndex = 2;
            this.bid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bid_KeyPress);
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(116, 143);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(112, 21);
            this.price.TabIndex = 3;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "药品售价";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(70, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 18;
            this.label30.Text = "规格";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(46, 106);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 17;
            this.label22.Text = "药品进价";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(58, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 16;
            this.label25.Text = "药品名";
            // 
            // packing
            // 
            this.packing.FormattingEnabled = true;
            this.packing.Location = new System.Drawing.Point(116, 222);
            this.packing.Name = "packing";
            this.packing.Size = new System.Drawing.Size(112, 20);
            this.packing.TabIndex = 5;
            // 
            // unit
            // 
            this.unit.FormattingEnabled = true;
            this.unit.Location = new System.Drawing.Point(116, 184);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(112, 20);
            this.unit.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "包装数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "记录单位";
            // 
            // approval
            // 
            this.approval.Location = new System.Drawing.Point(116, 259);
            this.approval.Name = "approval";
            this.approval.Size = new System.Drawing.Size(112, 21);
            this.approval.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "批准文号";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(116, 302);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(55, 23);
            this.btn.TabIndex = 30;
            this.btn.Text = "确定";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // updateDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 337);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.approval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.packing);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.specification);
            this.Controls.Add(this.name);
            this.Controls.Add(this.bid);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label25);
            this.MaximizeBox = false;
            this.Name = "updateDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改药品信息";
            this.Load += new System.EventHandler(this.updateDrug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox specification;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox bid;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox packing;
        private System.Windows.Forms.ComboBox unit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox approval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn;
    }
}