using custom_cloud.loadingForm;
using custom_cloud.subMainForm;
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

namespace custom_cloud
{
    public partial class MainWindow : Form
    {
        Color SelectedColor = Color.FromArgb(Convert.ToInt32("e93da5fc", 16));
        /* 子窗体 */
        CloudDiskForm cloudDiskForm = new CloudDiskForm();
        ShareForm shareForm = new ShareForm();
        SyncForm syncForm = new SyncForm();
        SettingForm settingForm = new SettingForm();
        Point offset;
        /// <summary>
        /// 父窗体
        /// </summary>
        public Form_Login form_ParentLogin;
       /// <summary>
       /// 判断当前选中哪个子窗体
       /// </summary>
        object ButtonSelected = new object();
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo userInfo = new UserInfo();
        /// <summary>
        /// 用户本地信息
        /// </summary>
        UserLocalInfo userLocalInfo = new UserLocalInfo();
        int InitialFormWidth = 1024;
        int InitialFormHeight = 632;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        public void setUserInfo(UserInfo userInfo, UserLocalInfo userLocalInfo)
        {
            this.userInfo = userInfo;
            this.userLocalInfo = userLocalInfo;
            initializeWidget();
        }
        void initializeWidget()
        {
            

            cloudDiskForm.TopLevel = false;
            shareForm.TopLevel = false;
            syncForm.TopLevel = false;
            //settingForm.TopLevel = false;
            selectFormToShow();
            
            pictureBox_buttonRecover.Visible = false;
            /* 设置右上角按钮背景色 */
            pictureBox_buttonClose.Parent = panel_title;
            pictureBox_buttonMaximize.Parent = panel_title;
            pictureBox_buttonMinimize.Parent = panel_title;
            pictureBox_buttonRecover.Parent = panel_title;
            pictureBox_buttonListSetting.Parent = panel_title;

            pictureBox_buttonClose.BackColor = Color.Transparent;
            pictureBox_buttonMaximize.BackColor = Color.Transparent;
            pictureBox_buttonMinimize.BackColor = Color.Transparent;
            pictureBox_buttonRecover.BackColor = Color.Transparent;
            pictureBox_buttonListSetting.BackColor = Color.Transparent;
            /* 左上角背景色 */
            label_userName.Parent = panel_title;
            label_userName.BackColor = Color.Transparent;
            label_userName.Text = userInfo.UserName;
            /* 上方功能按钮背景色 */
            pictureBox_buttonSelectDisk.Parent = panel_title;
            ButtonSelected = pictureBox_buttonSelectDisk;
            pictureBox_buttonSelectDisk.BackColor = SelectedColor;
            pictureBox_buttonSelectDisk.MouseLeave += new EventHandler(btn_function_MouseLeave);
            pictureBox_buttonShare.Parent = panel_title;
            pictureBox_buttonNet.Parent = panel_title;
            pictureBox_buttonNet.BackColor = Color.Transparent;
            //pictureBox_buttonSelectDisk.BackColor = Color.Transparent;
            pictureBox_buttonShare.BackColor = Color.Transparent;

            label_disk.Parent = panel_title;
            label_disk.BackColor = SelectedColor;
            //label_disk.BackColor = Color.Transparent;
            label_share.Parent = panel_title;
            label_share.BackColor = Color.Transparent;
            label_sync.Parent = panel_title;
            label_sync.BackColor = Color.Transparent;

            /* Context Menu Setting */
            //pictureBox_buttonListSetting.ContextMenuStrip = contextMenuStrip_listSetting;
        }
        void doNothing(object obj, EventArgs ea) { }
        /// <summary>
        /// 切换窗体的方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_function_Click(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonSelectDisk))
            {
                shareForm.Hide();
                syncForm.Hide();
                cloudDiskForm.Show();

                ButtonSelected = pictureBox_buttonSelectDisk;
                
                //pictureBox_buttonSelectDisk.BackColor = SelectedColor;
                pictureBox_buttonShare.BackColor = Color.Transparent;
                label_share.BackColor = Color.Transparent;
                pictureBox_buttonNet.BackColor = Color.Transparent;
                label_sync.BackColor = Color.Transparent;
            }
            if (obj.Equals(pictureBox_buttonShare))
            {
                syncForm.Hide();
                cloudDiskForm.Hide();
                shareForm.Show();

                ButtonSelected = pictureBox_buttonShare;

                pictureBox_buttonSelectDisk.BackColor = Color.Transparent;
                label_disk.BackColor = Color.Transparent;
                //pictureBox_buttonShare.BackColor = SelectedColor;
                pictureBox_buttonNet.BackColor = Color.Transparent;
                label_sync.BackColor = Color.Transparent;
            }
            if (obj.Equals(pictureBox_buttonNet))
            {
                cloudDiskForm.Hide();
                shareForm.Hide();
                syncForm.Show();

                ButtonSelected = pictureBox_buttonNet;

                pictureBox_buttonSelectDisk.BackColor = Color.Transparent;
                label_disk.BackColor = Color.Transparent;
                pictureBox_buttonShare.BackColor = Color.Transparent;
                label_share.BackColor = Color.Transparent;
                //pictureBox_buttonNet.BackColor = SelectedColor;
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_formClose_Click(object obj, EventArgs ea)
        {
            //Application.Exit();
            minimizeWindow();
        }
        void btn_formMinimize_Click(object obj, EventArgs ea)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        void btn_formMaximize_Click(object obj, EventArgs ea)
        {
            
            //Thread.Sleep(200);
            pictureBox_buttonRecover.Visible = true;
            pictureBox_buttonMaximize.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }
        void btn_formRecover_Click(object obj, EventArgs ea)
        {
            
            //Thread.Sleep(200);
            pictureBox_buttonRecover.Visible = false;
            pictureBox_buttonMaximize.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// 设置按钮按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_buttonSetting_Click(object sender, EventArgs e)
        {
            settingForm = new SettingForm();
            //settingForm.TopLevel = false;
            //settingForm.Parent = this;
            settingForm.startSetting();
            DialogResult dialogResult = settingForm.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                /* 临时保存工作目录，防止回退 */
                string tempPath = cloudDiskForm.Current_Path;
                Stack<string> backStack = cloudDiskForm.BackStack;
                Stack<string> forwardStack = cloudDiskForm.ForwardStack;
                cloudDiskForm.updateFileTree();
                FileTree fileTree = cloudDiskForm.File_Tree;


                cloudDiskForm = new CloudDiskForm();
                cloudDiskForm.TopLevel = false;
                panel_mainForm.Controls.RemoveByKey(cloudDiskForm.Name);

                cloudDiskForm.BackStack = backStack;
                cloudDiskForm.ForwardStack = forwardStack;
                cloudDiskForm.Current_Path = tempPath;
                cloudDiskForm.setUserInfo(userInfo);


                panel_mainForm.Controls.Add(cloudDiskForm);
                cloudDiskForm.Show();
                /* 还原目录树的展开状态 */
                cloudDiskForm.File_Tree = fileTree;
                cloudDiskForm.updateDirectoryTree();
            }
            //settingForm.Show();
            //this.Enabled = false;
        }
        /// <summary>
        /// 设置按钮按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_buttonListSetting_Click(object sender, EventArgs e)
        {
            /* 变换菜单位置 */
            
            //contextMenuStrip_listSetting.SetBounds(pictureBox_buttonListSetting.Location.X, pictureBox_buttonListSetting.Location.Y, contextMenuStrip_listSetting.Width, contextMenuStrip_listSetting.Height);
            contextMenuStrip_listSetting.Show(pictureBox_buttonListSetting, 0, pictureBox_buttonListSetting.Height);
        }
        /// <summary>
        /// 鼠标移到关闭按钮上改变颜色
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="mea"></param>
        void btn_formClose_MouseEnter(object obj, EventArgs ea)
        {
            pictureBox_buttonClose.BackColor = Color.Red;
        }
        void btn_formClose_MouseLeave(object obj, EventArgs ea)
        {
            pictureBox_buttonClose.BackColor = Color.Transparent;
        }
        void btn_formMinimize_MouseEnter(object obj, EventArgs ea)
        {
            pictureBox_buttonMinimize.BackColor = SelectedColor;
        }
        void btn_formMinimize_MouseLeave(object obj, EventArgs ea)
        {
            pictureBox_buttonMinimize.BackColor = Color.Transparent;
        }
        void btn_formMaximize_MouseEnter(object obj, EventArgs ea)
        {
            pictureBox_buttonMaximize.BackColor = SelectedColor;
        }
        void btn_formMaximize_MouseLeave(object obj, EventArgs ea)
        {
            pictureBox_buttonMaximize.BackColor = Color.Transparent;
        }
        void btn_formRecover_MouseEnter(object obj, EventArgs ea)
        {
            pictureBox_buttonRecover.BackColor = SelectedColor;
        }
        void btn_formRecover_MouseLeave(object obj, EventArgs ea)
        {
            pictureBox_buttonRecover.BackColor = Color.Transparent;
        }
        void btn_formuserIcon_MouseEnter(object obj, EventArgs ea)
        {
            pictureBox_userIcon.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pictureBox_buttonSetting_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_buttonListSetting.BackColor = SelectedColor;
        }

        private void pictureBox_buttonSetting_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_buttonListSetting.BackColor = Color.Transparent;
        }
        void btn_formuserIcon_MouseLeave(object obj, EventArgs ea)
        {
            pictureBox_userIcon.BorderStyle = BorderStyle.None;
        }
        void btn_function_MouseEnter(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonSelectDisk))
            {
                pictureBox_buttonSelectDisk.BackColor = SelectedColor;
                label_disk.BackColor = SelectedColor;
            }
            if (obj.Equals(pictureBox_buttonShare))
            {
                pictureBox_buttonShare.BackColor = SelectedColor;
                label_share.BackColor = SelectedColor;
            }
            if (obj.Equals(pictureBox_buttonNet))
            {
                pictureBox_buttonNet.BackColor = SelectedColor;
                label_sync.BackColor = SelectedColor;
            }
            //pictureBox_userIcon.BorderStyle = BorderStyle.FixedSingle;
        }
        void btn_function_MouseLeave(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonSelectDisk) && !ButtonSelected.Equals(pictureBox_buttonSelectDisk))
            {
                pictureBox_buttonSelectDisk.BackColor = Color.Transparent;
                label_disk.BackColor = Color.Transparent;
            }
            if (obj.Equals(pictureBox_buttonShare) && !ButtonSelected.Equals(pictureBox_buttonShare))
            {
                pictureBox_buttonShare.BackColor = Color.Transparent;
                label_share.BackColor = Color.Transparent;
            }
            if (obj.Equals(pictureBox_buttonNet) && !ButtonSelected.Equals(pictureBox_buttonNet))
            {
                pictureBox_buttonNet.BackColor = Color.Transparent;
                label_sync.BackColor = Color.Transparent;
            }
        }
        
        /// <summary>
        /// 窗体拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        void selectFormToShow()
        {
            
            
            panel_mainForm.Controls.Add(cloudDiskForm);
            panel_mainForm.Controls.Add(shareForm);
            panel_mainForm.Controls.Add(syncForm);
            cloudDiskForm.setUserInfo(userInfo);
            cloudDiskForm.Show();
            syncForm.setInfo(userLocalInfo);
        }
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(pictureBox_userIcon)) setUserInfo();
            if (sender.Equals(toolStripMenuItem_showMainWindow)) recoverWindow();
            if (sender.Equals(toolStripMenuItem_logOut)) closeWindow();
            if (sender.Equals(toolStripMenuItem_list_logout)) closeWindow();
            if (sender.Equals(toolStripMenuItem_exit)) exitApplication();
            if (sender.Equals(toolStripMenuItem_list_exit)) exitApplication();
        }
        /// <summary>
        /// 设置用户信息
        /// </summary>
        void setUserInfo()
        {
            SettingUserInfo settingUserInfo = new SettingUserInfo();
            // 临时测试
            settingUserInfo.setUserInfo(userInfo, userLocalInfo);
            DialogResult dialogResult = settingUserInfo.ShowDialog();
        }
        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            int old_panel_width = panel_title.Width;
            panel_title.Width = this.Width;

            pictureBox_buttonClose.SetBounds(panel_title.Width - pictureBox_buttonClose.Width,
                pictureBox_buttonClose.Location.Y, pictureBox_buttonClose.Width, pictureBox_buttonClose.Height);
            pictureBox_buttonMaximize.SetBounds(panel_title.Width - (old_panel_width - pictureBox_buttonMaximize.Location.X),
                pictureBox_buttonMaximize.Location.Y, pictureBox_buttonMaximize.Width, pictureBox_buttonMaximize.Height);
            pictureBox_buttonMinimize.SetBounds(panel_title.Width - (old_panel_width - pictureBox_buttonMinimize.Location.X),
                pictureBox_buttonMinimize.Location.Y, pictureBox_buttonMinimize.Width, pictureBox_buttonMinimize.Height);
            pictureBox_buttonRecover.SetBounds(panel_title.Width - (old_panel_width - pictureBox_buttonRecover.Location.X),
                pictureBox_buttonRecover.Location.Y, pictureBox_buttonRecover.Width, pictureBox_buttonRecover.Height);
            pictureBox_buttonListSetting.SetBounds(panel_title.Width - (old_panel_width - pictureBox_buttonListSetting.Location.X),
                pictureBox_buttonListSetting.Location.Y, pictureBox_buttonListSetting.Width, pictureBox_buttonListSetting.Height);

            panel_mainForm.Width = this.Width;
            panel_mainForm.Height = this.Height - panel_title.Height;

            cloudDiskForm.Width = panel_mainForm.Width;
            cloudDiskForm.Height = panel_mainForm.Height;
            shareForm.Width = panel_mainForm.Width;
            shareForm.Height = panel_mainForm.Height;
            syncForm.Width = panel_mainForm.Width;
            syncForm.Height = panel_mainForm.Height;
        }
        /// <summary>
        /// 最小化窗体
        /// </summary>
        void minimizeWindow()
        {
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 最大化窗体
        /// </summary>
        void recoverWindow()
        {
            if (this.WindowState.Equals(FormWindowState.Minimized) || !this.Visible)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 注销窗体
        /// </summary>
        void closeWindow()
        {
            /* 向服务器提交注销请求 */
            UtilityLoading utilityLoading = new UtilityLoading();
            utilityLoading.ButtonText = "取消";
            utilityLoading.StatusText = "正在向服务器发送注销请求";
            utilityLoading.functionLogout(userInfo);
            if (utilityLoading.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("注销失败!");
                return;
            }
            if (form_ParentLogin != null) form_ParentLogin.Show();
            this.Close();
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        void exitApplication()
        {
            /* 删除文件缓存目录 */
            if (Directory.Exists(MyConfig.PATH_FILE_BUFFER)) FileTree.deleteDirectory(MyConfig.PATH_FILE_BUFFER, null);
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 双击图标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            recoverWindow();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* 删除文件缓存目录 */
            if (Directory.Exists(MyConfig.PATH_FILE_BUFFER)) FileTree.deleteDirectory(MyConfig.PATH_FILE_BUFFER, null);
        }
    }
}
