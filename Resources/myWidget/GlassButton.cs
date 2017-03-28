using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace custom_cloud
{
    public partial class GlassButton : UserControl
    {
        public GlassButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);                   //双缓冲防止重绘时闪烁
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);           //忽略 WM_ERASEBKGND 窗口消息减少闪烁
            SetStyle(ControlStyles.UserPaint, true);                      //自定义绘制控件内容
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);   //模拟透明            
            SetStyle(ControlStyles.Selectable, true);                     //接收焦点
            Size = new Size(73, 81);                                      //初始大小
            Font = new Font("微软雅黑", 9);                               //控件字体
        }
        ///<summary>
        /// 控件状态
        ///</summary>
        public enum State
        {
            ///<summary>
            /// 无
            ///</summary>
            Normal = 0,
            ///<summary>
            /// 获得焦点
            ///</summary>
            Focused = 1,
            ///<summary>
            /// 失去焦点
            ///</summary>
            LostFocused = 2,
            ///<summary>
            /// 鼠标指针进入控件
            ///</summary>
            MouseEnter = 3
        }


        Bitmap _bmp;
        ///<summary>
        /// 获取或设置控件显示的图片
        ///</summary>
        [Description("获取或设置控件显示的图标")]
        public Bitmap Bitmap
        {
            get { return _bmp; }
            set
            {
                _bmp = value;
                Invalidate(false);
            }
        }
        bool _focused;
        State state;
        ///<summary>
        /// 重写控件焦点属性
        ///</summary>
        [Description("重写控件焦点属性")]
        public new bool Focused
        {
            get { return _focused; }
            set
            {
                _focused = value;


                if (_focused)
                    state = State.Focused;
                else
                    state = State.LostFocused;


                Invalidate(false);
            }
        }
        
        //自定义绘制
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;


            switch (state)
            {
                case State.Focused:
                    {
                        DrawSelected(g);
                        break;
                    }
                case State.MouseEnter:
                    {
                        if (!Focused)
                            g.DrawImage(Properties.Resources.enter, ClientRectangle);
                        else
                            DrawSelected(g);
                        break;
                    }
            }


            DrawImage(g);
            DrawText(g);
        }


        //焦点进入
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            Focused = true;
        }


        //失去焦点
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Focused = false;
        }


        //禁止调整大小
        protected override void OnResize(EventArgs e)
        {
            Width = 73;
            Height = 81;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            state = State.MouseEnter;
            Invalidate(false);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!Focused)
            {
                state = State.LostFocused;
                Invalidate(false);
            }
        }


        //只响应单击鼠标左键事件
        protected override void OnClick(EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;
            if (m.Button == MouseButtons.Left)
            {
                base.OnClick(e);
                Focus();
            }
        }
        #region//Draw
        void DrawSelected(Graphics g)
        {
            g.DrawImage(Properties.Resources.down, ClientRectangle);
        }

        int bmp_Left;
        int bmp_Top;
        void DrawImage(Graphics g)
        {
            if (_bmp != null)
            {
                Bitmap bmp = ScaleZoom(_bmp);
                bmp_Left = (Width - bmp.Width) / 2;
                g.DrawImage(bmp, new Rectangle(bmp_Left, bmp_Top, bmp.Width, bmp.Height));
            }
        }


        void DrawText(Graphics g)
        {
            SizeF size = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - size.Width) / 2, 58);
        }
        #endregion

        int bmp_Size;
        #region//按比例缩放图片
        public Bitmap ScaleZoom(Bitmap bmp)
        {
            if (bmp != null)
            {
                double zoomScale;
                if (bmp.Width > bmp_Size || bmp.Height > bmp_Size)
                {
                    double imageScale = (double)bmp.Width / (double)bmp.Height;
                    double thisScale = 1;


                    if (imageScale > thisScale)
                    {
                        zoomScale = (double)bmp_Size / (double)bmp.Width;
                        return BitMapZoom(bmp, bmp_Size, (int)(bmp.Height * zoomScale));
                    }
                    else
                    {
                        zoomScale = (double)bmp_Size / (double)bmp.Height;
                        return BitMapZoom(bmp, (int)(bmp.Width * zoomScale), bmp_Size);
                    }
                }
            }
            return bmp;
        }
        #endregion


        #region//缩放BitMap
        ///<summary>
        /// 图片缩放
        ///</summary>
        ///<param name="bmpSource">源图片</param>
        ///<param name="bmpSize">缩放图片的大小</param>
        ///<returns>缩放的图片</returns>
        public Bitmap BitMapZoom(Bitmap bmpSource, int bmpWidth, int bmpHeight)
        {
            Bitmap bmp, zoomBmp;
            try
            {
                bmp = new Bitmap(bmpSource);
                zoomBmp = new Bitmap(bmpWidth, bmpHeight);
                Graphics gh = Graphics.FromImage(zoomBmp);
                gh.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gh.DrawImage(bmp, new Rectangle(0, 0, bmpWidth, bmpHeight), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);


                gh.Dispose();
                return zoomBmp;
            }
            catch
            { }
            finally
            {
                bmp = null;
                zoomBmp = null;
                GC.Collect();
            }
            return null;
        }
        #endregion
    }
}
