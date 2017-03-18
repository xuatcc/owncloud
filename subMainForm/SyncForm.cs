using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class SyncForm : Form
    {
        /// <summary>
        /// 列表头1，显示同步中的文件名
        /// </summary>
        protected ColumnHeader ListFileNameHeader = new ColumnHeader();
        /// <summary>
        /// 列表头2，显示文件同步状态
        /// </summary>
        protected ColumnHeader ListFileStatusHeader = new ColumnHeader();

        public SyncForm()
        {
            InitializeComponent();
            initializeConfig();
            initializeWidget();
        }

        private void SyncForm_SizeChanged(object sender, EventArgs e)
        {
            panel_functionList.Width = this.Width;
            listView_syncStatus.Width = this.Width;
            listView_syncStatus.Height = this.Height - panel_functionList.Height;
        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        protected void initializeConfig()
        {

        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        protected void initializeWidget()
        {
            ListFileNameHeader.Text = "文件路径";
            ListFileNameHeader.Width = listView_syncStatus.Width / 3;
            ListFileNameHeader.TextAlign = HorizontalAlignment.Left;
            ListFileStatusHeader.Text = "同步状态";
            ListFileStatusHeader.Width = listView_syncStatus.Width / 3;
            ListFileStatusHeader.TextAlign = HorizontalAlignment.Left;

            listView_syncStatus.Columns.Add(ListFileNameHeader);
            listView_syncStatus.Columns.Add(ListFileStatusHeader);
        }
    }
}
