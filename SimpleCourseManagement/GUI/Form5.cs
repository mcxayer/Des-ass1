using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form5 : Form
    {
        int id;
        public Form5(int studentid)
        {
            InitializeComponent();
            id = studentid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
