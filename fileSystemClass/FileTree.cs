/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 文件树，便于管理文件
    /// </summary>
    public class FileTree
    {
        public DirectoryInfo RootDirectory;
        public Dictionary<string, TreeFileInfo> CurrentDirectoryFileList = new Dictionary<string, TreeFileInfo>();
        public Dictionary<string, FileTree> SubTree = new Dictionary<string, FileTree>();
        public FileTree Parent;
        public string Key;
        /// <summary>
        /// 记录展开状态
        /// </summary>
        public bool isExpand = false;
        /// <summary>
        /// 目录修改时间
        /// </summary>
        public double ModifyTime
        {
            get
            {
                return RootDirectory.LastWriteTime.Subtract(MyConfig.RefTime).TotalSeconds;
            }
        }
        /// <summary>
        /// 文件夹是否为空
        /// </summary>
        public bool isEmpty
        {
            get
            {
                DirectoryInfo[] di = RootDirectory.GetDirectories();
                FileInfo[] fi = RootDirectory.GetFiles();
                if (di.Length == 0 && fi.Length == 0) return true;
                else return false;
            }
        }
        public long FileByte
        {
            get
            {
                FileInfo[] fInfo = RootDirectory.GetFiles();
                long fileByte = 0;
                foreach (FileInfo fi in fInfo)
                {
                    fileByte += fi.Length;
                }
                return fileByte;
            }
        }
        public FileTree(string root_directory)
        {
            initializeTree(root_directory);
        }
        void initializeTree(string root_directory)
        {
            //ModifyTime = DateTime.Now.Subtract(MyConfig.RefTime).TotalSeconds;
            RootDirectory = new DirectoryInfo(root_directory);
            CurrentDirectoryFileList = new Dictionary<string, TreeFileInfo>();
            SubTree = new Dictionary<string, FileTree>();
            DirectoryInfo[] dInfo = RootDirectory.GetDirectories();
            FileInfo[] fInfo = RootDirectory.GetFiles();
            /* 广度优先遍历 */
            foreach (FileInfo fi in fInfo)
            {
                CurrentDirectoryFileList.Add(fi.Name, new TreeFileInfo(fi.FullName));
            }
            foreach (DirectoryInfo di in dInfo)
            {
                SubTree.Add(di.Name, new FileTree(RootDirectory + @"\" + di.Name));
                SubTree[di.Name].Parent = this;
            }
        }
        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <returns></returns>
        public long getByteLength()
        {
            long byteCount = FileByte;
            foreach(FileTree fileTree in SubTree.Values)
            {
                byteCount += fileTree.getByteLength();
            }
            return byteCount;
        }
        /// <summary>
        /// 获取路径块
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stack<string> getPathBlock(string path)
        {
            Stack<string> pathBlock = new Stack<string>();
            string fullPath = Path.GetFullPath(path);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (directoryInfo == null) return null;
            while (!this.RootDirectory.FullName.Contains(directoryInfo.FullName))
            {
                pathBlock.Push(directoryInfo.Name);
                directoryInfo = directoryInfo.Parent;
            }
            //pathBlock.Push(directoryInfo.FullName);
            return pathBlock;
        }
        /// <summary>
        /// 获得指定的子树
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public FileTree getTargetTree(string directoryPath)
        {
            Stack<string> pathBlock = getPathBlock(directoryPath);
            if (pathBlock == null) return null;
            FileTree fileTree = this;
            while (pathBlock.Count > 0) fileTree = fileTree.SubTree[pathBlock.Pop()];
            return fileTree;
        }
        /// <summary>
        /// 更新文件树
        /// </summary>
        /// <param name="directory_paths"></param>
        /// 
        
        public void updateTree(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath)) return;
            if (directoryPath.Equals(RootDirectory.FullName))
            {
                initializeTree(directoryPath);
            }
            FileTree fileTree = getTargetTree(directoryPath);
            if (fileTree == null) return;
            else fileTree.initializeTree(directoryPath);
        }
        /// <summary>
        /// 文件夹类名
        /// </summary>
        public static string FOLDER_IDENTIFY_NAME = "FOLDER~!@#$%^&*++";
        /// <summary>
        /// 文件类名
        /// </summary>
        public static string FILE_IDENTIFY_NAME = "FILE*&^%$#@!~++";
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static string copyFile(string source, string destination)
        {
            if (!File.Exists(source)) return null;
            string newFileName = destination;
            int counter = 0;
            
            //防止重名
            while (File.Exists(newFileName))
            {
                ++counter;
                newFileName = Path.GetDirectoryName(destination) + "/" + Path.GetFileNameWithoutExtension(destination)+ "_" +
                    counter.ToString() + Path.GetExtension(destination);
                //string a = "";
            }
            File.Copy(source, newFileName);
            return newFileName;
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        public static string moveFile(string source, string destination)
        {
            if (!File.Exists(source)) return null;
            string newFileName = destination;
            int counter = 0;
            if (source.Equals(destination)) return newFileName;
            //防止重名
            while (File.Exists(newFileName))
            {
                ++counter;
                newFileName = Path.GetDirectoryName(destination) + "/" + Path.GetFileNameWithoutExtension(destination) + "_" +
                    counter.ToString() + Path.GetExtension(destination);
                //string a = "";
            }
            File.Move(source, newFileName);
            return newFileName;
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="sycnPath"></param>
        public static string copyDirectory(string source, string destination)
        {
            if (!Directory.Exists(source)) return null;
            /* 遍历source目录下文件夹 */
            DirectoryInfo directoryInfo = new DirectoryInfo(source);
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            string newFolderName = destination;
            /* 防止重名 */
            int counter = 0;
            while (Directory.Exists(newFolderName))
            {
                ++counter;
                newFolderName = Path.GetDirectoryName(destination) + "/" + Path.GetFileNameWithoutExtension(destination) + "_" +
                    counter.ToString();
                //string a = "";
            }
            Directory.CreateDirectory(newFolderName);
            /* 递归 */
            foreach(DirectoryInfo di in directoryInfos)
            {
                copyDirectory(di.FullName, newFolderName + "/" + di.Name);
            }
            /* 复制本目录文件 */
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach(FileInfo fi in fileInfo)
            {
                copyFile(fi.FullName, newFolderName + "/" + fi.Name);
            }
            return newFolderName;
        }
        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static string moveDirectory(string source, string destination)
        {
            if (!Directory.Exists(source)) return null;
            /* 遍历source目录下文件夹 */
            DirectoryInfo directoryInfo = new DirectoryInfo(source);
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            string newFolderName = destination;
            if (newFolderName.Equals(source)) return newFolderName;
            /* 防止重名 */
            int counter = 0;
            while (Directory.Exists(newFolderName))
            {
                ++counter;
                newFolderName = Path.GetDirectoryName(destination) + "/" + Path.GetFileNameWithoutExtension(destination) + "_" +
                    counter.ToString();
                //string a = "";
            }
            /* 复制本目录文件 */
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            Directory.Move(source, newFolderName);
            foreach (FileInfo fi in fileInfo)
            {
                moveFile(fi.FullName, newFolderName + "/" + fi.Name);
            }
            
            /* 递归 */
            foreach (DirectoryInfo di in directoryInfos)
            {
                moveDirectory(di.FullName, newFolderName + "/" + di.Name);
            }
            
            return newFolderName;
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="directory"></param>
        public static void deleteDirectory(string path)
        {
            if (!Directory.Exists(path)) return;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectoryInfo[] directory_info = directoryInfo.GetDirectories();
            /* 递归子目录 */
            foreach(DirectoryInfo di in directory_info)
            {
                deleteDirectory(di.FullName);
            }
            /* 删除本目录文件 */
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach(FileInfo fi in fileInfo)
            {
                File.Delete(fi.FullName);
            }
            /* 删除本目录 */
            Directory.Delete(path);
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static string createFolder(string path)
        {
            string newFileName = path + "/" + "新建文件夹";
            int counter = 0;
            while (Directory.Exists(newFileName))
            {
                ++counter;
                newFileName = path + "/" + "新建文件夹" + "_" + counter.ToString();
            }
            Directory.CreateDirectory(newFileName);
            return newFileName;
        }
        
        /// <summary>
        /// 自定义文件类，用于配合主ListView显示文件
        /// </summary>
        public class TreeFileInfo
        {
            public FileInfo Fileinfo;
            /// <summary>
            /// 图标
            /// </summary>
            public Bitmap Icon;
            /// <summary>
            /// 扩展名
            /// </summary>
            public string ExtendName
            {
                get { return Path.GetExtension(Fileinfo.Name); }
            }
            public TreeFileInfo() { }
            public TreeFileInfo(string full_name)
            {
                Fileinfo = new FileInfo(full_name);
            }
            /// <summary>
            /// 修改时间
            /// </summary>
            public double ModifyTime
            {
                get
                {
                    return Fileinfo.LastWriteTime.Subtract(MyConfig.RefTime).TotalSeconds;
                }
            }
        }
    }
}
