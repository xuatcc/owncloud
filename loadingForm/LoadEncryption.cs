using custom_cloud.cmdClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.loadingForm
{
    public partial class LoadEncryption : Form
    {
        public LoadEncryption()
        {
            InitializeComponent();
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
        public Queue<string> importItem(string[] itemsPath, FileTree fileTree, string currentPath)
        {
            string[] fileNames = itemsPath;
            Queue<string> newFileNames = new Queue<string>();
            for (int i = 0; i < fileNames.Length; i++)
            {
                string newFileName = FileTree.copyFile(fileNames[i],
                    fileTree.getTargetTree(currentPath).RootDirectory.FullName + "/" + Path.GetFileName(fileNames[i]));
                /* 加密 */
                CMDComand.encryptFile(newFileName, newFileName);
                newFileNames.Enqueue(newFileName);
                Application.DoEvents();
            }
            return newFileNames;
        }
        /// <summary>
        /// 导入文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string importFolder(string source, string target)
        {
            return FileTree.copyDirectory(source, target);
        }
    }
}
