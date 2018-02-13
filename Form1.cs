 
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
        public string InputDirectories;
        public string OutputDirectories;
        struct Data_Node
        {
            public string InputFilePath;    //输入文件的路径
            public string OutputFilePath;   //输出文件的路径
        };

        Queue<Data_Node> gQueue_Data = new Queue<Data_Node>();

        void traverse_dir(string inputpath, string outputpath, ref Queue<Data_Node> queue)
        {
            DirectoryInfo dir = new DirectoryInfo(inputpath);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();

            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo d in dii)
            {
                traverse_dir(d.FullName, outputpath, ref queue);
                //Console.WriteLine("dir = {0}", d.FullName);
            } 

            foreach (FileInfo f in fil)
            {
                Data_Node temp;

                Console.WriteLine("file = {0}\\{1}", f.DirectoryName, f.Name);
                temp.InputFilePath = f.DirectoryName + "\\" + f.Name;
                temp.OutputFilePath = outputpath + temp.InputFilePath.Substring(InputDirectories.Length, temp.InputFilePath.Length - InputDirectories.Length) + ".txt";
                Console.WriteLine("inputdir = {0}", temp.InputFilePath);
                Console.WriteLine("outputdir = {0}", temp.OutputFilePath);

                string dir1 = temp.OutputFilePath.Substring(0, temp.OutputFilePath.LastIndexOf("\\"));
                Console.WriteLine("outputdir1 = {0}", dir1);
                if (Directory.Exists(dir1) == false)
                {
                    Directory.CreateDirectory(dir1);

                }
                queue.Enqueue(temp);
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
                InputDirectories = folder.SelectedPath;
                this.textBox_open.Text = InputDirectories;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择txt存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                OutputDirectories = folder.SelectedPath;
                this.textBox_save.Text = OutputDirectories;
            }
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            InputDirectories = this.textBox_open.Text;
            OutputDirectories = this.textBox_save.Text;
            traverse_dir(InputDirectories, OutputDirectories, ref gQueue_Data);
        }

    }
}
