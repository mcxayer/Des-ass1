using AdminGUI.Facade;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceFacade nf;

        public MainWindow()
        {
            InitializeComponent();
            nf = new ServiceFacade();
            UpdateCoursesListView();
            UpdateTeacherComboBox();
            UpdateTeacherListView();

        }

        public void UpdateCoursesListView()
        {
            try
            {
                lstCourses.Items.Clear();
                foreach (int i in nf.GetListOfCourseId())
                {
                    List<string> courseInfo = nf.GetCourseInfo(i);
                    lstCourses.Items.Add(courseInfo);
                }
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTeacherListView()
        {
            try
            {
                lstTeachers.Items.Clear();
                foreach (int i in nf.GetListOfTeacherId())
                {
                    List<string> teacherInfo = nf.GetTeacherInfo(i);
                    lstTeachers.Items.Add(teacherInfo);
                }
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTeacherComboBox()
        {
            try
            {
                cmbTeacher.Items.Clear();
                foreach (int i in nf.GetListOfTeacherId())
                {
                    List<string> teacherInfo = nf.GetTeacherInfo(i);
                    cmbTeacher.Items.Add(teacherInfo[0] + " " + teacherInfo[1] + " " + teacherInfo[2]);
                }
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int courseId = nf.CreateCourse(txbName.Text, cmbInstance.SelectedIndex + 1, Int32.Parse(txbInstanceYear.Text), txbDescription.Text, Int32.Parse(txbEcts.Text));

                if (cmbTeacher.SelectedIndex != -1)
                {
                    String teacherItem = ((String)cmbTeacher.SelectedValue);

                    for (int i = 0; i < teacherItem.Length; i++)
                    {
                        if(!char.IsDigit(teacherItem[i]))
                        {
                            int teacherId;
                            if (Int32.TryParse(teacherItem.Substring(0, teacherItem.Length - i), out teacherId))
                            {
                                Console.WriteLine(teacherId + " " + courseId);
                                nf.AssignCourseTeacher(teacherId,courseId);
                            }
                            break;
                        }
                    }
                }

                UpdateCoursesListView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some of the filled textfield doesn't match the required input. Please fill out form correctly.");
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSaveTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nf.CreateTeacher(txbTeacherName.Text, txbFamilyName.Text, txbEmail.Text);
                UpdateTeacherListView();
                UpdateTeacherComboBox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some of the filled textfield doesn't match the required input. Please fill out form correctly.");
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
