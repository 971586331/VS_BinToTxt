namespace VS_BinToTxt
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_open = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_save = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_check = new System.Windows.Forms.Button();
            this.label_filenum = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_CurrentInput = new System.Windows.Forms.Label();
            this.label_CurrentOutput = new System.Windows.Forms.Label();
            this.label_ShowTime = new System.Windows.Forms.Label();
            this.label_RunTime = new System.Windows.Forms.Label();
            this.label_SystemResource = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_open
            // 
            this.textBox_open.Location = new System.Drawing.Point(10, 35);
            this.textBox_open.Name = "textBox_open";
            this.textBox_open.Size = new System.Drawing.Size(280, 21);
            this.textBox_open.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "打开要转换的bin文件目录";
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(300, 32);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "保存转换后的txt文件";
            // 
            // textBox_save
            // 
            this.textBox_save.Location = new System.Drawing.Point(10, 90);
            this.textBox_save.Name = "textBox_save";
            this.textBox_save.Size = new System.Drawing.Size(280, 21);
            this.textBox_save.TabIndex = 4;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(300, 90);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_check
            // 
            this.button_check.Location = new System.Drawing.Point(23, 136);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(100, 23);
            this.button_check.TabIndex = 6;
            this.button_check.Text = "检查输入参数";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // label_filenum
            // 
            this.label_filenum.AutoSize = true;
            this.label_filenum.Location = new System.Drawing.Point(21, 170);
            this.label_filenum.Name = "label_filenum";
            this.label_filenum.Size = new System.Drawing.Size(65, 12);
            this.label_filenum.TabIndex = 7;
            this.label_filenum.Text = "文件个数：";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(272, 136);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(100, 23);
            this.button_start.TabIndex = 8;
            this.button_start.Text = "开始转换";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(272, 165);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(100, 23);
            this.button_stop.TabIndex = 9;
            this.button_stop.Text = "结果转换";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 207);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(347, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // label_CurrentInput
            // 
            this.label_CurrentInput.AutoSize = true;
            this.label_CurrentInput.Location = new System.Drawing.Point(21, 242);
            this.label_CurrentInput.Name = "label_CurrentInput";
            this.label_CurrentInput.Size = new System.Drawing.Size(65, 12);
            this.label_CurrentInput.TabIndex = 11;
            this.label_CurrentInput.Text = "正在转换：";
            // 
            // label_CurrentOutput
            // 
            this.label_CurrentOutput.AutoSize = true;
            this.label_CurrentOutput.Location = new System.Drawing.Point(21, 264);
            this.label_CurrentOutput.Name = "label_CurrentOutput";
            this.label_CurrentOutput.Size = new System.Drawing.Size(65, 12);
            this.label_CurrentOutput.TabIndex = 12;
            this.label_CurrentOutput.Text = "输出文件：";
            // 
            // label_ShowTime
            // 
            this.label_ShowTime.AutoSize = true;
            this.label_ShowTime.Location = new System.Drawing.Point(21, 291);
            this.label_ShowTime.Name = "label_ShowTime";
            this.label_ShowTime.Size = new System.Drawing.Size(65, 12);
            this.label_ShowTime.TabIndex = 13;
            this.label_ShowTime.Text = "当前时间：";
            // 
            // label_RunTime
            // 
            this.label_RunTime.AutoSize = true;
            this.label_RunTime.Location = new System.Drawing.Point(21, 313);
            this.label_RunTime.Name = "label_RunTime";
            this.label_RunTime.Size = new System.Drawing.Size(65, 12);
            this.label_RunTime.TabIndex = 14;
            this.label_RunTime.Text = "运行时间：";
            // 
            // label_SystemResource
            // 
            this.label_SystemResource.AutoSize = true;
            this.label_SystemResource.Location = new System.Drawing.Point(21, 335);
            this.label_SystemResource.Name = "label_SystemResource";
            this.label_SystemResource.Size = new System.Drawing.Size(65, 12);
            this.label_SystemResource.TabIndex = 15;
            this.label_SystemResource.Text = "系统资源：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.label_SystemResource);
            this.Controls.Add(this.label_RunTime);
            this.Controls.Add(this.label_ShowTime);
            this.Controls.Add(this.label_CurrentOutput);
            this.Controls.Add(this.label_CurrentInput);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_filenum);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_save;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Label label_filenum;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_CurrentInput;
        private System.Windows.Forms.Label label_CurrentOutput;
        private System.Windows.Forms.Label label_ShowTime;
        private System.Windows.Forms.Label label_RunTime;
        private System.Windows.Forms.Label label_SystemResource;
    }
}

