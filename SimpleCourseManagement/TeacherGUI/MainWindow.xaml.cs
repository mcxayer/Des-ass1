using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeacherGUI.Facade;

namespace TeacherGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NetworkFacade nf;

        public MainWindow()
        {
            InitializeComponent();
            nf = new NetworkFacade();
            UpdateCoursesListView();
        }

        public void UpdateCoursesListView()
        {
            lstCourses.Items.Clear();
            foreach (int i in nf.GetListOfCourseId())
            {
                List<string> courseInfo = nf.GetCourseInfo(i);
                lstCourses.Items.Add(courseInfo);
            }
        }

        private void lstCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> fetchedCourseId = (List<string>)lstCourses.SelectedItem;
            lstViewStudents.Items.Clear();

            foreach(int i in nf.GetStudentIdsForCourse(Int32.Parse(fetchedCourseId[0]))){
                List<string> studentInfo = nf.GetStudentInfo(i);
                lstViewStudents.Items.Add(studentInfo);
            }
        }
    }
}
