using GUI.Facade;
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
    public partial class Form4 : Form
    {
        int id;
        public Form4(int studentid)
        {
            InitializeComponent();
            id = studentid;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String coursestring = textBox1.Text;
            int courseid = Int32.Parse(coursestring);
            ServiceFacade.Instance.RegisterCourse(id, courseid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String coursestring = textBox1.Text;
            int courseid = Int32.Parse(coursestring);
            ServiceFacade.Instance.UnregisterCourse(id, courseid);
        }
    }
}
