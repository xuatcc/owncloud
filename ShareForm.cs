using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class ShareForm : Form
    {
        public ShareForm()
        {
            InitializeComponent();
        }

        private void ShareForm_SizeChanged(object sender, EventArgs e)
        {
            panel_functionList.Height = this.Height;
        }
    }
}
