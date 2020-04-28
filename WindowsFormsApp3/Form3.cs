using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form myfm = new Form();

            RichTextBox myRT = new RichTextBox();
            myRT.Dock = DockStyle.Fill;

            myfm.MdiParent = this;
            myfm.Text = "Doc" + MdiChildren.Length;
            myfm.Size = new Size(200, 200);
            myfm.Controls.Add(myRT);
            myfm.Show();
        }
    }
}
