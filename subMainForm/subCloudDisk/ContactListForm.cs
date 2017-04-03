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
            
            this.userInfo = userInfo;
            testContact();
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
            //initializeWidget();
        }
        void initializeWidget()
        {
            //button_confirm.Enabled = false;
            Application.DoEvents();
            Thread.Sleep(10);
            getContactListFromServer();
        }
        

        /// <summary>
        /// 测试添加联系人
        /// </summary>
        void testContact()
        {
            /*
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
            */
            string callback = "[{ \"--\":[{\"uid\":\"1234\",\"username\":\"res\"},{\"uid\":\"test\",\"username\":\"??\"},{\"uid\":\"test99\",\"username\":\"??\"}]},{\"2\":[{\"uid\":\"1234\",\"username\":\"res\"},{\"uid\":\"test22\",\"username\":\"test22\"},{\"uid\":\"test3\",\"username\":\"test3\"}]},{\"fa\":[{\"uid\":\"1234\",\"username\":\"res\"},{\"uid\":\"test11\",\"username\":\"test11\"},{\"uid\":\"test22\",\"username\":\"test22\"},{\"uid\":\"test3\",\"username\":\"test3\"},{\"uid\":\"test44\",\"username\":\"test44\"}]},{\"group\":[{\"uid\":\"1234\",\"username\":\"res\"},{\"uid\":\"bigbigqi\",\"username\":\"??????\"},{\"uid\":\"test3\",\"username\":\"test3\"}]},{\"testg\":[{\"uid\":\"1234\",\"username\":\"res\"},{\"uid\":\"bigbigqi\",\"username\":\"??????\"},{\"uid\":\"test3\",\"username\":\"test3\"}]}]";
            Dictionary<string, ContactList.Group.GroupMember[]>[] contactDic = JsonHelper.getDeserializeObject<Dictionary<string, ContactList.Group.GroupMember[]>[]>(callback);
            setContactTree(contactDic);
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
                    if (isAllSelected) e.Node.Parent.Checked = true;
                }
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
            if (RelativeFilePath == null) return;
            UserInfo uiToSend = userInfo;
            string filePath;
            uiToSend.FileShareList = new UserInfo.ShareList();
            for(int i = 0;i < RelativeFilePath.Count;i++)
            {
                filePath = RelativeFilePath.ElementAt(i);
                foreach (TreeNode node in treeView_contact.Nodes)
                {
                    foreach (TreeNode contact_node in node.Nodes)
                    {
                        if (!contact_node.Checked) continue;
                        if(!(uiToSend.FileShareList.IDList.Contains(contact_node.Name) && uiToSend.FileShareList.FileList.Contains(filePath)))
                        {
                            uiToSend.FileShareList.IDList.AddLast(contact_node.Name);
                            uiToSend.FileShareList.FileList.AddLast(filePath);
                        }
                    }
                }
            }
            if (uiToSend.FileShareList.IDList.Count > 0)
            {
                UtilityLoading utL = new UtilityLoading();
                utL.StatusText = "正在分享";
                utL.ButtonText = "取消";
                utL.functionShareFiles(uiToSend);
                if (utL.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("分享成功");
                }
                else
                {
                    MessageBox.Show("分享失败!");
                }
            }
            else
            {
                MessageBox.Show("请选择联系人!");
            }
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
                //ContactList cl = JsonHelper.getDeserializeObject<ContactList>(callback);
                /* 创建联系人树 */
                Dictionary<string, ContactList.Group.GroupMember[]>[] contactDic = JsonHelper.getDeserializeObject<Dictionary<string, ContactList.Group.GroupMember[]>[]>(callback);
                setContactTree(contactDic);
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
        protected void setContactTree(Dictionary<string, ContactList.Group.GroupMember[]>[] contactDic)
        {
            if (userInfo == null) return;
            treeView_contact.Nodes.Clear();
            foreach(Dictionary<string, ContactList.Group.GroupMember[]> cdic in contactDic)
            {
                if (cdic.Keys.Count > 0) treeView_contact.Nodes.Add(cdic.Keys.ElementAt(0), cdic.Keys.ElementAt(0));
                if (cdic.Values.Count > 0)
                {
                    foreach (ContactList.Group.GroupMember member in cdic.Values.ElementAt(0))
                    {
                        if(member.uid != userInfo.UserID)treeView_contact.Nodes[cdic.Keys.ElementAt(0)].Nodes.Add(member.uid, member.username + "(" + member.uid + ")");
                    }
                }
            }
        }
        #endregion function
    }
}
