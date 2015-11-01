using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Facade;

namespace GUI
{
    public partial class Form5 : Form
    {
        int id;
        public Form5(int studentid)
        {
            InitializeComponent();
            id = studentid;
            List<double> allGrades = ServiceFacade.Instance.GetExamGrades(id);
            String grade = string.Join(",", allGrades.ToArray());
            richTextBox1.Text = grade;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String examstring = textBox1.Text;
            int examid = Int32.Parse(examstring);
            double grade = ServiceFacade.Instance.GetExamGrade(id, examid);
            label1.Text = grade.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
