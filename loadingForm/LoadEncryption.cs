using custom_cloud.cmdClass;
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
    public partial class LoadEncryption : Form
    {
        Thread ThreadImport;
        string[] ItemsPath;
        string CurrentPath;
        string Source;
        string Target;
        public LoadEncryption()
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
            if (sender.Equals(button_cancelImport))
            {
                if (ThreadImport != null) ThreadImport.Abort();
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
            if (sender.Equals(button_cancelImport)) button_cancelImport.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancelImport)) button_cancelImport.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseDown_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancelImport)) button_cancelImport.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseUp_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_cancelImport)) button_cancelImport.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="itemsPath"></param>
        /// <param name="fileTree"></param>
        /// <param name="currentPath"></param>
        /// <returns></returns>
        public void importItem(string[] itemsPath, string currentPath)
        {
            if (itemsPath == null) closeForm();
            ItemsPath= itemsPath;
            progressBar_main.Visible = false;
            label_fileStatus.Visible = true;
            progressBar_main.Maximum = itemsPath.Length;
            CurrentPath = currentPath;
            ThreadImport = new Thread(threadImportItems);
            ThreadImport.Start();
        }
        /// <summary>
        /// 导入文件线程
        /// </summary>
        void threadImportItems()
        {
            try
            {
                string newFileName;
                for (int i = 0; i < ItemsPath.Length; i++)
                {
                    if (File.Exists(ItemsPath[i]))
                    {
                        newFileName = FileTree.importFile(ItemsPath[i],
                           CurrentPath + "/" + Path.GetFileName(ItemsPath[i]));
                        /* 加密 */
                        CMDComand.encryptFile(newFileName, newFileName);
                        label_fileStatus.Invoke(new MethodInvoker(delegate
                        {
                            label_fileStatus.Text = "正在处理: " + Path.GetFileName(ItemsPath[i]);
                            label_fileStatus.SetBounds(142 - (label_fileStatus.Width / 2), label_fileStatus.Location.Y, label_fileStatus.Width, label_fileStatus.Height);
                        }
                    ));
                    }
                    else if (Directory.Exists(ItemsPath[i]))
                    {
                        FileTree.importDirectory(ItemsPath[i], CurrentPath + "/" + Path.GetFileName(ItemsPath[i]), label_fileStatus);
                        
                    }
                    
                }
                MethodInvoker methodInvoker = new MethodInvoker(closeForm);
                BeginInvoke(methodInvoker);
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 导入文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public void importFolder(string source, string target)
        {
            Source = source;
            Target = target;
            progressBar_main.Visible = false;
            label_fileStatus.Visible = true;
            ThreadImport = new Thread(threadImportFolder);
            ThreadImport.Start();
        }
        /// <summary>
        /// 导入文件夹线程
        /// </summary>
        void threadImportFolder()
        {
            try
            {
                FileTree.importDirectory(Source, Target, label_fileStatus);
                MethodInvoker methodInvoker = new MethodInvoker(closeForm);
                BeginInvoke(methodInvoker);
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        private void LoadEncryption_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadImport != null) ThreadImport.Abort();
        }
        void closeForm()
        {
            this.Close();
        }
    }
}
