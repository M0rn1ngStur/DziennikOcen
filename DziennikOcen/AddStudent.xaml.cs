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
    /// Logika interakcji dla klasy AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        private async void submit(object sender, RoutedEventArgs e)
        {
            using (var context = new DziennikOcenContext())
            {
                Student x = new Student { Name = Name.Text, GroupSymbol = GroupSymbol.Text };
                context.Students.Add(x);
                await context.SaveChangesAsync();
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window showStudent = new ShowStudents();
            showStudent.Show();
            this.Close();
        }
    }
}
