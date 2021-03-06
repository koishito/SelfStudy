﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mypath = @"D:\_\YXSample\10";

            string[] imgFile = System.IO.Directory.GetFiles(mypath, "*.jpg");

            for (int i = 0; i < imgFile.Length; i++)
            {
                Image myImg = Bitmap.FromFile(imgFile[i]);
                imageList1.Images.Add(myImg);
                listView1.Items.Add(imgFile[i], i);
                myImg.Dispose();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = richTextBox1.UndoActionName;
            DialogResult ans;
            ans = MessageBox.Show("continue?", "confirmation",
                        MessageBoxButtons.YesNo);
            if (ans == DialogResult.Yes)
            {
                richTextBox1.Undo();
                label1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selst = richTextBox1.SelectionStart;
            int sellg = richTextBox1.SelectionLength;
            for (int i = richTextBox1.SelectionStart; i < selst + sellg; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                Font myfont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(myfont.FontFamily, myfont.Size, (myfont.Bold) ? FontStyle.Regular : FontStyle.Bold);
            }
            richTextBox1.SelectionStart = selst;
            richTextBox1.SelectionLength = sellg;
            richTextBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(label2.Text,RichTextBoxStreamType.RichText);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(label2.Text, RichTextBoxStreamType.RichText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 8;
            numericUpDown1.Maximum = 30;
            numericUpDown1.Value = (int)label2.Font.Size;
            numericUpDown1.Increment = 1;

            trackBar1.Minimum = 8;
            trackBar1.Maximum = 30;
            trackBar1.Value = (int)label2.Font.Size;
            trackBar1.TickFrequency = 1;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 3;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Font myfont = label2.Font;
            label2.Font = new Font(myfont.FontFamily, (int) numericUpDown1.Value);
            trackBar1.Value = (int)label2.Font.Size;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Font myfont = label2.Font;
            label2.Font = new Font(myfont.FontFamily, trackBar1.Value);
            numericUpDown1.Value = (int)label2.Font.Size;
        }
    }
}
