
using System;
using System.IO;
using System.Collections.Generic;
using System.StubHelpers;
using System.Runtime.InteropServices;
using System.Threading;

//输入输出文件结构体
public struct Data_Node
{
    public string InputFilePath;    //输入文件的路径
    public string OutputFilePath;   //输出文件的路径
};

//当前状态
public enum e_Current_cmd
{
    NO_INSTRUCT,        //没有任务
    START_CONVERSION,   //开始转换
    CONVERSION_FINISH,   //转换完成
};

//数据文件头
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Data_Head_Info
{
    public uint time;                   //时间
    public uint data_len;               //数据的长度(byte)
    public uint sample_multiple;        //采样档位
    public uint sampling_gear;          //采样频率档位
    public uint sampling_freq;          //采样频率(HZ)
    public ushort Gear;                 //档位
    public float Software_Multiple;     //软件倍数
    public ushort excursion;            //偏移
    public float Capacity;              //最大量程
};

public static class common // static 不是必须
{
    private static string name = "cc";
    public static string Name
    {
        get { return name; }
        set { name = value; }
    }

    public static Queue<Data_Node> gQueue_Data = new Queue<Data_Node>();

    public static e_Current_cmd gCurrent_cmd;
    public static Data_Head_Info gData_Head_Info;
}