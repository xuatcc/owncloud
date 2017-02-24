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

namespace custom_cloud.subSettingForm
{
    public partial class SettingSkinForm : Form
    {
        /// <summary>
        /// 大图标尺寸
        /// </summary>
        public int SizeLargeIcon
        {
            get
            {
                return int.Parse(numericUpDown_iconSizeLarge.Value.ToString());
            }
            set
            {
                numericUpDown_iconSizeLarge.Value = value;
            }
        }
        /// <summary>
        /// 小图标尺寸
        /// </summary>
        public int SizeSmallIcon
        {
            get { return int.Parse(numericUpDown_iconSizeSmall.Value.ToString()); }
            set { numericUpDown_iconSizeSmall.Value = value; }
        }

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
