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
    public partial class SettingSyncForm : Form
    {
        /// <summary>
        /// 是否自动同步
        /// </summary>
        public bool isAutoSync
        {
            get { return checkBox_autoSync.Checked; }
            set { checkBox_autoSync.Checked = value; }
        }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string ServerAddress
        {
            get { return textBox_serverAddress.Text; }
            set { textBox_serverAddress.Text = value; }
        }
        public string Port
        {
            get { return textBox_port.Text; }
            set { textBox_port.Text = value; }
        }
        public SettingSyncForm()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_sync.Parent = this;
            label_sync.BackColor = Color.Transparent;

            label_serverAddress.Parent = this;
            label_serverAddress.BackColor = Color.Transparent;

            label_port.BackColor = Color.Transparent;
            label_port.Parent = this;

            checkBox_autoSync.Parent = this;
            checkBox_autoSync.BackColor = Color.Transparent;
        }
    }
}
