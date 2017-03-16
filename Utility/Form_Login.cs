/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class Form_Login : Form
    {
        MainWindow mw;
        UserInfo User_Info = new UserInfo();
        Point offset;
        bool isRememberPassword;
        bool isAutoLogin;
        string serverURI;
        string userID;
        string Password;
        int serverPort;
        public Form_Login()
        {
            InitializeComponent();
            initializeConfig();
            initializeWidget();
        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        void initializeConfig()
        {
            if (checkFirstUse())
            {
                MyConfig.ConfigFile configFile = MyConfig.readConfig(MyConfig.CONFIG_FILE_PATH);
                serverURI = (string)configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_URI];
                serverPort = int.Parse(configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_PORT].ToString());
                saveLoginConfig();
            }
            else
            {
                MyConfig.ConfigFile configFile = MyConfig.readConfig(MyConfig.CONFIG_FILE_PATH);
                isRememberPassword = (bool)configFile.TableLogin[MyConfig.ConfigFile.Login.KEY_REMEMBER_PASSWORD];
                isAutoLogin = (bool)configFile.TableLogin[MyConfig.ConfigFile.Login.KEY_AUTO_LOGIN];
                serverURI = configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_URI].ToString();
                serverPort = int.Parse(configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_PORT].ToString());

                //textBox_password.Text = configFile.TableLogin[MyConfig.ConfigFile.Login.KEY_LAST_LOGIN_PASSWORD].ToString();
                comboBox_user.Text = configFile.TableLogin[MyConfig.ConfigFile.Login.KEY_LAST_LOGIN_ACCOUNT].ToString();
                UserLocalInfo userLocalInfo = MyConfig.getUserLocalInfo(configFile.TableLogin[MyConfig.ConfigFile.Login.KEY_LAST_LOGIN_ACCOUNT].ToString());
                if (userLocalInfo != null)
                {
                    if (userLocalInfo.IsRemeberPassword) textBox_password.Text = userLocalInfo.Password;
                }
            }
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseDownEvent(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_login)) button_login.Image = Properties.Resources.down;
            if (obj.Equals(button_register)) button_register.Image = Properties.Resources.down;
        }
        void btn_MouseUpEvent(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_login)) button_login.Image = Properties.Resources.enter;
            if (obj.Equals(button_register)) button_register.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        void initializeWidget()
        {
            addItemToCombox();

            button_login.Click += new EventHandler(btn_login_Click);
            /* 标题框 */
            label_errorInfo.Visible = false;

            pictureBox_buttonClose.BackColor = Color.Transparent;
            pictureBox_buttonClose.Parent = panel_title;
            pictureBox_buttonClose.Click += new EventHandler(btn_formClose_Click);
            
            pictureBox_buttonMinimize.BackColor = Color.Transparent;
            pictureBox_buttonMinimize.Parent = panel_title;

            pictureBox_buttonSetting.Parent = panel_title;
            pictureBox_buttonSetting.BackColor = Color.Transparent;
            /* 账户框 */
            panel_loginPanel.Parent = this;
            panel_loginPanel.BackColor = Color.Transparent;

            pictureBox_user.BackColor = Color.Transparent;
            pictureBox_user.Parent = panel_user;

            comboBox_user.BackColor = panel_user.BackColor;
            comboBox_user.Parent = panel_user;
            comboBox_user.AutoSize = false;
            comboBox_user.Height = 36;

            textBox_password.AutoSize = false;
            textBox_password.Height = 36;
            textBox_password.PasswordChar = '*';

            button_login.BackColor = Color.Transparent;
            button_login.Parent = panel_loginPanel;

            checkBox_autoLogin.Checked = isAutoLogin;
            checkBox_rememberPW.Checked = isRememberPassword;
        }
        /// <summary>
        /// 想combo中添加选项
        /// </summary>
        void addItemToCombox()
        {
            comboBox_user.Items.AddRange(MyConfig.getLocalUserID());
        }
        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_login_Click(object obj, EventArgs ea)
        {
            /*
            string user = comboBox_user.Text;
            // matching password
            string password_input = textBox_password.Text;
            Order order = new Order();
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = user;
            userID = user;
            userInfo.Password = password_input;
            Password = password_input;
            userInfo.Order = order.OrderCodes["login"];
            
            LoadingForm loadingForm = new LoadingForm();
            
            loadingForm.setInfo(userID, Password, serverURI, serverPort);
            DialogResult dialogResult = loadingForm.ShowDialog();
            

            if (dialogResult.Equals(DialogResult.OK))
            {
                loadingForm.Visible = false;
                MyConfig.writeUserTrack(comboBox_user.Text);
                User_Info = loadingForm.User_Info;
                UserLocalInfo User_LocalInfo = MyConfig.getUserLocalInfo(User_Info.UserID);
                navigateToMainWindow(User_Info);
                this.Hide();
            }
            else if (dialogResult.Equals(DialogResult.No))
            {
                User_Info = loadingForm.User_Info;
                ErrorCode errorCode = new ErrorCode();
                //label_errorInfo.Text = "登录失败，原因: " + errorCode.TableErrorCode[userManiWindow.error_code];
                label_errorInfo.Text = "登录失败，错误码：" + User_Info.error_code.ToString();
                label_errorInfo.Visible = true;
            }
            /*
            /* 测试主窗体 */
            
            User_Info.UserID = comboBox_user.Text;
            User_Info.UserName = "Doge";
            User_Info.Password = textBox_password.Text;
            User_Info.SyncServerAddress = "http://192.168.204.130/helo";
            UserLocalInfo User_LocalInfo = MyConfig.getUserLocalInfo(User_Info.UserID);
            if (User_LocalInfo == null) User_LocalInfo = new UserLocalInfo();
            User_LocalInfo.UserId = User_Info.UserID;

            MyConfig.writeUserTrack(comboBox_user.Text);
            navigateToMainWindow(User_Info);
            
            
        }
        /// <summary>
        /// 导航去主窗体
        /// </summary>
        void navigateToMainWindow(UserInfo user_info)
        {
            //UserInfo userManiWindow = new UserInfo();

            saveLoginConfig();
            saveUserLocalInfo();
            mw = new MainWindow();
            UserLocalInfo userLocalInfo = MyConfig.getUserLocalInfo(user_info.UserID);
            mw.setUserInfo(user_info, userLocalInfo);
            mw.form_ParentLogin = this;
            this.Hide();
            mw.Show();
            
            //this.Show();
        }
        /// <summary>
        /// 保存登录配置
        /// </summary>
        void saveLoginConfig()
        {
            /* 保存配置 */
            MyConfig.ConfigFile configFile = MyConfig.readConfig(MyConfig.CONFIG_FILE_PATH);
            /* 基本配置 */
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_LOGIN,
                MyConfig.ConfigFile.Login.KEY_REMEMBER_PASSWORD, checkBox_rememberPW.Checked);
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_LOGIN,
                MyConfig.ConfigFile.Login.KEY_AUTO_LOGIN, checkBox_autoLogin.Checked);
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_LOGIN,
                MyConfig.ConfigFile.Login.KEY_LAST_LOGIN_ACCOUNT, comboBox_user.Text);

            MyConfig.saveConfig(MyConfig.CONFIG_FILE_PATH, configFile);
            
        }
        /// <summary>
        /// 保存用户本地信息
        /// </summary>
        void saveUserLocalInfo()
        {
            /* 用户本地信息 */
            UserLocalInfo userLocalInfo = MyConfig.getUserLocalInfo(comboBox_user.Text);
            if (userLocalInfo == null)
            {
                userLocalInfo = new UserLocalInfo();
                userLocalInfo.UserId = User_Info.UserID;
                userLocalInfo.SyncPath = Path.GetFullPath(MyConfig.PATH_USER + "/" + userLocalInfo.UserId + "/sync/");
                //MyConfig.createOrModifyUserDirectory(userLocalInfo.UserId, User_Info);
                //MyConfig.createOrModifyUserLocalInfo(userLocalInfo);
            }
            userLocalInfo.IsRemeberPassword = checkBox_rememberPW.Checked;
            if (checkBox_rememberPW.Checked) userLocalInfo.Password = textBox_password.Text;
            else userLocalInfo.Password = "";

            MyConfig.createOrModifyUserLocalInfo(userLocalInfo);
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_register_Click(object obj, EventArgs ea)
        {
            Process.Start("http://192.168.204.129/owncloud");
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_formClose_Click(object obj, EventArgs ea)
        {
            System.Environment.Exit(0);
        }
        void btn_formMinimize_Click(object obj, EventArgs ea)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        void btn_settingForm_Click(object obj, EventArgs ea)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.startSetting();
            DialogResult dialogResult = settingForm.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                initializeConfig();
                initializeWidget();
            }
            //object getinfo = dialogResult;
            //settingForm.Show();
        }
        /// <summary>
        /// 鼠标移到关闭按钮上改变颜色
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="mea"></param>
        /// 
        void btn_Any_MouseEnter(object obj, EventArgs ea)
        {
            if(obj.Equals(pictureBox_buttonClose)) pictureBox_buttonClose.BackColor = Color.Red;
            if(obj.Equals(pictureBox_buttonMinimize)) pictureBox_buttonMinimize.BackColor = MyConfig.SelectedColor;
            if (obj.Equals(pictureBox_buttonSetting)) pictureBox_buttonSetting.BackColor = MyConfig.SelectedColor;
            if(obj.Equals(button_login)) button_login.Image = Properties.Resources.enter;
            if(obj.Equals(button_register)) button_register.Image = Properties.Resources.enter;
        }
        void btn_Any_MouseLeave(object obj, EventArgs ea)
        {
            if(obj.Equals(pictureBox_buttonClose)) pictureBox_buttonClose.BackColor = Color.Transparent;
            if(obj.Equals(pictureBox_buttonMinimize)) pictureBox_buttonMinimize.BackColor = Color.Transparent;
            if (obj.Equals(pictureBox_buttonSetting)) pictureBox_buttonSetting.BackColor = Color.Transparent;
            if(obj.Equals(button_login)) button_login.Image = Properties.Resources.down;
            if(obj.Equals(button_register)) button_register.Image = Properties.Resources.down;
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
        /// <summary>
        /// 初始化配置
        /// </summary>
        void setFirstConfig()
        {
            

            /* 自定义测试 */
            SettingForm sf = new SettingForm();
            sf.ButtonCancel_Enable = false;
            sf.setBtnExit();
            sf.isFirstUse = true;
            sf.startSetting();
            DialogResult dialogResult = sf.ShowDialog();
            if (dialogResult == DialogResult.OK) { }
            /* 初始化文件显示界面 */
            MyConfig.ConfigFile configFile = MyConfig.readConfig();
            if (configFile == null) return;

            /* 初始化文件显示方式 */
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN, MyConfig.ConfigFile.Skin.KEY_FILE_VIEW, View.LargeIcon);
            /* 初始化文件排列方式 */
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN, MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE, MyConfig.SortRule.ByName);

            MyConfig.saveConfig(configFile);
        }
        /// <summary>
        /// 检查是否是第一次使用
        /// </summary>
        bool checkFirstUse()
        {
            if (File.Exists(MyConfig.CONFIG_FILE_PATH)) return false;
            else
            {
                File.Create(MyConfig.FIRST_USE_FILE);
                /*初始化配置*/
                setFirstConfig();
                return true;
            }
        }
        /// <summary>
        /// 检查按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) btn_login_Click(this, null);
        }
        /// <summary>
        /// 改变账户时密码框清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_user_Click(object sender, EventArgs e)
        {
            UserLocalInfo userLocalInfo = MyConfig.getUserLocalInfo(comboBox_user.Text);
            if (userLocalInfo != null)
            {
                if (userLocalInfo.IsRemeberPassword) textBox_password.Text = userLocalInfo.Password;
                else textBox_password.Text = "";
            }
            else textBox_password.Text = "";
        }
        void comboBox_user_Textchange(object obj, EventArgs ea)
        {
            textBox_password.Text = "";
        }
    }
}
