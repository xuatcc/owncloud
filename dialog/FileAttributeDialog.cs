/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.dialog
{
    public partial class FileAttributeDialog : Form
    {
        const int LabelWidth = 200;
        const int LabelHeight = 12;
        public FileAttributeDialog()
        {
            InitializeComponent();
            //initializeWidget();
        }
        void initializeWidget()
        {
            label_fileName.Dock = DockStyle.Fill;
            label_fileName.AutoSize = false;
            label_fileName.Width = LabelWidth;
            label_fileName.Height = LabelHeight;

            label_fileSize.Dock = DockStyle.Fill;
            label_fileSize.AutoSize = false;
            label_fileSize.Width = LabelWidth;
            label_fileSize.Height = LabelHeight;

            label_fileCreateTime.Dock = DockStyle.Fill;
            label_fileCreateTime.AutoSize = false;
            label_fileCreateTime.Width = LabelWidth;
            label_fileCreateTime.Height = LabelHeight;

            label_fileSyncStatus.Dock = DockStyle.Fill;
            label_fileSyncStatus.AutoSize = false;
            label_fileSyncStatus.Width = LabelWidth;
            label_fileSyncStatus.Height = LabelHeight;
        }
        /// <summary>
        /// 设置标签值
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileCreateTime"></param>
        /// <param name="fileSyncStatus"></param>
        public void setLabelValue(string fileName, string fileSize, string fileCreateTime, string fileSyncStatus)
        {
            label_fileName.Text = "名称: " + fileName;
            label_fileSize.Text = "大小: " + fileSize;
            label_fileCreateTime.Text = "修改时间: " + fileCreateTime;
            label_fileSyncStatus.Text = "同步状态: " + fileSyncStatus;
        }
    }
}
