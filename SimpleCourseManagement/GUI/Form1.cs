﻿using GUI.Facade;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int studentId = -1;
            try
            {
                ServiceFacade.Instance.RegisterStudent("hej", "med", "dig@uni.dk");
                studentId = ServiceFacade.Instance.GetStudentId("dig@uni.dk");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                ServiceFacade.Instance.RegisterCourse(studentId, 1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;

            try
            {
                int studentId = ServiceFacade.Instance.GetStudentId(email);
                Form3 f3 = new Form3(studentId);
                f3.ShowDialog();
                this.Close();
            }
            catch(FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
