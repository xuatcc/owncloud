using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace custom_cloud.userClass
{
    /// <summary>
    /// 联系人信息
    /// </summary>
    public class ContactList
    {
        /// <summary>
        /// 组
        /// </summary>
        public Dictionary<string, Group> Groups = new Dictionary<string, Group>();
        /// <summary>
        /// 组
        /// </summary>
        public class Group
        {
            /// <summary>
            /// 组名
            /// </summary>
            public string Name;
            /// <summary>
            /// 组内成员
            /// </summary>
            public Dictionary<string, GroupMember> Members = new Dictionary<string, GroupMember>();
            public Group() { }
            public Group(string name) { Name = name; }
            /// <summary>
            /// 组内成员类
            /// </summary>
            public class GroupMember
            {
                /// <summary>
                /// 成员ID
                /// </summary>
                public string uid;

                /// <summary>
                /// 成员名
                /// </summary>
                public string username;
                public GroupMember() { }
                public GroupMember(string id) { uid = id; }
                public GroupMember(string id, string name) { uid = id; username = name; }
            }
        }
    }
}
