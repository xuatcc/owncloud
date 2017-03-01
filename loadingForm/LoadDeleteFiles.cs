using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud.loadingForm
{
    /// <summary>
    /// 删除等待窗体
    /// </summary>
    public partial class LoadDeleteFiles : Form
    {
        /// <summary>
        /// 删除操作线程
        /// </summary>
        Thread ThreadDelete;
        Queue<string> FileNames = new Queue<string>();
        Queue<string> KeyNames = new Queue<string>();
        public LoadDeleteFiles()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_status.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) closeForm();
        }
        /// <summary>
        /// 鼠标移入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseEnter_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseDown_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseUp_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="keyNames"></param>
        public void deleteItems(Queue<string> fileNames, Queue<string> keyNames)
        {
            if (fileNames.Count != keyNames.Count)
            {
                closeForm();
            }
            FileNames = fileNames;
            KeyNames = keyNames;
            ThreadDelete = new Thread(threadDeleteItems);
            ThreadDelete.Start();
        }
        /// <summary>
        /// 删除线程
        /// </summary>
        void threadDeleteItems()
        {
            try
            {
                deleteFiles();
                MethodInvoker methodInvoker = new MethodInvoker(closeForm);
                BeginInvoke(methodInvoker);
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 删除操作细节
        /// </summary>
        void deleteFiles()
        {
            string fileName;
            string key;
            while (FileNames.Count > 0)
            {
                fileName = FileNames.Dequeue();
                key = KeyNames.Dequeue();
                if (key.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    fileName += MyConfig.EXTEND_NAME_ENCRYP_FILE;
                    File.Delete(fileName);
                }
                else if (key.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    FileTree.deleteDirectory(fileName);
                }
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        void closeForm()
        {
            if (ThreadDelete != null) ThreadDelete.Abort();
            this.Close();
        }
        /// <summary>
        /// 关闭窗体前先退出线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDeleteFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadDelete != null) ThreadDelete.Abort();
        }
    }
}
