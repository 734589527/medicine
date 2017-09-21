
using DevComponents.AdvTree;
using InventoryManagentSystem.bean;
using InventoryManagentSystem.Dao;
using System.Collections.Generic;
using System.Windows.Forms;
using 医药管理系统.Dao;
namespace 医药管理系统
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.tabcontrol = new DevExpress.XtraTab.XtraTabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.node10 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node11 = new DevComponents.AdvTree.Node();
            this.node12 = new DevComponents.AdvTree.Node();
            this.node13 = new DevComponents.AdvTree.Node();
            this.node16 = new DevComponents.AdvTree.Node();
            this.node15 = new DevComponents.AdvTree.Node();
            this.node33 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.node17 = new DevComponents.AdvTree.Node();
            this.node18 = new DevComponents.AdvTree.Node();
            this.node19 = new DevComponents.AdvTree.Node();
            this.node20 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node21 = new DevComponents.AdvTree.Node();
            this.node22 = new DevComponents.AdvTree.Node();
            this.node23 = new DevComponents.AdvTree.Node();
            this.node24 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node26 = new DevComponents.AdvTree.Node();
            this.node27 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node28 = new DevComponents.AdvTree.Node();
            this.node100 = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.node29 = new DevComponents.AdvTree.Node();
            this.node30 = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.node31 = new DevComponents.AdvTree.Node();
            this.node32 = new DevComponents.AdvTree.Node();
            this.exit = new DevComponents.AdvTree.Node();
            this.node34 = new DevComponents.AdvTree.Node();
            this.node35 = new DevComponents.AdvTree.Node();
            List<Node> NodeMainList = new List<Node>();
            List<Node> Node1List = new List<Node>();
            List<Node> Node2List = new List<Node>();
            List<Node> Node3List = new List<Node>();
            List<Node> Node4List = new List<Node>();
            List<Node> Node5List = new List<Node>();
            List<Node> Node6List = new List<Node>();
            List<Node> Node7List = new List<Node>();
            List<Node> Node8List = new List<Node>();
             LimitDao limitDao = new LimitDao();
            List<Limit> list1=limitDao.getLimitList();
          for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].getId() == int.Parse(user.part))
                {
                    
                    if (list1[i].getAddComm() == 0 && list1[i].getDeleteComm() == 0 && list1[i].getUpdateComm() == 0)
                    {
                    }
                    else
                    {
                       
                        NodeMainList.Add(this.node1);
                        Node1List.Add(this.node9);
                        if (list1[i].getAddComm() == 1)
                        {
                            Node1List.Add(this.node10);
                        }
                    }
                    if (list1[i].getStoOut() == 0 && list1[i].getStoIn() == 0 && list1[i].getSelectSto() == 0 && list1[i].getAdjustSto() == 0 && list1[i].getStoWarn() == 0 && list1[i].getReadyStoOut() == 0)
                    {

                    }
                    else
                    {
                        NodeMainList.Add(this.node2);
                        if(list1[i].getSelectSto()==1)
                        {
                            Node2List.Add(this.node11);
                        }
                        if(list1[i].getStoIn()==1)
                        {
                            Node2List.Add(this.node12);
                        }
                        if(list1[i].getStoOut()==1)
                        {
                            Node2List.Add(this.node13);
                        }
                        if(list1[i].getReadyStoOut()==1)
                        {
                            Node2List.Add(this.node16);
                        }
                        if(list1[i].getStoWarn()==1)
                        {
                            Node2List.Add(this.node15);
                        }
                        if(list1[i].getAdjustSto()==1)
                        {
                            Node2List.Add(this.node33);
                        }
                    }
                    if(list1[i].getAddSale()==0&&list1[i].getSelectSale()==0&&list1[i].getReGoods()==0&&list1[i].getReOrder()==0)
                    {
                    }
                    else
                    {
                        NodeMainList.Add(this.node3);
                        if(list1[i].getSelectSale()==1)
                        {
                            Node3List.Add(this.node17);
                        }
                         if(list1[i].getAddSale()==1)
                        {
                            Node3List.Add(this.node18);
                        }
                         if(list1[i].getReGoods()==1)
                        {
                            Node3List.Add(this.node20);
                        }
                         if(list1[i].getReOrder()==1)
                        {
                            Node3List.Add(this.node19);
                        }
                    }
                    if(list1[i].getStoInGra()==0&&list1[i].getStoOutGra()==0&&list1[i].getSaleGra()==0&&list1[i].getReGoodsGra()==0)
                    {
                    }
                    else
                    {
                        NodeMainList.Add(node4);
                        if(list1[i].getStoInGra()==1)
                        {
                            Node4List.Add(node21);
                        }
                         if(list1[i].getStoOutGra()==1)
                        {
                            Node4List.Add(node22);
                        }
                         if(list1[i].getSaleGra()==1)
                        {
                            Node4List.Add(node23);
                        }
                         if(list1[i].getReGoodsGra()==1)
                        {
                            Node4List.Add(node24);
                        }
                    }
                    if(list1[i].getAddCus()==0&&list1[i].getDeleteCus()==0&&list1[i].getUpdateCus()==0)
                    {
                    }
                    else
                    {
                        NodeMainList.Add(node5);
                        Node5List.Add(this.node26);
                        if(list1[i].getAddCus()==1)
                        {
                            Node5List.Add(this.node27);
                        }
                    }
                    if(list1[i].getAddVerify()==0&&list1[i].getDeleteVerify()==0&&list1[i].getUpdateVerify()==0)
                    {
                    }
                    else
                    {
                        NodeMainList.Add(this.node6);
                        Node6List.Add(this.node100);
                        if(list1[i].getAddVerify()==1)
                        {
                              Node6List.Add(this.node28);
                        }
                    }
                    if(list1[i].getAddStf()==0&&list1[i].getDeleteStf()==0&&list1[i].getUpdateStf()==0)
                    {
                    }
                    else
                    {
                        NodeMainList.Add(this.node7);
                        Node7List.Add(this.node29);
                        if(list1[i].getAddStf()==1)
                        {
                            Node7List.Add(this.node30);
                        }
                    }
                    if(list1[i].getAddRol()==0&&list1[i].getDeleteRol()==0&&list1[i].getUpdateRol()==0)
                    {}
                    else
                    {
                        NodeMainList.Add(this.node8);
                        if(list1[i].getDeleteRol()==1&&list1[i].getUpdateRol()==1)
                        {
                            Node8List.Add(this.node31);
                        }
                        if(list1[i].getAddRol()==1)
                        {
                            Node8List.Add(this.node32);
                        }
                    }
                }
            }
          NodeMainList.Add(this.exit);
                this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.Icon = new System.Drawing.Icon("C:\\Users\\159\\Desktop\\5000个ICO图标文件\\pop_soft\\netscape03.ico");
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // tabcontrol
            // 
            this.tabcontrol.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabcontrol.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Close | DevExpress.XtraTab.TabButtons.Default)));
            this.tabcontrol.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded;
            this.tabcontrol.Location = new System.Drawing.Point(167, 82);
            this.tabcontrol.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.tabcontrol.Size = new System.Drawing.Size(931, 529);
            this.tabcontrol.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.advTree1);
            this.panel1.Location = new System.Drawing.Point(1, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 524);
            this.panel1.TabIndex = 2;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.advTree1.Location = new System.Drawing.Point(3, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node2,
            this.node3,
            this.node4,
            this.node5,
            this.node6,
            this.node7,
            this.node8,
            this.exit}*/
                NodeMainList.ToArray());
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(155, 521);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.Click += new System.EventHandler(this.advTree1_Click);
            // 
            // node1
            // 
            if (Node1List != null)
            {
                this.node1.Name = "node1";
                this.node1.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node9,
            this.node10}*/
                    Node1List.ToArray());
                this.node1.Text = "商品管理";
            }
            // 
            // node9
            // 
            this.node9.Expanded = true;
            this.node9.Name = "node9";
            this.node9.Text = "商品管理";

            // 
            // node10
            // 
            this.node10.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.node10.Expanded = true;
            this.node10.Name = "node10";
            this.node10.Text = "新增商品";
            // 
            // node2
            // 
            if (Node2List!=null)
            {
                
                Node[] node2s = Node2List.ToArray();
                this.node2.Name = "node2";
                for (int i = 0; i < Node2List.Count; i++)
                {
                    this.node2.Nodes.Add(Node2List[i]);
                }       
                this.node2.Text = "库存管理";
            }
            // 
            // node11
            // 
            this.node11.Expanded = true;
            this.node11.Name = "node11";
            this.node11.Text = "库存管理";
            // 
            // node12
            // 
            this.node12.Expanded = true;
            this.node12.Name = "node12";
            this.node12.Text = "入库管理";
            // 
            // node13
            // 
            this.node13.Expanded = true;
            this.node13.Name = "node13";
            this.node13.Text = "出库管理";
            // 
            // node16
            // 
            this.node16.Expanded = true;
            this.node16.Name = "node16";
            this.node16.Text = "出库审核";
            // 
            // node15
            // 
            this.node15.Expanded = true;
            this.node15.Name = "node15";
            this.node15.Text = "库存预警";
            // 
            // node33
            // 
            this.node33.Expanded = true;
            this.node33.Name = "node33";
            this.node33.Text = "退货/单审核";
            // 
            // node3
            // 
            if (Node3List != null)
            {
                this.node3.Name = "node3";
                this.node3.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node17,
            this.node18,
            this.node19,
            this.node20}*/Node3List.ToArray());
                this.node3.Text = "销售管理";
            }
            // 
            // node17
            // 
            this.node17.Expanded = true;
            this.node17.Name = "node17";
            this.node17.Text = "销售管理";
            // 
            // node18
            // 
            this.node18.Expanded = true;
            this.node18.Name = "node18";
            this.node18.Text = "新建销售单";
            // 
            // node19
            // 
            this.node19.Expanded = true;
            this.node19.Name = "node19";
            this.node19.Text = "退单管理";
            // 
            // node20
            // 
            this.node20.Expanded = true;
            this.node20.Name = "node20";
            this.node20.Text = "退货管理";
            // 
            // node4
            // 
            if (Node4List != null)
            {
                this.node4.Name = "node4";
                this.node4.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node21,
            this.node22,
            this.node23,
            this.node24}*/Node4List.ToArray());
                this.node4.Text = "统计报表";
            }
            // 
            // node21
            // 
            this.node21.Expanded = true;
            this.node21.Name = "node21";
            this.node21.Text = "入库报表";
            // 
            // node22
            // 
            this.node22.Expanded = true;
            this.node22.Name = "node22";
            this.node22.Text = "出库报表";
            // 
            // node23
            // 
            this.node23.Expanded = true;
            this.node23.Name = "node23";
            this.node23.Text = "销售报表";
            // 
            // node24
            // 
            this.node24.Expanded = true;
            this.node24.Name = "node24";
            this.node24.Text = "退货报表";
            // 
            // node5
            // 
            if (Node5List != null)
            {
                this.node5.Name = "node5";
                this.node5.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node26,
            this.node27}*/
                    Node5List.ToArray());
                this.node5.Text = "客户管理";
            }
            // 
            // node26
            // 
            this.node26.Expanded = true;
            this.node26.Name = "node26";
            this.node26.Text = "客户管理";
            // 
            // node27
            // 
            this.node27.Expanded = true;
            this.node27.Name = "node27";
            this.node27.Text = "新增客户";
            // 
            // node6
            // 
            if (Node6List != null)
            {
                this.node6.Name = "node6";
                this.node6.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node28,
            this.node100}*/Node6List.ToArray());
                this.node6.Text = "药品检验";
            }
            // 
            // node28
            // 
            this.node28.Name = "node28";
            this.node28.Text = "药品检验";
            // 
            // node100
            // 
            this.node100.Expanded = true;
            this.node100.Name = "node100";
            this.node100.Text = "药品检验管理";
            // 
            // node7
            // 
            if (Node7List != null)
            {
                this.node7.Name = "node7";
                this.node7.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node29,
            this.node30}*/Node7List.ToArray());
                this.node7.Text = "员工管理";
            }
            // 
            // node29
            // 
            this.node29.Expanded = true;
            this.node29.Name = "node29";
            this.node29.Text = "员工管理";
            // 
            // node30
            // 
            this.node30.Expanded = true;
            this.node30.Name = "node30";
            this.node30.Text = "员工入职";
            // 
            // node8
            // 
            if (Node8List != null)
            {
                this.node8.Name = "node8";
                this.node8.Nodes.AddRange(/*new DevComponents.AdvTree.Node[] {
            this.node31,
            this.node32}*/Node8List.ToArray());
                this.node8.Text = "角色管理";
            }
            // 
            // node31
            // 
            this.node31.Expanded = true;
            this.node31.Name = "node31";
            this.node31.Text = "角色管理";
            // 
            // node32
            // 
            this.node32.Expanded = true;
            this.node32.Name = "node32";
            this.node32.Text = "新建角色";
            // 
            // exit
            // 
            this.exit.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.exit.Name = "exit";
            this.exit.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node34,
            this.node35});
            this.exit.Text = "退出系统";
            // 
            // node34
            // 
            this.node34.Expanded = true;
            this.node34.Name = "node34";
            this.node34.Text = "退出系统";
            // 
            // node35
            // 
            this.node35.Expanded = true;
            this.node35.Name = "node35";
            this.node35.Text = "切换用户";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.White;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 76);
            this.panel2.TabIndex = 3;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 636);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabcontrol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private DevExpress.XtraTab.XtraTabControl tabcontrol;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.Node node10;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node11;
        private DevComponents.AdvTree.Node node12;
        private DevComponents.AdvTree.Node node13;
        private DevComponents.AdvTree.Node node16;
        private DevComponents.AdvTree.Node node14;
        private DevComponents.AdvTree.Node node15;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node17;
        private DevComponents.AdvTree.Node node18;
        private DevComponents.AdvTree.Node node19;
        private DevComponents.AdvTree.Node node20;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node21;
        private DevComponents.AdvTree.Node node22;
        private DevComponents.AdvTree.Node node23;
        private DevComponents.AdvTree.Node node24;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node26;
        private DevComponents.AdvTree.Node node27;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node28;
        private DevComponents.AdvTree.Node node100;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node29;
        private DevComponents.AdvTree.Node node30;
        private DevComponents.AdvTree.Node node31;
        private DevComponents.AdvTree.Node node32;
        private DevComponents.AdvTree.Node exit;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.AdvTree.Node node34;
        private DevComponents.AdvTree.Node node35;
        private DevComponents.AdvTree.Node node33;
    }
}