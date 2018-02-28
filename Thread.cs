
using System;
using System.Threading;

class ThreadTest
{
    Data_Node outdata;
    int i;
    Data_Head_Info file_head;
    ushort[] file_buffer = new ushort[32*1024*1024/2];

    public void MyThread()
    {
        while (!_shouldStop)
        {
            Console.WriteLine("这是一个线程在运行");
            
            switch(common.gCurrent_cmd)
            {
                case e_Current_cmd.NO_INSTRUCT:
                {
                    Thread.Sleep(100); break;
                }
                case e_Current_cmd.START_CONVERSION:
                {
                    try
                    {
                        outdata = common.gQueue_Data.Dequeue();
                    }
                    catch( System.InvalidOperationException )
                    {
                       // 错误处理代码
                        common.gCurrent_cmd = e_Current_cmd.CONVERSION_FINISH;
                        break;
                    }

                    Console.WriteLine("Thread inputfile = {0}", outdata.InputFilePath);
                    Console.WriteLine("Thread outputfile = {0}", outdata.OutputFilePath);

                    read_file_f(outdata->InputFilePath, file_buffer, sizeof(ushort), (char *)&file_head, sizeof(char), sizeof(Data_Head_Info));

                    QDateTime current_date_time =QDateTime::currentDateTime();
                    QString current_date =current_date_time.toString("yyyy.MM.dd hh:mm:ss.zzz ddd");
                    qDebug() << current_date << endl;

                    QFile f(QString(QLatin1String(outdata->OutputFilePath)));
                    if(!(f.open(QIODevice::WriteOnly | QIODevice::Text)))
                    {
                        qDebug() << "Open failed" << OutputFile;
                    }
                    QTextStream txtInput(&f);
                    for(i = 0; i < file_head.data_len/sizeof(short int); i ++)
                    {
                        txtInput << file_buff[i] << endl;
                    }
                    f.close();
                    emit signal_updata_state(done_number + 1, total_number, outdata);
                    i = 0;
                    done_number ++;
                    qDebug() << "ssss" << endl;
                    break;
                }
                case CONVERSION_FINISH:
                {
                    msleep(100);
                    break;
                }
            }
            msleep(100);

            Thread.Sleep(1000);
        }
    }
    public void RequestStop()
    {
        _shouldStop = true;
    }
    // Volatile is used as hint to the compiler that this data
    // member will be accessed by multiple threads.
    private volatile bool _shouldStop;

    public void read_file_f(string filedir, ref ushort[] buff, int data_len, ref Data_Head_Info head, int head_len, int head_num)
    { 
    
    }
}