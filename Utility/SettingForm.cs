/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using custom_cloud.subSettingForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud
{
    /// <summary>
    /// 设置主交互对话框
    /// </summary>
    public partial class SettingForm : Form
    {
        Point offset;
        SettingPrimaryForm settingPrimaryForm = new SettingPrimaryForm();
        SettingSyncForm settingSyncForm = new SettingSyncForm();
        SettingSkinForm settingSkinForm = new SettingSkinForm();
        public bool isFirstUse = false;
        public bool ButtonCancel_Enable
        {
            set { button_cancel.Enabled = value; }
        }
        public SettingForm()
        {
            InitializeComponent();
            initializeWidget();
        }
        public void startSetting()
        {
            initializeConfig();
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        void initializeConfig()
        {
            if (isFirstUse) return;
            MyConfig.ConfigFile configFile = MyConfig.readConfig();
            if (configFile == null) return;
            if(configFile.TablePrimary.ContainsKey(MyConfig.ConfigFile.Primary.KEY_AUTO_START))settingPrimaryForm.isAutoStart =
                    (bool)configFile.TablePrimary[MyConfig.ConfigFile.Primary.KEY_AUTO_START];
            if (configFile.TableSync.ContainsKey(MyConfig.ConfigFile.Sync.KEY_AUTO_SYNC))settingSyncForm.isAutoSync =
                    (bool)configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_AUTO_SYNC];
            if (configFile.TableSync.ContainsKey(MyConfig.ConfigFile.Sync.KEY_SERVER_URI)) settingSyncForm.ServerAddress = 
                    configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_URI].ToString();
            if (configFile.TableSync.ContainsKey(MyConfig.ConfigFile.Sync.KEY_SERVER_PORT)) settingSyncForm.Port = 
                    configFile.TableSync[MyConfig.ConfigFile.Sync.KEY_SERVER_PORT].ToString();

            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_LARGE_ICON_SIZE))settingSkinForm.SizeLargeIcon =
                    int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_LARGE_ICON_SIZE].ToString());
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_SMALL_ICON_SIZE)) settingSkinForm.SizeSmallIcon = 
                    int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_SMALL_ICON_SIZE].ToString());
        }
        void initializeWidget()
        {
            pictureBox_buttonClose.Parent = panel_title;
            pictureBox_buttonMinimize.Parent = panel_title;

            pictureBox_buttonClose.BackColor = Color.Transparent;
            pictureBox_buttonMinimize.BackColor = Color.Transparent;

            //settingPrimaryForm = new SettingPrimaryForm();
            settingPrimaryForm.TopLevel = false;
            settingSyncForm.TopLevel = false;
            settingSkinForm.TopLevel = false;
            panel_form.Controls.Add(settingPrimaryForm);
            panel_form.Controls.Add(settingSyncForm);
            panel_form.Controls.Add(settingSkinForm);
            settingPrimaryForm.Show();

            label_error.Visible = false;
            label_error.BackColor = Color.Transparent;
            label_error.Parent = this;
        }
        void btn_formChoose_Event(object obj, EventArgs ea)
        {
            if (obj.Equals(toolStripMenuItem_primary))
            {
                settingSyncForm.Hide();
                settingSkinForm.Hide();
                settingPrimaryForm.Show();
            }
            if (obj.Equals(toolStripMenuItem_transfer))
            {
                settingPrimaryForm.Hide();
                settingSkinForm.Hide();
                settingSyncForm.Show();
            }
            if (obj.Equals(toolStripMenuItem_skin))
            {
                settingPrimaryForm.Hide();
                settingSyncForm.Hide();
                settingSkinForm.Show();
            }
        }
        void button_MouseEnterEvent(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonClose)) pictureBox_buttonClose.BackColor = Color.Red;
            if (obj.Equals(pictureBox_buttonMinimize)) pictureBox_buttonMinimize.BackColor = MyConfig.SelectedColor;
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        void button_MouseLeaveEvent(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonClose)) pictureBox_buttonClose.BackColor = Color.Transparent;
            if (obj.Equals(pictureBox_buttonMinimize)) pictureBox_buttonMinimize.BackColor = Color.Transparent;
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        void btn_MouseDownEvent(object obj, MouseEventArgs mea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        void btn_MouseUpEvent(object obj, MouseEventArgs mea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        void btn_Click_Event(object obj, EventArgs ea)
        {
            if (obj.Equals(pictureBox_buttonClose)) this.Close();
            if (obj.Equals(pictureBox_buttonMinimize)) this.WindowState = FormWindowState.Minimized;
            if (obj.Equals(button_confirm))
            {
                
                /* 可能不合法的配置 */
                string sync_ip = settingSyncForm.ServerAddress;
                //string a = "";
                if (!CodeAnalysis.IsValidIP(sync_ip))
                {
                    label_error.Visible = true;
                    label_error.Text = "服务器地址不合法";
                    return;
                }
                string sync_port_str = settingSyncForm.Port;
                if (!CodeAnalysis.IsInteger(sync_port_str))
                {
                    label_error.Visible = true;
                    label_error.Text = "端口不合法";
                    return;
                }
                /* 保存配置 */
                MyConfig.ConfigFile configFile;
                if (File.Exists(MyConfig.CONFIG_FILE_PATH)) configFile = MyConfig.readConfig(MyConfig.CONFIG_FILE_PATH);
                else configFile = new MyConfig.ConfigFile();
                if (configFile == null) return;

                /* 保存服务器地址 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SYNC, 
                    MyConfig.ConfigFile.Sync.KEY_SERVER_URI, sync_ip);
                /* 保存端口 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SYNC, 
                    MyConfig.ConfigFile.Sync.KEY_SERVER_PORT, int.Parse(sync_port_str));
                /* 是否自动启动 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_PRIMARY, 
                    MyConfig.ConfigFile.Primary.KEY_AUTO_START, settingPrimaryForm.isAutoStart);
                /* 是否自动同步 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SYNC, 
                    MyConfig.ConfigFile.Sync.KEY_AUTO_SYNC, settingSyncForm.isAutoSync);

                /* 保存外观 */
                /* 大图标大小 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN,
                    MyConfig.ConfigFile.Skin.KEY_LARGE_ICON_SIZE, settingSkinForm.SizeLargeIcon);
                /* 小图标大小 */
                configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN,
                    MyConfig.ConfigFile.Skin.KEY_SMALL_ICON_SIZE, settingSkinForm.SizeSmallIcon);

                MyConfig.saveConfig(MyConfig.CONFIG_FILE_PATH, configFile);

                

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (obj.Equals(button_cancel)) this.Close();
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
        public void setBtnExit()
        {
            pictureBox_buttonClose.Click += new EventHandler(exitApp);
        }
        void exitApp(object obj, EventArgs ea)
        {
            System.Environment.Exit(0);
        }
    }
}
