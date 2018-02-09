 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VS_BinToTxt
{
    public partial class Form1 : Form
    {

        struct Data_Node
        {
            string InputFilePath;    //输入文件的路径
            string OutputFilePath;   //输出文件的路径
        };

        Queue<Data_Node> gQueue_Data = new Queue<Data_Node>();

        void traverse_dir(string path, ref Queue<Data_Node> queue)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();

            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo d in dii)
            {
                //traverse_dir(d.Name, ref queue);
                Console.WriteLine("dir = {0}", d.Name);
            } 

            foreach (FileInfo f in fil)
            {
                Data_Node temp;

                Console.WriteLine("file = {0}\\{1}", f.DirectoryName, f.Name);
                //queue.Enqueue(temp);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择bin文件目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
                this.textBox_open.Text = sPath;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择txt存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
                this.textBox_save.Text = sPath;
            }
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            string path = this.textBox_open.Text;
            traverse_dir(path, ref gQueue_Data);
        }

    }
}
