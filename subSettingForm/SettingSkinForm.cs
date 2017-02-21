using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.subSettingForm
{
    public partial class SettingSkinForm : Form
    {
        public SettingSkinForm()
        {
            InitializeComponent();
            initializeWidget();
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        void initializeWidget()
        {
            label_title.Parent = this;
            label_title.BackColor = Color.Transparent;

            label_sub_iconSize.Parent = this;
            label_sub_iconSize.BackColor = Color.Transparent;

            label_sub_iconSize_large.Parent = this;
            label_sub_iconSize_large.BackColor = Color.Transparent;

            label_iconSizeLarge_pixel.Parent = this;
            label_iconSizeLarge_pixel.BackColor = Color.Transparent;

            label_iconSizeSmall.Parent = this;
            label_iconSizeSmall.BackColor = Color.Transparent;

            label_iconSizeSmall_pixel.Parent = this;
            label_iconSizeSmall_pixel.BackColor = Color.Transparent;
        }
    }
}
