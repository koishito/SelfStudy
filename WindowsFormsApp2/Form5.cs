using System;
using System.IO;
using System.Collections;
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
    //private CheckedListBox clb = new CheckedListBox();

    public partial class Form5 : Form
    {
        TimeSpan stTime = new TimeSpan(0, 0, 0);
        TimeSpan addsecond = new TimeSpan(0, 0, 1);

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string[] myArray = new string[] { "テニス", "バドミントン", "陸上", "柔道", "水泳" };
            checkedListBox1.Items.AddRange(myArray);
            checkedListBox1.SetItemChecked(0, true);

            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("ファイル名", 120);
            listView1.Columns.Add("サイズ", 60,HorizontalAlignment.Right);
            listView1.Columns.Add("更新日時", 120);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stTime += addsecond;
            label1.Text = stTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            stTime = new TimeSpan(0, 0, 0);
            label1.Text = stTime.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo;
            FileInfo[] fList;

            listView1.Items.Clear();

            if (System.IO.Directory.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("フォルダが存在しません。", "通知");
                return;
            }

            //dirInfo = new System.IO.DirectoryInfo(textBox1.Text);
            //fList = dirInfo.GetFiles();
            dirInfo = new DirectoryInfo(textBox1.Text);
            FileSystemInfo[] dirArray = dirInfo.GetFileSystemInfos();

            //foreach (System.IO.FileInfo fInfo in fList)
            foreach (FileSystemInfo fInfo in dirArray)
            {
                //Boolean fl = (fInfo.Attributes.HasFlag(FileAttributes.Directory)) && (!(fInfo.Attributes.HasFlag(FileAttributes.Hidden)))
                Boolean fl = (((fInfo.Attributes & FileAttributes.Directory) != 0) &&
                              ((fInfo.Attributes & FileAttributes.Hidden) == 0));
                if (fl)
                {
                    ListViewItem fItem = new ListViewItem(fInfo.Name);
                    fItem.SubItems.Add(@"(folder)");
                    fItem.SubItems.Add(fInfo.LastWriteTime.ToShortDateString());
                    listView1.Items.Add(fItem);
                }
            }

            foreach (FileSystemInfo fInfo in dirArray)
            {
                Boolean fl = (((fInfo.Attributes & (FileAttributes.Directory | FileAttributes.Hidden)) == 0));
                if (fl)
                {
                    FileInfo file = new FileInfo(fInfo.FullName);
                    ListViewItem fItem = new ListViewItem(file.Name);
                    fItem.SubItems.Add(file.Length.ToString());
                    fItem.SubItems.Add(file.LastWriteTime.ToShortDateString());
                    listView1.Items.Add(fItem);
                }
            }

            //foreach (FileSystemInfo fInfo in dirArray)
            //{
            //    ListViewItem fItem = new ListViewItem(fInfo.Name);
            //    FileInfo file = new FileInfo(fInfo.FullName);
            //    fItem.SubItems.Add(File.Exists(fInfo.FullName) ? file.Length.ToString() : "(folder)");
            //    //fItem.SubItems.Add(fInfo.Length.ToString());
            //    fItem.SubItems.Add(fInfo.LastWriteTime.ToShortDateString());
            //    listView1.Items.Add(fItem);
            //}

            listView1.Sort();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
    }
}
