﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud.loadingForm
{
    /// <summary>
    /// 解密文件时弹出的交互窗体
    /// </summary>
    public partial class LoadDisCryption : Form
    {
        /// <summary>
        /// 标签属性
        /// </summary>
        public string LabelFunction
        {
            get { return label_status.Text; }
            set { label_status.Text = value; }
        }
        /// <summary>
        /// 导出文件线程
        /// </summary>
        Thread ThreadExport;
        Queue<string> FileNames = new Queue<string>();
        Queue<string> KeyNames = new Queue<string>();
        /// <summary>
        /// 文件密钥
        /// </summary>
        string fileKey;
        string Destination;
        public LoadDisCryption()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_status.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancelExport))
            {
                if (ThreadExport != null) ThreadExport.Abort();
                this.Close();
            }
        }
        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseEnter_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancelExport)) button_cancelExport.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancelExport)) button_cancelExport.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseDown_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancelExport)) button_cancelExport.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseUp_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancelExport)) button_cancelExport.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 解密并导出文件
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="keyNames"></param>
        public void exportFiles(Queue<string> fileNames, Queue<string> keyNames, string destination, string fileKey)
        {
            if(fileKey == null)
            {
                closeForm();
            }
            this.fileKey = fileKey;
            label_status.Text = "正在解密文件";
            FileNames = fileNames;
            KeyNames = keyNames;
            Destination = destination;
            ThreadExport = new Thread(threadExport);
            ThreadExport.Start();
        }
        /// <summary>
        /// 解密导出文件线程
        /// </summary>
        void threadExport()
        {
            try
            {
                FileTree.exportItems(FileNames, KeyNames, Destination, label_fileStatus, fileKey);
                MethodInvoker methodInvoker = new MethodInvoker(closeForm);
                BeginInvoke(methodInvoker);
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 不解密导出文件
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="keyNames"></param>
        /// <param name="destination"></param>
        public void exportFilesWithoutDiscryption(Queue<string> fileNames, Queue<string> keyNames, string destination)
        {
            label_status.Text = "正在导出文件";
            FileNames = fileNames;
            KeyNames = keyNames;
            Destination = destination;
            ThreadExport = new Thread(threadExportWithoutDiscryption);
            ThreadExport.Start();
        }
        /// <summary>
        /// 不解密导出文件
        /// </summary>
        void threadExportWithoutDiscryption()
        {
            try
            {
                FileTree.exportItemsWithoutDiscryption(FileNames, KeyNames, Destination, label_fileStatus);
                MethodInvoker methodInvoker = new MethodInvoker(closeForm);
                BeginInvoke(methodInvoker);
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        void closeForm()
        {
            if (ThreadExport != null)
            {
                ThreadExport.Abort();
                this.Close();
            }
        }
    }
}
