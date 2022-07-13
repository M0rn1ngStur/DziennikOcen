using DziennikOcen.Model;
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
using System.Windows.Shapes;

namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy AddGrade.xaml
    /// </summary>
    public partial class AddGrade : Window
    {
        public AddGrade()
        {
            InitializeComponent();
        }
        private async void submit(object sender, RoutedEventArgs e)
        {
            using (var context = new DziennikOcenContext())
            {
                Grade x = new Grade { StudentId = int.Parse(StudentId.Text), Grade1 = int.Parse(Grade1.Text), ClassId = int.Parse(ClassId.Text) };
                context.Grades.Add(x);
                await context.SaveChangesAsync();
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window showGrades = new ShowGrades();
            showGrades.Show();
            this.Close();
        }
    }
}
