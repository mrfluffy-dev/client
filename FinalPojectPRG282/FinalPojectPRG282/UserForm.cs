using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPojectPRG282
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Image";
            o.Filter = "JPG | *.jpg| PNG | *.png";
            if(o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pic.ImageLocation = o.FileName;
            }
        }
    }
}
