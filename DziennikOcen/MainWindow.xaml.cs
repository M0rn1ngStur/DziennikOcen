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

namespace DziennikOcen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showStudents(object sender, RoutedEventArgs e)
        {
            Window showStudents = new ShowStudents();
            showStudents.Show();
            this.Close();
        }
        private void showAttendances(object sender, RoutedEventArgs e)
        {
            Window showAttendances = new ShowAttendances();
            showAttendances.Show();
            this.Close();
        }
        private void showClasses(object sender, RoutedEventArgs e)
        {
            Window showClasses = new ShowClasses();
            showClasses.Show();
            this.Close();
        }
        private void showGrades(object sender, RoutedEventArgs e)
        {
            Window showGrades = new ShowGrades();
            showGrades.Show();
            this.Close();
        }
    }
}
