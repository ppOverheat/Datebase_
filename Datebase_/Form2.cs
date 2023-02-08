using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datebase_
{
    public partial class Form2 : Form
    {
        bool logged = false;
        public Form2()
        {
            InitializeComponent();
            authBox.SelectedIndex = 0;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!Common.ConnectStr(serverBox.Text, loginBox.Text, psdBox.Text, logged))
            {
                this.Visible = false;
                new Form1().ShowDialog();
            }
        }
        private void onAuthChanged(object sender, EventArgs e)
        {
            logged = (authBox.SelectedIndex == 0)?false:true;
            loginBox.Enabled = logged;
            psdBox.Enabled = logged;
        }
    }
}
