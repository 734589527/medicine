using InventoryManagentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 医药管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Activated += new EventHandler(Form1_Activated);
            InitializeComponent();
            this.skinEngine1.SkinFile = "MacOS.ssk";
            Login l = new Login(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
