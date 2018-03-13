 
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
        Thread workerThread;

        public string InputDirectories;
        public string OutputDirectories;

        public delegate void stuInfoDelegate(int value, string input, string output);  //声明委托类型

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
            Console.WriteLine("Data_Head_Info = {0}", System.Runtime.InteropServices.Marshal.SizeOf(common.gData_Head_Info));

            System.Timers.Timer t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            t.Start();
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
            this.progressBar.Maximum = common.gQueue_Data.Count;
            this.progressBar.Value = 0;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            workerThread = new Thread(MyThread);
            workerThread.Name = "文件处理线程";
            common.gCurrent_cmd = e_Current_cmd.START_CONVERSION;
            RequestStart();
            workerThread.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            RequestStop();
            workerThread.Join();
            Console.WriteLine("thread stop!");
        }

        //委托，用于在线程中防问UI线程的控件
        private void showStuIfo(int value, string input, string output)  //本例中的线程要通过这个方法来访问主线程中的控件
        {
            this.progressBar.Value = value;
            this.label_CurrentInput.Text = input;
            this.label_CurrentOutput.Text = output;
        }

        //1000MS的定时器
        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("1000MS!");
        }

    }
}
