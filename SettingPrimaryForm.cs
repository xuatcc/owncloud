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
    
    public partial class SettingPrimaryForm : Form
    {
        /// <summary>
        /// 是否自动启动
        /// </summary>
        public bool isAutoStart
        {
            get { return checkBox_autoStart.Checked; }
            set { checkBox_autoStart.Checked = value; }
        }
        public SettingPrimaryForm()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            checkBox_autoStart.Parent = this;
            checkBox_autoStart.BackColor = Color.Transparent;
        }
    }
}
