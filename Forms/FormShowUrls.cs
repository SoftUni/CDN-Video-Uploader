using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CDN_Video_Uploader.Forms
{
    public partial class FormShowUrls : Form
    {
        public FormShowUrls()
        {
            InitializeComponent();
        }

        public FormShowUrls(IEnumerable<string> urls) : this()
        {
            this.textBoxUrls.Text = string.Join(Environment.NewLine, urls);
        }
    }
}
