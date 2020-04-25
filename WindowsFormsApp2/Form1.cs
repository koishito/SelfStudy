using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //if (Directory.Exists(TextBox1.txt))
            InitializeComponent();
        }

        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("ボタンをクリックすると終了します。");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            AcceptButton = button3;
            //Form3 newForm = new Form3();
            //newForm.StartPosition = FormStartPosition.CenterScreen;
            //newForm.ShowDialog();
            linkLabel1.Text = "秀和システムを開きます。";
            linkLabel1.Links.Add(0, 6, "www.shuwasystem.co.jp");
            linkLabel2.Text = "Form5を開きます。";
            linkLabel2.LinkArea=new LinkArea(0, 5);
            label1.Text = textBox1.Text;
            radioButton4.Checked = true;
            string[] myArray = new string[] { "テニス", "バドミントン", "陸上", "柔道", "水泳" };
            comboBox1.Items.AddRange(myArray);
            leftToolStripMenuItem.Enabled = false;
            //MessageBox.Show(Convert.ToInt32(true).ToString());
            toolStripStatusLabel1.Text = DateTime.Today.ToShortDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.StartPosition = FormStartPosition.CenterParent;
            newForm.ShowDialog();
            //MessageBox.Show("label1：" + label1.Text, "入力内容");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.StartPosition = FormStartPosition.CenterScreen;
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Width += 10;
            //Height += 10;
            Size = new Size(Width + 10, Height + 10);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AboutBox1 newForm = new AboutBox1();
            newForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string linktarget;
            linktarget = linkLabel1.Links[0].LinkData.ToString();
            System.Diagnostics.Process.Start(linktarget);

            linkLabel1.LinkVisited = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("パスワード："+ textBox2.Text,"入力内容");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text ="no checked";
            foreach (RadioButton myradioButton in groupBox1.Controls)
            {
                if (myradioButton.Checked)
                {
                    label1.Text = myradioButton.Text;
                    break;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            foreach (Object myList in listBox1.SelectedItems)
            {
                if (label1.Text != "") 
                {
                    label1.Text += Environment.NewLine;
                }
                label1.Text += myList;

            }

            //label1.Text = listBox1.SelectedIndex.ToString()+ Environment.NewLine + listBox1.SelectedItem.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            /*for (int i = listBox1.Items.Count-1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    listBox1.Items.RemoveAt(i);
                }
            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedItem.ToString();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {
            leftToolStripMenuItem.Enabled = true;
            centerToolStripMenuItem.Enabled = true;
            rightToolStripMenuItem.Enabled = true;
            switch (textBox1.TextAlign)
            {
                case HorizontalAlignment.Left:
                    leftToolStripMenuItem.Enabled = false;
                    break;
                case HorizontalAlignment.Center:
                    centerToolStripMenuItem.Enabled = false;
                    break;
                default:
                    rightToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void boldToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1FontStyle();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boldToolStripMenuItem.Checked = !boldToolStripMenuItem.Checked;
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            italicToolStripMenuItem.Checked = !italicToolStripMenuItem.Checked;
        }

        private void italicToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox1FontStyle();
        }

        private void textBox1FontStyle()
        {
            textBox1.Font = new Font(textBox1.Font, ((boldToolStripMenuItem.Checked) ? FontStyle.Bold : 0) | ((italicToolStripMenuItem.Checked) ? FontStyle.Italic : 0));

            //switch (((boldToolStripMenuItem.Checked) ? "Bold" : "") + ((italicToolStripMenuItem.Checked) ? "Italic" : ""))
            ////switch (boldToolStripMenuItem.Checked.ToString() + italicToolStripMenuItem.Checked.ToString())
            //{
            //    case "BoldItalic":
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Bold | FontStyle.Italic);
            //        break;
            //    case "Bold":
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            //        break;
            //    case "Italic":
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            //        break;
            //    default:
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            //        break;
            //}


            //MessageBox.Show(((byte)true).ToString());

            ////MessageBox.Show((((boldToolStripMenuItem.Checked) ? 2 : 0) + ((italicToolStripMenuItem.Checked) ? 1 : 0)).ToString());
            //switch (((boldToolStripMenuItem.Checked) ? 2 : 0) + ((italicToolStripMenuItem.Checked) ? 1 : 0))
            //{
            //    case 3:
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Bold | FontStyle.Italic);
            //        break;
            //    case 2:
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            //        break;
            //    case 1:
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            //        break;
            //    default:
            //        textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            //        break;
            //}
        }

        private void leftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox myobj = (TextBox)contextMenuStrip1.SourceControl;
            myobj.TextAlign = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox myobj = (TextBox)contextMenuStrip1.SourceControl;
            myobj.TextAlign = HorizontalAlignment.Center;
        }

        private void rightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox myobj = (TextBox)contextMenuStrip1.SourceControl;
            myobj.TextAlign = HorizontalAlignment.Right;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            textBox1.Font = new Font(textBox1.Font, ((toolStripButton1.Checked) ? FontStyle.Bold : 0));

        }

    }
}
