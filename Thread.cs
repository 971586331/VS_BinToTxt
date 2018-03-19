
using System.IO;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VS_BinToTxt
{
    public partial class Form1
    {
        int i = 0;
        int Current_Count = 0;
        Data_Node outdata = new Data_Node();

        public void MyThread()
        {
            while (!_shouldStop)
            {
                switch (common.gCurrent_cmd)
                {
                    case e_Current_cmd.NO_INSTRUCT:
                    {
                        Thread.Sleep(1000); break;
                    }
                    case e_Current_cmd.START_CONVERSION:
                    {
                        try
                        {
                            outdata = common.gQueue_Data.Dequeue();
                        }
                        catch (System.InvalidOperationException)
                        {
                            // 错误处理代码
                            common.gCurrent_cmd = e_Current_cmd.CONVERSION_FINISH;
                            Current_Count = 0;
                            break;
                        }

                        //Console.WriteLine("正在转换！");
                        //Console.WriteLine("Thread inputfile = {0}", outdata.InputFilePath);
                        //Console.WriteLine("Thread outputfile = {0}", outdata.OutputFilePath);

                        Data_Head_Info file_head = new Data_Head_Info();
                        byte[] file_buffer = new byte[32L * 1024L * 1024L];
                        read_file_f(outdata.InputFilePath, ref file_buffer, sizeof(ushort), ref file_head, sizeof(char), System.Runtime.InteropServices.Marshal.SizeOf(common.gData_Head_Info));

                        StreamWriter sw = new StreamWriter(outdata.OutputFilePath);
                        for (i = 0; i < file_head.data_len / sizeof(ushort) - 2; i++)
                        {
                            ushort num = BitConverter.ToUInt16(file_buffer, i * 2);
                            sw.WriteLine(num.ToString());
                        }
                        sw.Close();
                        Current_Count ++;

                        try
                        {
                            Invoke(new stuInfoDelegate(showStuIfo), new object[] { Current_Count, outdata.InputFilePath, outdata.OutputFilePath }); //线程通过方法的委托执行showStuIfo()，实现对ListBox控件的访问
                        }
                        catch
                        {
                            //Console.WriteLine("屏蔽一个错误！");
                        }
                        
                        break;
                    }
                    case e_Current_cmd.CONVERSION_FINISH:
                    {
                        Console.WriteLine("转换完成！");

                        this.RequestStop();
                        Thread.Sleep(1000);
                        break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void RequestStart()
        {
            _shouldStop = false;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;

        public void read_file_f(string filedir, ref byte[] buff, int data_len, ref Data_Head_Info head, int head_len, int head_num)
        {
            byte[] head_buffer = new byte[head_num];

            BinaryReader br = new BinaryReader(new FileStream(filedir, FileMode.Open));
            head_buffer = br.ReadBytes(head_num);
            head.time = BitConverter.ToUInt32(head_buffer, 0);
            head.data_len = BitConverter.ToUInt32(head_buffer, 4);
            head.sample_multiple = BitConverter.ToUInt32(head_buffer, 8);
            head.sampling_freq = BitConverter.ToUInt32(head_buffer, 12);
            head.Gear = BitConverter.ToUInt16(head_buffer, 16);
            head.Software_Multiple = BitConverter.ToSingle(head_buffer, 20);
            head.excursion = BitConverter.ToUInt16(head_buffer, 24);
            head.Capacity = BitConverter.ToSingle(head_buffer, 28);

            //Console.WriteLine("head.time = {0}", head.time);
            //Console.WriteLine("head.data_len = {0}", head.data_len);
            //Console.WriteLine("head.sample_multiple = {0}", head.sample_multiple);
            //Console.WriteLine("head.sampling_freq = {0}", head.sampling_freq);
            //Console.WriteLine("head.Gear = {0}", head.Gear);
            //Console.WriteLine("head.Software_Multiple = {0}", head.Software_Multiple);
            //Console.WriteLine("head.excursion = {0}", head.excursion);
            //Console.WriteLine("head.Capacity = {0}", head.Capacity);

            buff = br.ReadBytes((int)head.data_len);
            br.Close();
        }
    }
}