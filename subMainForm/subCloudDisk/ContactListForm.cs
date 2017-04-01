using custom_cloud.loadingForm;
using custom_cloud.userClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud.subMainForm.subCloudDisk
{
    /// <summary>
    /// 选择好友的窗口
    /// </summary>
    public partial class ContactListForm : Form
    {
        UserInfo userInfo;
        /// <summary>
        /// 被分享文件的相对路径
        /// </summary>
        Queue<string> RelativeFilePath;
        public ContactListForm(UserInfo userInfo)
        {
            InitializeComponent();
            //testContact();
            this.userInfo = userInfo;
            //initializeWidget();
        }
        void initializeConfig()
        {

        }
        /// <summary>
        /// 设置文件分享路径
        /// </summary>
        public void setShareFilePath(Queue<string> relativeFilePath)
        {
            RelativeFilePath = relativeFilePath;
            initializeWidget();
        }
        void initializeWidget()
        {
            Application.DoEvents();
            Thread.Sleep(10);
            getContactListFromServer();
        }
        /// <summary>
        /// 添加联系人到Tree视图
        /// <param name="contactList">联系人列表</param>
        /// </summary>
        protected void addContactItemsToTreeView(ContactList contactList)
        {
            treeView_contact.Nodes.Clear();
            foreach(ContactList.Group clg in contactList.Groups.Values)
            {
                treeView_contact.Nodes.Add(clg.Name, clg.Name);
                foreach(ContactList.Group.GroupMember cggm in clg.Members.Values)
                {
                    treeView_contact.Nodes[clg.Name].Nodes.Add(cggm.Name + "(" + cggm.ID + ")");
                }
            }
        }

        /// <summary>
        /// 测试添加联系人
        /// </summary>
        void testContact()
        {
            ContactList contactList = new ContactList();
            contactList.Groups.Add("animals", new ContactList.Group("animals"));
            contactList.Groups["animals"].Members.Add("elephant", new ContactList.Group.GroupMember("elephant", "大象"));
            contactList.Groups["animals"].Members.Add("tiger", new ContactList.Group.GroupMember("tiger", "老虎"));
            contactList.Groups["animals"].Members.Add("dog", new ContactList.Group.GroupMember("dog", "狗"));
            contactList.Groups.Add("fruits", new ContactList.Group("fruits"));
            contactList.Groups["fruits"].Members.Add("apple", new ContactList.Group.GroupMember("apple", "苹果"));
            contactList.Groups["fruits"].Members.Add("orige", new ContactList.Group.GroupMember("orige", "橙子"));
            contactList.Groups["fruits"].Members.Add("melon", new ContactList.Group.GroupMember("melon", "西瓜"));

            addContactItemsToTreeView(contactList);
        }
        /// <summary>
        /// 选中节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_contact_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.ByMouse) return;
            if (e.Node.Checked)
            {
                foreach(TreeNode node in e.Node.Nodes)
                {
                    node.Checked = true;
                }
                if (e.Node.Parent != null)
                {
                    bool isAllSelected = true;
                    foreach(TreeNode node in e.Node.Parent.Nodes)
                    {
                        if (!node.Checked)
                        {
                            isAllSelected = false;
                            break;
                        }
                    }
                    if (isAllSelected) e.Node.Parent.Checked = true;                }
            }
            else
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = false;
                }
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {

        }

        private void button_confirm_MouseEnter(object sender, EventArgs e)
        {
            button_confirm.Image = Properties.Resources.enter;
        }

        private void button_confirm_MouseLeave(object sender, EventArgs e)
        {
            button_confirm.Image = Properties.Resources.down;
        }

        private void button_confirm_MouseDown(object sender, MouseEventArgs e)
        {
            button_confirm.Image = Properties.Resources.down;
        }

        private void button_confirm_MouseUp(object sender, MouseEventArgs e)
        {
            button_confirm.Image = Properties.Resources.enter;
        }
        #region function
        /// <summary>
        /// 从服务器获取联系人列表
        /// </summary>
        protected void getContactListFromServer()
        {
            Hashtable hashtable = new Hashtable();
            UtilityLoading utilityLoading = new UtilityLoading();
            utilityLoading.StatusText = "正在获取联系人列表";
            if (userInfo != null) utilityLoading.functionGetContactList(userInfo);
            if (utilityLoading.ShowDialog() == DialogResult.OK)
            {
                //hashtable = utilityLoading.CallBackTable;
                string callback = utilityLoading.CallBackMessage;
                ContactList cl = JsonHelper.getDeserializeObject<ContactList>(callback);
                /* 创建联系人树 */
                //setContactTree(hashtable);
            }
            else
            {
                MessageBox.Show("无法获取联系人信息!");
                
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
        /// <summary>
        /// 根据哈希表创建联系人树
        /// </summary>
        /// <param name="hashtable"></param>
        protected void setContactTree(Hashtable hashtable)
        {

        }
        #endregion function
    }
}
