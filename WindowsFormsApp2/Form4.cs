using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        private Button bt = new Button();
        private Button bt2 = new Button();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            /*bt.Text = "Close(&C)";
            bt.Click += new EventHandler(btClick);
            this.Controls.Add(bt);*/

            bt2.Text = "Close2          (&C)";
            bt2.Click += new EventHandler(bt2Click);
            //bt2.Size.Width = 10;
            //bt2.Size.Height = 10;
            this.Controls.Add(bt2);
        }

        public void btClick(Object sender, EventArgs e)
        {
            this.Close();
        }
        public void bt2Click(Object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
