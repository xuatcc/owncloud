using custom_cloud.userClass;
using System;
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

        public ContactListForm()
        {
            InitializeComponent();
            testContact();
        }
        void initializeConfig()
        {

        }
        void initializeWidget()
        {

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
        protected void getContactListFromServer()
        {

        }
        #endregion function
    }
}
