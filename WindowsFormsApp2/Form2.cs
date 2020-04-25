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
    public partial class Form2 : Form
    {
        public Form1 f1;

        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f1 = f; // メイン・フォームへの参照を保存

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("textBox1：" + textBox1.Text, "入力内容");
            //Form1 newForm = new Form1();
            //this.textBox1.Text = newForm.label1.Text;
            //MessageBox.Show("textBox1：" + textBox1.Text, "入力内容");
            Label f1_label1 = (Label)f1.Controls["label1"];
            this.textBox1.Text = f1_label1.Text;
            
        }

    }
}
