using GUI.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String famName = textBox2.Text;
            String email = textBox3.Text;

            try
            {
                ServiceFacade.Instance.RegisterStudent(name, famName, email);
                this.Close();
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
