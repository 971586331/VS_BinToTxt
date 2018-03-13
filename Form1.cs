 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace VS_BinToTxt
{
    public partial class Form1 : Form
    {
        ThreadTest workerObject;
        Thread workerThread;

        public string InputDirectories;
        public string OutputDirectories;

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
            common._syncContext = SynchronizationContext.Current;
            Console.WriteLine("Data_Head_Info = {0}", System.Runtime.InteropServices.Marshal.SizeOf(common.gData_Head_Info));
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
            traverse_dir(InputDirectories, OutputDirectories, ref common.gQueue_Data);
            Console.WriteLine("gQueue_Data.Count = {0}", common.gQueue_Data.Count);
            this.label_filenum.Text = "文件个数： " + common.gQueue_Data.Count.ToString();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            workerObject = new ThreadTest();
            workerThread = new Thread(workerObject.MyThread);
            workerThread.Name = "文件处理线程";
            common.gCurrent_cmd = e_Current_cmd.START_CONVERSION;

            workerThread.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            workerObject.RequestStop();
            workerThread.Join();
            Console.WriteLine("thread stop!");
        }

        private void SetLabelText(object text)
        {
 
        }
    }
}
