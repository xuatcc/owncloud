﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();
        }

        private void SyncForm_SizeChanged(object sender, EventArgs e)
        {
            panel_functionList.Width = this.Width;
        }
    }
}
